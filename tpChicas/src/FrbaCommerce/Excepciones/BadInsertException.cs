using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class BadInsertException : Exception
    {
        public BadInsertException()
            : base("Un error ha ocurrido durante la ejecución.")
        {
        }
    }
}
