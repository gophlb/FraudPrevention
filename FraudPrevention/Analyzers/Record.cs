using System;

namespace FraudPrevention.Analyzers
{
    public class Record : IEquatable<Record>
    {
        public int OrderId { get; set; }
        public int DealId { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CreditCardNumber { get; set; }


        public bool Equals(Record anotherRecord)
        {            
            return
                (this.Email == this.Email && this.DealId == this.DealId)
                ||
                (
                    (
                        this.StreetAddress == this.StreetAddress
                        || this.City == this.City
                        || this.State == this.State
                        || this.ZipCode == this.ZipCode
                    )
                    && this.DealId == this.DealId
                    && this.CreditCardNumber != this.CreditCardNumber
                )
                ;
        }

    }
}
