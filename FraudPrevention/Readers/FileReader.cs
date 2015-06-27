using System;
using System.IO;
using Utils.Extensions;
using System.Linq;

namespace FraudPrevention.Readers
{
    public class FileReader : IReader
    {
        private string filePath = "";

        public FileReader(string filePath) 
        {
            this.filePath = filePath;
        }
        

        public string[] ReadInput()
        {
            string[] result;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            else 
            {
                try
                {
                    //First line is only for check purposes. Maybe other day :(
                    result = File.ReadAllLines(filePath).Skip(1).ToArray<string>();
                }
                catch(Exception ex)
                {
                    ex.Log("");
                    throw;
                }
            }

            return result;
        }
    }
}