using BL.RapiAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.RapiAuto
{
    public partial class formClientes : Form
    {
        ClientesBL _cliente;
        public formClientes()
        {
            InitializeComponent();

            List<TextBox> BuscarTlist = new List<TextBox>();
            List<string> BuscarSlist = new List<String>();
            BuscarTlist.Add(txtBuscarCliente);
            BuscarSlist.Add("Buscar cliente por nombre");
            SetCueBanner(ref BuscarTlist, BuscarSlist);

            _cliente = new ClientesBL();
            listaClientesBindingSource.DataSource = _cliente.ObtenerClientes();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea eliminar este cliente?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _cliente.AgregarCliente();
            listaClientesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            Cancelar.Visible = !valor;
        }

        private void Eliminar(int id)
        {
            var resultado = _cliente.EliminarCliente(id);
            if (resultado)
                listaClientesBindingSource.ResetBindings(false);
            else
                MessageBox.Show("Ocurrió un error al eliminar el cliente");
        }

        private void listaClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaClientesBindingSource.EndEdit();
            var cliente = (Clientes)listaClientesBindingSource.Current;

            var resultado = _cliente.GuardarCliente(cliente);
            if (resultado.Exitoso)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Cliente guardado exitosamente");
            }
        }

        private void listaClientesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void formClientes_Load(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarCliente_TextChanged_1(object sender, EventArgs e)
        {
            _cliente = new ClientesBL();
            var textoABuscar = txtBuscarCliente.Text;
            listaClientesBindingSource.DataSource =
                _cliente.ObtenerClientes(textoABuscar);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var clienteId = Convert.ToInt32(idTextBox.Text);
                _cliente.RefrescarDatos(clienteId);
                
                listaClientesBindingSource.ResetBindings(false);
            }
        }
    }
}
