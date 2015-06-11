using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Utilities
{
    public class Validator
    {
        public static string SoloNumeros(string textoAValidar, string nombreCampo)
        {
            string strError = "";

            if (strError.Length == 0 && !EsNumero(textoAValidar))
            {
                strError += "El campo " + nombreCampo + " tiene caracteres inválidos\n";
            }
            return strError;
        }

        public static string SoloNumerosODecimales(string textoAValidar, string nombreCampo)
        {
            string strError = "";

            if (strError.Length == 0 && !EsDecimal(textoAValidar))
            {
                strError += "El campo " + nombreCampo + " tiene caracteres inválidos\n";
            }
            return strError;
        }

        public static bool EsNumero(object obj)
        {
            try
            {
                int.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EsDecimal(object obj)
        {
            try
            {
                decimal.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public static string ValidarNulo(string textoAValidar, string nombreCampo)
        {
            if (string.IsNullOrEmpty(textoAValidar))
            {
                return "Tiene que ingresar un valor para el campo " + nombreCampo + "\n";
            }
            return string.Empty;
        }

        public static string EsAño(string año, string nombreCampo)
        {
            int unAño = Convert.ToInt32(año);
            if (unAño < 1900 || unAño > 2014)
                return "Tiene que ingresar un año válido, entre 1900 y 2015, para el campo " + nombreCampo + "\n";

            return string.Empty;
            
        }

        public static string ValidarFechaVencimiento(string fecha, string nombreCampo, DateTime fechaHoy)
        {
            DateTime unaFecha = Convert.ToDateTime(fecha);
            if (unaFecha < fechaHoy)
                return "Tiene que ingresar una fecha válida, para el campo " + nombreCampo + "\n";
            return string.Empty;
        }

        public static string ValidarCantidadMenor(string cant, int cantPublis, string nombreCampo)
        {
            int cantidad = Convert.ToInt32(cant);
            if (cantidad > cantPublis)
                return "No posee tantas publicaciones para rendir. Tiene que ingresar una cantidad válida, para el campo " + nombreCampo + "\n";
            return string.Empty;
        }

        public static string SoloNumerosPeroOpcional(string textoAValidar, string nombreCampo)
        {
            string strError = "";
            if (String.IsNullOrEmpty(textoAValidar))
                return strError;
            if (!EsNumero(textoAValidar))
            {
                strError += "El campo " + nombreCampo + " tiene caracteres inválidos\n";
            }
            return strError;
        }


        public static string MayorACero(string textoAValidar, string nombreCampo)
        {
            string strError = "";
            if (Convert.ToInt32(textoAValidar) == 0)
            {
                strError += "El campo " + nombreCampo + " debe ser mayor que cero\n";
            }
            return strError;
            
        }

        public static string validarNuloEnListaDeCheckbox(CheckedListBox lstRubros, string nombreListado)
        {
            string strError = "";
            if (lstRubros.CheckedItems.Count == 0)
            {
                strError += "El " + nombreListado + " debe tener seleccionado al menos un elemento. \n";
            }
            return strError;

        }


        public static string validarCuitCuil(string valor, string campoADevolver)
        {
            string strError = "";
            if (!validarCuitCuil(valor))
            {
                strError += "El " + campoADevolver + " no es válido. \n";
            }
            return strError;
        }

        //Validar  CUIT/CUIL valido
        public static bool validarCuitCuil(string valor)
        {
            if (valor.Length == 0) return false;

            var CuitCuilValidado = string.Empty;
            bool Valido = false;

            for (int i = 0; i < valor.Length; i++)
            {
                var Ch = valor[i];
                if ((Ch > 47) && (Ch < 58))
                {
                    CuitCuilValidado = CuitCuilValidado + Ch;
                }
            }

            valor = CuitCuilValidado;
            Valido = (valor.Length == 11);
            if (Valido)
            {
                int Verificador = digitoVerificador(valor);
                Valido = (valor[10].ToString() == Verificador.ToString());
            }

            return Valido;
        }

        //Obtengo el digito verificador del CUIT/CUIL
        private static int digitoVerificador(string CuitCuil)
        {
            int Sumador = 0;
            int Producto = 0;
            int Coeficiente = 0;
            int Resta = 5;
            for (int i = 0; i < 10; i++)
            {
                if (i == 4) Resta = 11;
                Producto = CuitCuil[i];
                Producto -= 48;
                Coeficiente = Resta - i;
                Producto = Producto * Coeficiente;
                Sumador = Sumador + Producto;
            }

            int Resultado = Sumador - (11 * (Sumador / 11));
            Resultado = 11 - Resultado;

            if (Resultado == 11) return 0;
            else return Resultado;
        }
    }
        
}
