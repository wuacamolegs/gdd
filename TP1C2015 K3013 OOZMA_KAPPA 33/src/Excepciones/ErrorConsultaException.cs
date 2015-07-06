using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class ErrorConsultaException : Exception
    {
        public ErrorConsultaException()
            : base("Se genero un error al ejecutar una consulta")
        {
        }
        public ErrorConsultaException(string storedProcedure)
            : base("Se genero un error al ejecutar: " + storedProcedure)
        {
        }
        public ErrorConsultaException(string storedProcedure, Exception mensaje)
            : base("Se genero un error al ejecutar: " + storedProcedure, mensaje)
        {
        }
    }
}