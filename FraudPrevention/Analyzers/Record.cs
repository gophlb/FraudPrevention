using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention.Analyzers
{
    public class Record
    {
        public int OrderId { get; set; }
        public int DealId { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CreditCardNumber { get; set; }


        public bool Equals(object anotherRecord)
        {
            Record aux = anotherRecord as Record;
            
            return
                (this.Email == aux.Email && this.DealId == aux.DealId)
                ||
                (
                    (
                        this.StreetAddress == aux.StreetAddress
                        || this.City == aux.City
                        || this.State == aux.State
                        || this.ZipCode == aux.ZipCode
                    )
                    && this.DealId == aux.DealId
                    && this.CreditCardNumber != aux.CreditCardNumber
                )
                ;
        }

    }
}
