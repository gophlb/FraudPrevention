using FraudPrevention.Analyzers;
using FraudPrevention.Dumpers;
using FraudPrevention.Readers;
using FraudPrevention.Transformers;
using System;
using Utils.Extensions;

public class Solution
{
    public static void Main(String[] args)
    {
        /*
        Ideal way combining readers and dumpers into controllers: 
            fraudprevention -f SourcePath -f TargetPath
            fraudprevention -db DataBaseConnectionString -f TargetPath
            fraudprevention -db DataBaseConnectionString (-db DataBaseConnectionString)? // Second parameter depending on the answer to "it's the same database?"
            fraudprevention -xm XmlSourcePath -f TargetPath
            fraudprevention -xm XmlSourcePath -db DataBaseConnectionString
            ...
        
        But, for time reasons, I will assume this format:
            fraudprevention SourcePath TargetPath
        */


        if (args == null || !(args.Length == 2))
        {
            Console.WriteLine("We need the path of the source and target file. Try running again the application specifying them. Press Enter to exit.");
            Console.ReadLine();
        }
        else
        {
            string filePathSource = args[0];
            string filePathTarget = args[1];

            try
            {
                ITransformer transformer = new Transformer();
                IReader fileReader = new FileReader(filePathSource);
                IAnalyzer fileAnalyzer = new FileAnalyzer(fileReader, transformer);

                AnalysisResult analysisResult = fileAnalyzer.Analyze();
                IDumper fileDumper = new FileDumper(analysisResult, filePathTarget);

                // A better way to inform about the result would be an Enum with some codes (error dumping, error reading, error connecting to db, etc)
                bool operationFinished = fileDumper.Dump();
                if (operationFinished)
                {
                    Console.WriteLine("The application finished correctly. Press Enter to exit.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("The application encountered an error. Please check the logs. Press Enter to exit.");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                ex.Log("");
                Console.WriteLine("The application encountered an error. Please check the logs. Press Enter to exit.");
                Console.ReadLine();                
            }
        }
    }
}