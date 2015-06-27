using FraudPrevention.Analyzers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Utils.Extensions;

namespace FraudPrevention.Transformers
{
    public class Transformer : ITransformer
    {
        public Transformer() { }

        public IEnumerable<Record> Transform(string[] records)
        {
            List<Record> result = new List<Record>();

            try
            {
                char[] splitSeparator = new char[] { ',' };

                Regex emailRegExp = new Regex(@"\+(\w)*@");
                foreach (string recordLine in records)
                {
                    string[] recordSplit = recordLine.Split(splitSeparator);

                    Record record = new Record() 
                    {
                        OrderId = Convert.ToInt16(recordSplit[0]),
                        DealId = Convert.ToInt16(recordSplit[1]),
                        Email = emailRegExp.Replace(recordSplit[2].ToLower().Replace(".", ""), "@"),
                        StreetAddress = recordSplit[3].ToLower().Replace("st.", "street").Replace("rd.", "road"),
                        City = recordSplit[4].ToLower(),
                        State = recordSplit[5].ToLower().Replace("il.", "illinois").Replace("ny", "new york"),
                        ZipCode = recordSplit[6].ToLower().Replace("-", ""),
                        CreditCardNumber = recordSplit[7].ToLower()
                    };
                    
                    result.Add(record);
                }
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
