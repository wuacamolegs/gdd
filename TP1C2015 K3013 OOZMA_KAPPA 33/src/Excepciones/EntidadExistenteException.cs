using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{

    public class EntidadExistenteException : Exception
    {
        public EntidadExistenteException(string textoExistente)
            : base("Ya existe " + textoExistente + " con estos datos.")
        {
        }
    }
}
