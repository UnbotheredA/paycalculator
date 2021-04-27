using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.PayCalculator.Utilities
{
    [Serializable()]
    public class NegativeSalaryException : System.Exception
    {
        public NegativeSalaryException() : base() { }
        public NegativeSalaryException(string message) : base(message) { }
        public NegativeSalaryException(string message, Exception inner) : base(message, inner) { }
        
        // this last consturctor is optional
        protected NegativeSalaryException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
