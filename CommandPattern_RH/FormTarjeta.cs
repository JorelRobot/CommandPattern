using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandPattern_RH
{
    public partial class FormTarjeta : Form, CommandCrear
    {
        private Empleado empleado;
        public Receiver receiver { get; set; }

        public FormTarjeta(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;   
        }

        private void FormTarjeta_Load(object sender, EventArgs e)
        {
        
        }

        public string execute(string estatus)
        {
            if (estatus == "aprobar")
            {
                empleado.CuentaTarjeta = txtTarjeta.Text;
                return estatus;
            }
            else if (estatus == "desaprobar")
                return estatus;
            else
                return "en_espera";
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            receiver.enviarEstatus(2,this.execute("aprobar"));
        }

        private void btnDesaprobar_Click(object sender, EventArgs e)
        {
            receiver.enviarEstatus(2, this.execute("desaprobar"));
        }
    }
}
