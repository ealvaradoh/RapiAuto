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
    public partial class FormReporteFacturas : Form
    {

        FacturaBL _FacturaBL;
        BindingSource bindingsourceFacturas;
        ClientesBL _ClientesBL;
        BindingSource bindingsourceClientes;
        ReporteFacturas reporte;

        public FormReporteFacturas()
        {
            InitializeComponent();

            List<TextBox> BuscarTlist = new List<TextBox>();
            List<string> BuscarSlist = new List<String>();
            BuscarTlist.Add(txtBuscarFactura);
            BuscarSlist.Add("Filtrar por número de factura");
            SetCueBanner(ref BuscarTlist, BuscarSlist);

            _FacturaBL = new FacturaBL();
            bindingsourceFacturas = new BindingSource();
            bindingsourceFacturas.DataSource = _FacturaBL.ObtenerFacturas();

            _ClientesBL = new ClientesBL();
            bindingsourceClientes = new BindingSource();
            bindingsourceClientes.DataSource = _ClientesBL.ObtenerClientes();

            reporte = new ReporteFacturas();
            reporte.Database.Tables[0].SetDataSource(bindingsourceFacturas);
            reporte.Database.Tables[1].SetDataSource(bindingsourceClientes);

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


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _FacturaBL = new FacturaBL();
            var textoABuscar = txtBuscarFactura.Text;
            bindingsourceFacturas.DataSource =
                _FacturaBL.ObtenerFacturas(textoABuscar);

            reporte.SetDataSource(bindingsourceFacturas);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
