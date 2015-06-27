using FraudPrevention.Readers;
using FraudPrevention.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Extensions;

namespace FraudPrevention.Analyzers
{
    public class Analyzer : IAnalyzer
    {
        private IReader reader;
        private ITransformer transformer;

        public Analyzer(IReader reader, ITransformer transformer)
        {
            this.reader = reader;
            this.transformer = transformer;
        }

        public AnalysisResult Analyze()
        {
            AnalysisResult analysisResult = new AnalysisResult();
            try
            {
                string[] recordLines = reader.ReadInput();
                IEnumerable<Record> records = transformer.Transform(recordLines);

                bool[] checkedRecords = new bool[records.Count()];
                int duplicated = 0;
                bool firstDuplicated = true;
                Record currentRecord;
                Record comparedRecord;
                for (int i = 0; i < records.Count(); i++)
                {
                    if (!checkedRecords[i])
                    {
                        currentRecord = records.ElementAt(i);

                        firstDuplicated = true;
                        for (int j = i + 1; j < records.Count(); j++)
                        {
                            if (!checkedRecords[j])
                            {
                                comparedRecord = records.ElementAt(j);
                                if (currentRecord.Equals(comparedRecord))
                                {
                                    if (firstDuplicated)
                                    {
                                        analysisResult.fraudulentIds.Add(currentRecord.OrderId);
                                        duplicated++;
                                        firstDuplicated = false;
                                    }

                                    analysisResult.fraudulentIds.Add(comparedRecord.OrderId);                                        
                                    checkedRecords[j] = true;                                    
                                }
                            }
                        }

                        checkedRecords[i] = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Log("");
                throw;
            }

            return analysisResult;
        }
    }
}
