using System;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace Log
{
    public class FSLogger
    {
        private string fileName;
        private string path = Directory.GetCurrentDirectory();
        private string rutaCompleta;
        
        // si pasamos la ruta de un archivo, se utilizará ese para hacer el log
        public FSLogger(string file)
        {
            fileName = file;
            if (!File.Exists(path + "\\" + fileName + ".txt"))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path + "\\" + fileName + ".txt"))
                {
                    sw.WriteLine(" |FECHA|     |USUARIO|  |LOGIN|  |CANTIDAD INTENTOS|");

                }
            }
      }

    
        public void EscribirLog(string Usuario, string EstadoLogin, Int64 cantidadIntentosFallidos)
        {
            rutaCompleta = path + "\\" + fileName + ".txt";
            try
            {
                using (StreamWriter w = File.AppendText(rutaCompleta))
                {
                    w.WriteLine(ConfigurationManager.AppSettings["Fecha"] + " - " + Usuario + " - " + EstadoLogin + " - " + cantidadIntentosFallidos);
                }
            }
            catch { }
        }

     
    }
}