using FraudPrevention.Analyzers;
using System;
using Utils.Extensions;

namespace FraudPrevention.Dumpers
{
    public class ConsoleDumper : IDumper
    {        
        private AnalysisResult analysisResult;

        public ConsoleDumper(AnalysisResult analysisResult)
        {
            this.analysisResult = analysisResult;
        }


        public bool Dump()
        {
            bool result = false;

            try
            {
                Console.WriteLine(analysisResult.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                ex.Log("");     //This extension could use, again, some different strategies depending on context.
                result = false;
            }

            return result;
        }
    }
}
