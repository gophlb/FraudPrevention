using System.Collections.Generic;
using System.Linq;

namespace FraudPrevention.Analyzers
{
    public class AnalysisResult
    {
        public ICollection<int> fraudulentIds { get; set; }

        public AnalysisResult()
        {
            fraudulentIds = new List<int>();
        }

        override public string ToString() 
        {
            return string.Join(",", fraudulentIds.ToArray());
        }
    }
}
