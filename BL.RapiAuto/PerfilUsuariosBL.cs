using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;

namespace BL.RapiAuto
{
    public class PerfilUsuariosBL
    {
        Contexto _contexto;
        public BindingList<PerfilUsuario> ListaPerfiles { get; set; }

        public PerfilUsuariosBL()
        {
            _contexto = new Contexto();
            ListaPerfiles = new BindingList<PerfilUsuario>();
        }

        public BindingList<PerfilUsuario> ObtenerPerfiles()
        {
            _contexto.PerfilesUsuarios.Load();
            ListaPerfiles = _contexto.PerfilesUsuarios.Local.ToBindingList();

            return ListaPerfiles;
        }
 
    }

    public class PerfilUsuario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public bool PuedeVerVehiculos { get; set; }
        public bool PuedeVerClientes { get; set; }
        public bool PuedeVerFacturas { get; set; }
        public bool PuedeVerReportes { get; set; }
        public bool PuedeControlarUsuarios{ get; set; }
    }
}
