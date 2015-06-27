using FraudPrevention.Analyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention.Transformers
{
    public interface ITransformer
    {
        IEnumerable<Record> Transform(string[] records);
    }
}
