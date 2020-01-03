using BL.RapiAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Win.RapiAuto
{
    public partial class FormReporteClientes : Form
    {
        ClientesBL _ClientesBL;
        BindingSource bindingsource;
        ReporteClientes reporte;
        public FormReporteClientes()
        {
            InitializeComponent();

            List<TextBox> BuscarTlist = new List<TextBox>();
            List<string> BuscarSlist = new List<String>();
            BuscarTlist.Add(txtBuscarCliente);
            BuscarSlist.Add("Filtrar cliente por nombre");
            SetCueBanner(ref BuscarTlist, BuscarSlist);

            _ClientesBL = new ClientesBL();
            bindingsource = new BindingSource();
            bindingsource.DataSource = _ClientesBL.ObtenerClientes();

            reporte = new ReporteClientes();
            reporte.SetDataSource(bindingsource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _ClientesBL = new ClientesBL();
            var textoABuscar = txtBuscarCliente.Text;
            bindingsource.DataSource =
                _ClientesBL.ObtenerClientes(textoABuscar);

            reporte.SetDataSource(bindingsource);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }

        private void txtBuscarCliente_Enter(object sender, EventArgs e)
        {
        }
    }
}
