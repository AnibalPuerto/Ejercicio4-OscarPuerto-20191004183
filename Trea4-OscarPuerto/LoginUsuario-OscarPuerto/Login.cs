using BD_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginUsuario_OscarPuerto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_correo.Text == String.Empty)
            {
                errorProvider1.SetError(txt_correo, "Ingrese un correo");
                txt_correo.Focus();
                return;
            }
            errorProvider1.Clear();
            if (txt_contraseña.Text == String.Empty)
            {
                errorProvider1.SetError(txt_contraseña, "Ingrese su contraseña");
                txt_contraseña.Focus();
                return;
            }
            errorProvider1.Clear();

           
            UsuarioDatos usuarioDatos = new UsuarioDatos();

            bool validar = await usuarioDatos.InicioSesion(txt_correo.Text, txt_contraseña.Text);
            if (validar)
            {
                LoginExitoso formExitoso = new LoginExitoso();
                Hide();
                formExitoso.Show();
            }
            else
            {
                MessageBox.Show("El correo o contraseña ingresados son incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
