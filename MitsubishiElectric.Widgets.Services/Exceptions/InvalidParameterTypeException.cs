using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitsubishiElectric.Widgets.Services.Exceptions
{
    public class InvalidParameterTypeException : Exception
    {
        public InvalidParameterTypeException() : base("Invalid input.")
        {
        }
    }
}
