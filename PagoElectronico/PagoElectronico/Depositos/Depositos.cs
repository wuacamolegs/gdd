using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace PagoElectronico.Depositos
{
    public partial class frmDepositos : Form
    {
        /*
        public Usuario unUsuario = new Usuario();
        public Cliente unCliente;
        public Deposito depositoActual = new Deposito();
        public Tarjeta unaTarjeta = new Tarjeta();
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblCuenta;
        private ComboBox cmbCuenta;
        private Label lblImporte;
        private TextBox txtImporte;
        private ComboBox cmbMoneda;
        private Label lblMoneda;
        private Label lblTarjeta;
        private Button btnAceptar;
        private ComboBox cmbTarjeta;
        public Cuenta unaCuenta = new Cuenta();
        


        public Depositos()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

          

        private void Depositos_Load(object sender, EventArgs e)
        {
            //cargar cmb Clientes
            DataSet dsClientes = ObtenerClientes();
            DropDownListManager.CargarCombo(cmbCliente, dsClientes.Tables[0], "cliente_id", "cliente_nombre", false, "");
        }

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            double cuentaID = Convert.ToDouble(cmbCuenta.SelectedValue);
            DataSet dsCuenta = unaCuenta.TraerCuentaPorCuentaID(cuentaID);
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //CMBMONEDA SOLO PERMITE DOLARES
            cmbMoneda.Items.Add("DOLARES");
        }

       //ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
        
        public DataSet ObtenerClientes()
        {

            DataSet ds = new DataSet();
            if (unUsuario.Rol.rol_id == 1)
            {
                DataSet dsClientes = unCliente.ObtenerTodosLosClientes(unUsuario.usuario_id);
                ds = dsClientes;
            }
            else
            {
                DataSet dsClienteUsuario = unCliente.ObtenerClientesPorUsuarioID(unUsuario.usuario_id);
                ds = dsClienteUsuario;
            }

            return ds;

        }

        public DataSet ObtenerCuentasActivasPorClienteId()
        {
            int clienteID = Convert.ToInt32(cmbCliente.SelectedValue);
            DataSet dsClientes = ObtenerClientePorID(clienteID);
            unCliente.DataRowToObject(dsClientes.Tables[0].Rows[0]);

            Cuenta unaCuenta = new Cuenta(unCliente, unUsuario);
            DataSet dsCuentas = unaCuenta.TraerCuentasActivasPorClienteID();

            return dsCuentas;

        }
               
        public DataSet ObtenerClientePorID(int clienteID)
        {
            DataSet dsCliente = unCliente.TraerClientePorID(clienteID);
            return dsCliente;

        }

        //VALIDAR TARJETA NO VENCIDA
        private bool ValidarCampos()
        {
            string strErrores = "";
            strErrores = strErrores + Validator.ValidarNulo(txtImporte.Text, "Importe");
            if (strErrores.Length > 0)
            {
                MessageBox.Show(strErrores);
                txtImporte.Clear();
                return false;
            }
            else
            {
                return true;
            }

        }

        
        //HACER DEPOSITO
        private void realizarAccionesDeposito()
        {
            
        }

        //HACER DEPOSITO
        private void generarDepositoExitoso()
        {
         
            
        }













        private void InitializeComponent()
        {
this.lblCliente = new System.Windows.Forms.Label();
this.cmbCliente = new System.Windows.Forms.ComboBox();
this.lblCuenta = new System.Windows.Forms.Label();
this.cmbCuenta = new System.Windows.Forms.ComboBox();
this.lblImporte = new System.Windows.Forms.Label();
this.txtImporte = new System.Windows.Forms.TextBox();
this.cmbMoneda = new System.Windows.Forms.ComboBox();
this.lblMoneda = new System.Windows.Forms.Label();
this.lblTarjeta = new System.Windows.Forms.Label();
this.btnAceptar = new System.Windows.Forms.Button();
this.cmbTarjeta = new System.Windows.Forms.ComboBox();
this.SuspendLayout();
// 
// lblCliente
// 
this.lblCliente.AutoSize = true;
this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblCliente.Location = new System.Drawing.Point(24, 64);
this.lblCliente.Name = "lblCliente";
this.lblCliente.Size = new System.Drawing.Size(64, 16);
this.lblCliente.TabIndex = 1;
this.lblCliente.Text = "CLIENTE";
// 
// cmbCliente
// 
this.cmbCliente.FormattingEnabled = true;
this.cmbCliente.Location = new System.Drawing.Point(170, 59);
this.cmbCliente.Name = "cmbCliente";
this.cmbCliente.Size = new System.Drawing.Size(214, 21);
this.cmbCliente.TabIndex = 5;
// 
// lblCuenta
// 
this.lblCuenta.AutoSize = true;
this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblCuenta.Location = new System.Drawing.Point(24, 130);
this.lblCuenta.Name = "lblCuenta";
this.lblCuenta.Size = new System.Drawing.Size(64, 16);
this.lblCuenta.TabIndex = 6;
this.lblCuenta.Text = "CUENTA";
// 
// cmbCuenta
// 
this.cmbCuenta.FormattingEnabled = true;
this.cmbCuenta.Location = new System.Drawing.Point(170, 125);
this.cmbCuenta.Name = "cmbCuenta";
this.cmbCuenta.Size = new System.Drawing.Size(213, 21);
this.cmbCuenta.TabIndex = 7;
// 
// lblImporte
// 
this.lblImporte.AutoSize = true;
this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblImporte.Location = new System.Drawing.Point(24, 247);
this.lblImporte.Name = "lblImporte";
this.lblImporte.Size = new System.Drawing.Size(69, 16);
this.lblImporte.TabIndex = 8;
this.lblImporte.Text = "IMPORTE";
// 
// txtImporte
// 
this.txtImporte.Location = new System.Drawing.Point(170, 243);
this.txtImporte.Name = "txtImporte";
this.txtImporte.Size = new System.Drawing.Size(215, 20);
this.txtImporte.TabIndex = 9;
// 
// cmbMoneda
// 
this.cmbMoneda.FormattingEnabled = true;
this.cmbMoneda.Location = new System.Drawing.Point(170, 186);
this.cmbMoneda.Name = "cmbMoneda";
this.cmbMoneda.Size = new System.Drawing.Size(213, 21);
this.cmbMoneda.TabIndex = 10;
this.cmbMoneda.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
// 
// lblMoneda
// 
this.lblMoneda.AutoSize = true;
this.lblMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
this.lblMoneda.Location = new System.Drawing.Point(24, 191);
this.lblMoneda.Name = "lblMoneda";
this.lblMoneda.Size = new System.Drawing.Size(67, 16);
this.lblMoneda.TabIndex = 11;
this.lblMoneda.Text = "MONEDA";
// 
// lblTarjeta
// 
this.lblTarjeta.AutoSize = true;
this.lblTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
this.lblTarjeta.Location = new System.Drawing.Point(12, 302);
this.lblTarjeta.Name = "lblTarjeta";
this.lblTarjeta.Size = new System.Drawing.Size(155, 16);
this.lblTarjeta.TabIndex = 12;
this.lblTarjeta.Text = "TARJETA DE CREDITO";
// 
// btnAceptar
// 
this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnAceptar.Location = new System.Drawing.Point(291, 344);
this.btnAceptar.Name = "btnAceptar";
this.btnAceptar.Size = new System.Drawing.Size(94, 37);
this.btnAceptar.TabIndex = 13;
this.btnAceptar.Text = "Aceptar";
this.btnAceptar.UseVisualStyleBackColor = true;
// 
// cmbTarjeta
// 
this.cmbTarjeta.FormattingEnabled = true;
this.cmbTarjeta.Location = new System.Drawing.Point(170, 297);
this.cmbTarjeta.Name = "cmbTarjeta";
this.cmbTarjeta.Size = new System.Drawing.Size(214, 21);
this.cmbTarjeta.TabIndex = 14;
// 
// frmDepositos
// 
this.ClientSize = new System.Drawing.Size(444, 410);
this.Controls.Add(this.cmbTarjeta);
this.Controls.Add(this.btnAceptar);
this.Controls.Add(this.lblTarjeta);
this.Controls.Add(this.lblMoneda);
this.Controls.Add(this.cmbMoneda);
this.Controls.Add(this.txtImporte);
this.Controls.Add(this.lblImporte);
this.Controls.Add(this.cmbCuenta);
this.Controls.Add(this.lblCuenta);
this.Controls.Add(this.cmbCliente);
this.Controls.Add(this.lblCliente);
this.Name = "frmDepositos";
this.ResumeLayout(false);
this.PerformLayout();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

*/
    
       
    }
}
