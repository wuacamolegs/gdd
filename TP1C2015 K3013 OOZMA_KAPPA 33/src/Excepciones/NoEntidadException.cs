using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class NoEntidadException : Exception
    {
        public NoEntidadException()
            : base("La entidad que se intentó buscar no fue encontrada")
        {
        }
    }
}
