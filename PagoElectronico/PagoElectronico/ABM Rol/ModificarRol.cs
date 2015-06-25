using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Clases;
using Utilities;

namespace PagoElectronico.ABM_Rol
{
    public partial class ModificarRol : Form
    {
        public Rol unRol = new Rol();

        public ModificarRol()
        {
            InitializeComponent();
        }
         
        public void abrirConRol(Rol rol)
        {
            unRol = rol;
            this.Show();
        }


    }
}
