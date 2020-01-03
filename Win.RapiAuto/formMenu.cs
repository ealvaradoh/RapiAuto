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

namespace Win.RapiAuto
{
    public partial class formMenu : Form
    {


        private void clientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public formMenu()
        {
            InitializeComponent();
        }

        private void Login()
        {
            var formLogin = new formLogin();
            formLogin.MenuPrincipal = this;
            formLogin.ShowDialog();
        }
        
        public void Autorizar(Usuario usuario)
        {
            clientesTSM.Enabled = usuario.PerfilUsuario.PuedeVerClientes;
            facturarTSM.Enabled = usuario.PerfilUsuario.PuedeVerFacturas;
            ReporteClientesTSM.Enabled = usuario.PerfilUsuario.PuedeVerReportes;
            ReporteFacturasTSM.Enabled = usuario.PerfilUsuario.PuedeVerReportes;
            ReporteVehiculosTSM.Enabled = usuario.PerfilUsuario.PuedeVerReportes;
            vehiculosTSM.Enabled = usuario.PerfilUsuario.PuedeVerVehiculos;
            controlDeUsuariosToolStripMenuItem.Enabled = usuario.PerfilUsuario.PuedeControlarUsuarios;
        }

        string usuario;
        string servidor;
        private void formMenu_Load(object sender, EventArgs e)
        {
            Login();
            usuario = formLogin.usuario;
            servidor = formLogin.servidor;
            tssUsuario.Text = "Usuario: " + usuario;
            tssServidor.Text = "Servidor: " + servidor;
        }

        private FormFactura formFactura;
        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formFactura == null)
            {
                formFactura = new FormFactura();
                formFactura.MdiParent = this;
                formFactura.Show();
            }
            else if (formFactura.IsDisposed)
            {
                formFactura = new FormFactura();
                formFactura.MdiParent = this;
                formFactura.Show();
            }
            else
                formFactura.Activate();
        }

        private FormReporteVehiculos FormReporteVehiculos;
        private void vehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormReporteVehiculos == null)
            {
                FormReporteVehiculos = new FormReporteVehiculos();
                FormReporteVehiculos.MdiParent = this;
                FormReporteVehiculos.Show();
            }
            else if (FormReporteVehiculos.IsDisposed)
            {
                FormReporteVehiculos = new FormReporteVehiculos();
                FormReporteVehiculos.MdiParent = this;
                FormReporteVehiculos.Show();
            }
            else
                FormReporteVehiculos.Activate();
        }

        private FormReporteClientes FormReporteClientes;
        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FormReporteClientes == null)
            {
                FormReporteClientes = new FormReporteClientes();
                FormReporteClientes.MdiParent = this;
                FormReporteClientes.Show();
            }
            else if (FormReporteClientes.IsDisposed)
            {
                FormReporteClientes = new FormReporteClientes();
                FormReporteClientes.MdiParent = this;
                FormReporteClientes.Show();
            }
            else
                FormReporteClientes.Activate();
        }

        private FormReporteFacturas FormReporteFacturas;
        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormReporteFacturas == null)
            {
                FormReporteFacturas = new FormReporteFacturas();
                FormReporteFacturas.MdiParent = this;
                FormReporteFacturas.Show();
            }
            else if (FormReporteFacturas.IsDisposed)
            {
                FormReporteFacturas = new FormReporteFacturas();
                FormReporteFacturas.MdiParent = this;
                FormReporteFacturas.Show();
            }
            else
                FormReporteFacturas.Activate();
        }

        private void loginToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login();
            usuario = formLogin.usuario;
            servidor = formLogin.servidor;
            tssUsuario.Text = "Usuario: " + usuario;
            tssServidor.Text = "Servidor: " + servidor;
        }

        private FormUsuarios FormUsuarios;
        private void controlDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormUsuarios == null)
            {
                FormUsuarios = new FormUsuarios();
                FormUsuarios.MdiParent = this;
                FormUsuarios.Show();
            }
            else if (FormUsuarios.IsDisposed)
            {
                FormUsuarios = new FormUsuarios();
                FormUsuarios.MdiParent = this;
                FormUsuarios.Show();
            }
            else
                FormUsuarios.Activate();
        }

        private formVehiculos formVehiculos;
        private void vehículosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formVehiculos == null)
            {
                formVehiculos = new formVehiculos();
                formVehiculos.MdiParent = this;
                formVehiculos.Show();
            }
            else if (formVehiculos.IsDisposed)
            {
                formVehiculos = new formVehiculos();
                formVehiculos.MdiParent = this;
                formVehiculos.Show();
            }
            else
                formVehiculos.Activate();
        }

        private formClientes formClientes;
        private void clientesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (formClientes == null)
            {
                formClientes = new formClientes();
                formClientes.MdiParent = this;
                formClientes.Show();
            }
            else if (formClientes.IsDisposed)
            {
                formClientes = new formClientes();
                formClientes.MdiParent = this;
                formClientes.Show();
            }
            else
                formClientes.Activate();
        }
    }
}
