using BL.RapiAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.RapiAuto
{
    public partial class FormUsuarios : Form
    {
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }
        private void clientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }
        private void FormUsuarios_Load(object sender, EventArgs e)
        {

        }
        
        SeguridadBL _SeguridadBL;
        PerfilUsuariosBL _PerfilUsuarioBL;

        public FormUsuarios()
        {
            InitializeComponent();

            _SeguridadBL = new SeguridadBL();
            listaUsuariosBindingSource.DataSource = _SeguridadBL.ObtenerUsuarios();

            _PerfilUsuarioBL = new PerfilUsuariosBL();
            listaPerfilesBindingSource.DataSource = _PerfilUsuarioBL.ObtenerPerfiles();
        }


        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            Cancelar.Visible = !valor;
        }

        private void DeshabilitarControles()
        {
            foreach (Control control in Controls)
            {
                if (control is GroupBox)
                    control.Enabled = false;
            }
        }

        private void HabilitarControles()
        {
            foreach (Control control in Controls)
            {
               if (control is GroupBox)
                    control.Enabled = true;
            }
        }

        private void listaUsuariosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaUsuariosBindingSource.EndEdit();
            var usuario = (Usuario)listaUsuariosBindingSource.Current;
            string ConfirmaContrasena = ConfirmarContrasenatextBox.Text;

            if (ConfirmaContrasena == contrasenaTextBox.Text)
            {
                var resultado = _SeguridadBL.GuardarUsuario(usuario);

                if (resultado.Exitoso == true)
                {
                    listaUsuariosBindingSource.ResetBindings(false);
                    DeshabilitarHabilitarBotones(true);
                    MessageBox.Show("Usuario guardado");
                    DeshabilitarControles();
                    tsbEditar.Enabled = true;

                }
                else
                {
                    MessageBox.Show(resultado.Mensaje);
                }
            }
            else
                MessageBox.Show("La contraseña no coincide con su confimación");
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

            _SeguridadBL.AgregarUsuario();
            listaUsuariosBindingSource.MoveLast();
            HabilitarControles();
            DeshabilitarHabilitarBotones(false);
        }

        private void Eliminar(int id)
        {
            var resultado = _SeguridadBL.EliminarUsuario(id);
            if (resultado)
                listaUsuariosBindingSource.ResetBindings(false);
            else
                MessageBox.Show("Ocurrió un error al eliminar el usuario");
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            DeshabilitarControles();
            Eliminar(0);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tsbEditar.Enabled = false;
            HabilitarControles();
        }
    }
}
