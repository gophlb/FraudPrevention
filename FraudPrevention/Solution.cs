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
        try
        {
            ITransformer transformer = new Transformer();
            IReader reader = new ConsoleReader();
            IAnalyzer analyzer = new Analyzer(reader, transformer);
            AnalysisResult analysisResult = analyzer.Analyze();
            IDumper fileDumper = new ConsoleDumper(analysisResult);

            // A better way to inform about the result would be an Enum with some codes (error dumping, error reading, error connecting to db, etc)                
            bool operationFinished = fileDumper.Dump();
            string message = "";
            if (operationFinished) { message = ""; }
            else { message = "The application encountered an error. Please check the logs. Press Enter to exit."; }

            Console.WriteLine(message);
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            ex.Log("");
            Console.WriteLine("The application encountered an error. Please check the logs. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}


// ********************* USING FILES AS SOURCE AND TARGET
//using FraudPrevention.Analyzers;
//using FraudPrevention.Dumpers;
//using FraudPrevention.Readers;
//using FraudPrevention.Transformers;
//using System;
//using Utils.Extensions;

//public class Solution
//{
//    public static void Main(String[] args)
//    {
//        /*
//        Ideal way combining readers and dumpers into controllers: 
//            fraudprevention -f SourcePath -f TargetPath
//            fraudprevention -db DataBaseConnectionString -f TargetPath
//            fraudprevention -db DataBaseConnectionString (-db DataBaseConnectionString)? // Second parameter depending on the answer to "it's the same database?"
//            fraudprevention -xm XmlSourcePath -f TargetPath
//            fraudprevention -xm XmlSourcePath -db DataBaseConnectionString
//            ...

//        But, for time reasons, I will assume this format:
//            fraudprevention SourcePath TargetPath
//        */


//        if (args == null || !(args.Length == 2))
//        {
//            Console.WriteLine("We need the path of the source and target file. Try running again the application specifying them. Press Enter to exit.");
//            Console.ReadLine();
//        }
//        else
//        {
//            string filePathSource = args[0];
//            string filePathTarget = args[1];

//            try
//            {
//                ITransformer transformer = new Transformer();
//                IReader reader = new FileReader(filePathSource);
//                IAnalyzer analyzer = new Analyzer(reader, transformer);

//                AnalysisResult analysisResult = analyzer.Analyze();
//                IDumper fileDumper = new FileDumper(analysisResult, filePathTarget);

//                // A better way to inform about the result would be an Enum with some codes (error dumping, error reading, error connecting to db, etc)                
//                bool operationFinished = fileDumper.Dump();
//                string message = "";
//                if (operationFinished) { message = "The application finished correctly. Press Enter to exit."; }
//                else { message = "The application encountered an error. Please check the logs. Press Enter to exit."; }

//                Console.WriteLine(message);
//                Console.ReadLine();
//            }
//            catch (Exception ex)
//            {
//                ex.Log("");
//                Console.WriteLine("The application encountered an error. Please check the logs. Press Enter to exit.");
//                Console.ReadLine();                
//            }
//        }
//    }
//}