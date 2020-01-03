using BL.RapiAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.RapiAuto
{
    public partial class formVehiculos : Form
    {   
        private void btAgregarFoto_Click(object sender, EventArgs e)
        {


        }
        private void fotoPictureBox_Click(object sender, EventArgs e)
        {

        }
        private void btRemoverFoto_Click(object sender, EventArgs e)
        {

        }
        private void formVehiculos_Load(object sender, EventArgs e)
        {

        }
        private void btAgregarFoto_Click_1(object sender, EventArgs e)
        {

        }
        private void btAgregarFoto_Click_2(object sender, EventArgs e)
        {

        }
        private void listaVehiculosBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        VehiculosBL _vehiculos;
        TipoBL _tiposBL;
        CombustibleBL _combustiblesBL;
        TransmisionBL _transmisionesBL;
        public formVehiculos()
        {
            InitializeComponent();
            List<TextBox> BuscarTlist = new List<TextBox>();
            List<string> BuscarSlist = new List<String>();
            BuscarTlist.Add(txtBuscarVehiculoModelo);
            BuscarSlist.Add("Buscar vehiculo por modelo");
            SetCueBanner(ref BuscarTlist, BuscarSlist);

            _vehiculos = new VehiculosBL();
            listaVehiculosBindingSource.DataSource = _vehiculos.ObtenerVehiculos();

            _tiposBL = new TipoBL();
            listaTiposBindingSource.DataSource = _tiposBL.ObtenerTipos();

            _combustiblesBL = new CombustibleBL();
            listaCombustiblesBindingSource.DataSource = _combustiblesBL.ObtenerCombustibles();

            _transmisionesBL = new TransmisionBL();
            listaTransmisionesBindingSource.DataSource = _transmisionesBL.ObtenerTransmisiones();

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

        private void listaVehiculosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaVehiculosBindingSource.EndEdit();
            var vehiculo = (Vehiculo)listaVehiculosBindingSource.Current;

            if(fotoPictureBox.Image != null)
            {
                vehiculo.Foto = Program.ImageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                vehiculo.Foto = null;
            }

            var resultado = _vehiculos.GuardarVehiculo(vehiculo);

            if (resultado.Exitoso==true)
            {
                listaVehiculosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Vehiculo guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _vehiculos.AgregarVehiculo();
            listaVehiculosBindingSource.MoveNext();
            

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

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {

            var resultado = _vehiculos.EliminarVehiculo(id);
            if (resultado == true)
            {
                listaVehiculosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el vehiculo");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            _vehiculos.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

        private void btAgregarFoto_Click_3(object sender, EventArgs e)
        {
            var vehiculo = (Vehiculo)listaVehiculosBindingSource.Current;

            if (vehiculo != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
            }
            else
            {
                MessageBox.Show("Cree un vehiculo antes de asignarle una imagen");
            }
        }

        private void btRemoverFoto_Click_1(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void txtBuscarFactura_TextChanged(object sender, EventArgs e)
        {
            _vehiculos = new VehiculosBL();
            var textoABuscar = txtBuscarVehiculoModelo.Text;
            listaVehiculosBindingSource.DataSource =
                _vehiculos.ObtenerVehiculos(textoABuscar);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var vehiculoId = Convert.ToInt32(idTextBox.Text);
                _vehiculos.RefrescarDatos(vehiculoId);

                listaVehiculosBindingSource.ResetBindings(false);
            }
            _vehiculos = new VehiculosBL();
            listaVehiculosBindingSource.DataSource = _vehiculos.ObtenerVehiculos();
        }
    }
}
