using System;
using System.IO;
using Utils.Extensions;
using System.Linq;
using System.Collections.Generic;

namespace FraudPrevention.Readers
{
    public class ConsoleReader : IReader
    {
        public ConsoleReader() { }


        public string[] ReadInput()
        {
            string[] result = null;

            try
            {
                string inputLine;
                int numberOfLines = 0;
                bool firstLine = true;
                ICollection<string> inputLines = new List<string>();
                while (!String.IsNullOrEmpty(inputLine = Console.ReadLine()))
                {
                    if (firstLine) 
                    {
                        firstLine = false;
                        numberOfLines = Convert.ToInt32(inputLine);
                    }
                    else 
                    {
                        inputLines.Add(inputLine);
                    }
                }

                if(numberOfLines != inputLines.Count())
                {
                    throw new Exception("Number of lines specified and introduced not equal.");
                }

                result = inputLines.ToArray();
            }
            catch (Exception ex)
            {
                ex.Log("");
                throw;
            }

            return result;
        }
    }
}