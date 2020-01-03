using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class CombustibleBL
    {
        Contexto _contexto;

        public BindingList<Combustible> ListaCombustibles { get; set; }

        public CombustibleBL()
        {
            _contexto = new Contexto();
            ListaCombustibles = new BindingList<Combustible>();
        }

        public BindingList<Combustible> ObtenerCombustibles()
        {
            _contexto.Combustibles.Load();
            ListaCombustibles = _contexto.Combustibles.Local.ToBindingList();

            return ListaCombustibles;
        }
    }

    public class Combustible
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
