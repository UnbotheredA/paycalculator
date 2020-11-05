using System;
using System.Collections.Generic;
using System.Text;

namespace paycalculator
{
    //base class only contatins things that other classes both need.
    public abstract class Employee
    {
        //properties tend to have first letter in caps
        protected string Name { get; set; }

        public Employee(string name) { //parameters camel-case name
        
            Name = name;
            
        }

        public abstract void HourlyPay();
    }
}

