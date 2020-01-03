using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class TransmisionBL
    {
        Contexto _contexto;

        public BindingList<Transmision> ListaTransmisiones { get; set; }

        public TransmisionBL()
        {
            _contexto = new Contexto();
            ListaTransmisiones = new BindingList<Transmision>();
        }

        public BindingList<Transmision> ObtenerTransmisiones()
        {
            _contexto.Transmisiones.Load();
            ListaTransmisiones = _contexto.Transmisiones.Local.ToBindingList();

            return ListaTransmisiones;
        }
    }

    public class Transmision
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
