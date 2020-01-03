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
    public partial class FormFactura : Form
    {
        
        private void FormFactura_Load(object sender, EventArgs e)
        {

        }
        private void facturaDetalleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void totalLabel_Click(object sender, EventArgs e)
        {

        }
        private void subtotalLabel_Click(object sender, EventArgs e)
        {

        }
        private void impuestoLabel_Click(object sender, EventArgs e)
        {

        }
        private void impuestoTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void subtotalTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void totalTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void idLabel_Click(object sender, EventArgs e)
        {

        }
        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        FacturaBL _facturaBL;
        ClientesBL _clienteBL;
        VehiculosBL _vehiculoBL;

        //internal static formMenu mdiParent;

        public FormFactura()
        {
            InitializeComponent();

            List<TextBox> BuscarTlist = new List<TextBox>();
            List<string> BuscarSlist = new List<String>();
            BuscarTlist.Add(txtBuscarFactura);
            BuscarSlist.Add("Buscar número de factura");
            SetCueBanner(ref BuscarTlist, BuscarSlist);

            _facturaBL = new FacturaBL();
            listaFacturasBindingSource.DataSource = _facturaBL.ObtenerFacturas();

            _clienteBL = new ClientesBL();
            listaClientesBindingSource1.DataSource = _clienteBL.ObtenerClientes();

            _vehiculoBL = new VehiculosBL();
            listaVehiculosBindingSource.DataSource = _vehiculoBL.ObtenerVehiculos();

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
        
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _facturaBL.AgregarFactura();
            listaFacturasBindingSource.MoveLast();

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
            toolStripButtonCancelar.Visible = !valor;
        }

        private void listaFacturasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaFacturasBindingSource.EndEdit();

            var factura = (Factura)listaFacturasBindingSource.Current;
            var resultado = _facturaBL.GuardarFactura(factura);

            if (resultado .Exitoso ==true )
            {
                listaFacturasBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Factura Guardada");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            _facturaBL.CancelarCambios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var factura = (Factura)listaFacturasBindingSource.Current;
            _facturaBL.AgregarFacturaDetalle(factura);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var factura = (Factura)listaFacturasBindingSource.Current;
            var facturaDetalle = (FacturaDetalle)facturaDetalleBindingSource.Current;

            _facturaBL.RemoverFacturaDetalle(factura, facturaDetalle);
            DeshabilitarHabilitarBotones(false);
        }

        private void facturaDetalleDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void facturaDetalleDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var factura = (Factura)listaFacturasBindingSource.Current;
            _facturaBL.CalcularFactura(factura);

            listaFacturasBindingSource.ResetBindings(false);


        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea anular esta factura?", "Anular", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Anular(id);
                }
            }
        }

        private void Anular(int id)
        {
            var resultado = _facturaBL.AnularFactura(id);

            if (resultado == true)
            {
                listaFacturasBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al anular la factura");
            }
        }

        private void listaFacturasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var factura = (Factura)listaFacturasBindingSource.Current;

            if(factura != null && factura .Id !=0 && factura.Activo == false )
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }

        private void txtBuscarFactura_TextChanged(object sender, EventArgs e)
        {
            _facturaBL = new FacturaBL();
            var textoABuscar = txtBuscarFactura.Text;
            listaFacturasBindingSource.DataSource =
                _facturaBL.ObtenerFacturas(textoABuscar);
        }
    }
}
