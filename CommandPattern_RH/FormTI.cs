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
    public partial class FormTI : Form, CommandCrear
    {
        private Empleado empleado;
        public Receiver receiver { get; set; }
        public FormTI(Empleado empleado)
        {
            
            InitializeComponent();
            this.empleado = empleado; 
        }

        private void FormTI_Load(object sender, EventArgs e)
        {

        }

        public string execute(string estatus)
        {
            if (estatus == "aprobar")
            {
                empleado.CuentaCorreo = txtCorreo.Text;
                return estatus;
            }
            else if (estatus == "desaprobar")
                return estatus;
            else
                return "en_espera";
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            receiver.enviarEstatus(1, this.execute("aprobar"));
            
        }

        private void btnDesaprobar_Click(object sender, EventArgs e)
        {
            receiver.enviarEstatus(1, this.execute("desaprobar"));

        }

    }
}
