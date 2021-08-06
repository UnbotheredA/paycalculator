using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.PayCalculator.Utilities
{
    [Serializable()]
    public class InvalidSalaryException : System.Exception
    {
        public InvalidSalaryException() : base() { }
        public InvalidSalaryException(string message) : base(message) { }
        public InvalidSalaryException(string message, Exception inner) : base(message, inner) { }
        
        // this last consturctor is optional
        protected InvalidSalaryException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
