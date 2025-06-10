using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_library_management_system
{
    public class InputException : Exception
    {
        public string Value { get; }
        public InputException(string message, string value)
            : base(message)
        {
            Value = value;
        }
    }
}
