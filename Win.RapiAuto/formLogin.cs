using BL.RapiAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Win.RapiAuto
{
    public partial class formLogin : Form
    {
        public formMenu MenuPrincipal { get; set; }
        SeguridadBL _seguridad;

        public formLogin()
        {
            InitializeComponent();
            _seguridad = new SeguridadBL();

            List<TextBox> servidorTlist = new List<TextBox>();
            List<string> servidorSlist = new List<String>();
            servidorTlist.Add(txtServidor);
            servidorSlist.Add("Servidor");
            SetCueBanner(ref servidorTlist, servidorSlist);

            List<TextBox> usuarioTlist = new List<TextBox>();
            List<string> usuarioSlist = new List<String>();
            usuarioTlist.Add(txtUsuario);
            usuarioSlist.Add("Usuario");
            SetCueBanner(ref usuarioTlist, usuarioSlist);

            List<TextBox> contrasenaTlist = new List<TextBox>();
            List<string> contrasenaSlist = new List<String>();
            contrasenaTlist.Add(txtContraseña);
            contrasenaSlist.Add("Contraseña");
            SetCueBanner(ref contrasenaTlist, contrasenaSlist);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr i, string str);

        void SetCueBanner(ref List<TextBox> textBox, List<string> CueText)
        {
            for (int x = 0; x < textBox.Count; x++)
            {
                SendMessage(textBox[x].Handle, 0x1501, (IntPtr)1, CueText[x]);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public static string usuario;
        public static string contrasena;
        public static string servidor;
        private void btAceptar_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            contrasena = txtContraseña.Text;
            servidor = txtServidor.Text;

            btAceptar.Enabled = false;
            btAceptar.Text = "Verificando...";
            Application.DoEvents();

            var resultado = _seguridad.Autorizar(usuario, contrasena);

            if (resultado.Exitoso == true)
            {
                MenuPrincipal.Autorizar(resultado.Usuario);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

            btAceptar.Enabled = true;
            btAceptar.Text = "Aceptar";
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
