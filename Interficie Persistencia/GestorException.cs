using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Interficie_Persistencia
{
    public class GestorException : Exception
    {
        public GestorException(string message) : base(message)
        {
        }

        public GestorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
