using System;
using FraudPrevention.Analyzers;
using System.IO;
using Utils.Extensions;

namespace FraudPrevention.Dumpers
{
    public class FileDumper : IDumper
    {        
        private AnalysisResult analysisResult;
        private string filePathTarget = "";

        public FileDumper(AnalysisResult analysisResult, string filePathTarget)
        {
            this.analysisResult = analysisResult;
            this.filePathTarget = filePathTarget;
        }


        public bool Dump()
        {
            bool result = false;

            try
            {
                File.WriteAllText(filePathTarget, analysisResult.ToString());
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
