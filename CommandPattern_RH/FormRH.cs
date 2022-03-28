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
    public partial class FormRH : Form
    {
        private Empleado empleado;
        private Receiver receiver;
        private FormTarjeta formTarjeta;
        private FormTI formTI;
        public FormRH()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            empleado = new Empleado();
            receiver = new Receiver();

            formTarjeta = new FormTarjeta(empleado);            
            formTarjeta.receiver = receiver;

            formTI = new FormTI(empleado);
            formTI.receiver = receiver;

            receiver.enviarTicketRH(this);

        }

        public void ActualizarTargeta(string estatus)
        {
            txtEstadoTarjeta.Text = estatus;
            txtTarjeta.Text = empleado.CuentaTarjeta;
        }

        public void ActualizarTI(string estatus)
        {
            txtEstadoTI.Text = estatus;
            txtCorreo.Text = empleado.CuentaCorreo;
        }

        private void ticketTI_Click(object sender, EventArgs e)
        {
            receiver.setCommand(formTI);
            txtEstadoTI.Text = receiver.execute();
            formTI.Show();
        }

        private void btnTicketTarjeta_Click(object sender, EventArgs e)
        {
            receiver.setCommand(formTarjeta);
            txtEstadoTarjeta.Text = receiver.execute();
            formTarjeta.Show();

        }
        private bool ValidarEmpleado()
        {
            if (txtEstadoTarjeta.Text == "aprobar" && txtEstadoTI.Text == "aprobar")
            {
                return true;
  
            }
            else
            {
                return false;   
            }
           
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarEmpleado())
            {
                empleado.Nombre = txtNombre.Text;
                empleado.Apellidos = txtApellidos.Text;
                empleado.FechaNacimiento = txtNacimiento.Text;
                empleado.Domicilio = txtDomicilio.Text;
                empleado.Telefono = txtTelefono.Text;
                txtTarjeta.Text = empleado.CuentaTarjeta;
                txtCorreo.Text = empleado.CuentaCorreo;
                MessageBox.Show("Usuario registrado");
                
            }
            else
            {
                MessageBox.Show("No se puede guardar empleado sin ambos departamentos aprobados");

            }
        }
    }
}
