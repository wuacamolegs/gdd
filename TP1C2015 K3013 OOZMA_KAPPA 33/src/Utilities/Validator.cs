using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

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
                Int64.Parse(obj.ToString());
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
            Int64 unAño = Convert.ToInt64(año);
            MessageBox.Show("ANIO: " + unAño, "anio");
            if (unAño < 1900 || unAño > 2016)
                return "Tiene que ingresar un año válido, entre 1900 y 2016, para el campo " + nombreCampo + "\n";

            return string.Empty;

        }

        public static string ValidarFechaVencimiento(string fecha, string nombreCampo, DateTime fechaHoy)
        {
            DateTime unaFecha = Convert.ToDateTime(fecha);
            if (unaFecha < fechaHoy)
                return "Tiene que ingresar una fecha válida, para el campo " + nombreCampo + "\n";
            return string.Empty;
        }

        public static string ValidarSuscripcionesCantidadMenor(string cant, Int64 cantSuscr, string nombreCampo)
        {
            Int64 cantidad = Convert.ToInt64(cant);
            if (cantidad > cantSuscr)
                return "No posee tantas suscripciones para rendir. Tiene que ingresar una cantidad válida, para el campo " + nombreCampo + "\n";
            return string.Empty;
        }

        public static string ValidarSaldoCantidadMenor(string cant, Int64 cant2, string nombreCampo)
        {
            Int64 cantidad = Convert.ToInt64(cant);
            if (cantidad > cant2)
                return "No posee saldo suficiente en la cuenta actual. Tiene que ingresar una cantidad válida, para el campo " + nombreCampo + "\n";
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
            if (Convert.ToInt64(textoAValidar) <= 0)
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

        public static void SoloLetras(KeyPressEventArgs pE)
        {
            if (Char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsSeparator(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }

        }
    }
}
