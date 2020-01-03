using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }

        public Usuario Usuario { get; set; }
        public PerfilUsuario PerfilUsuario { get; set; }
    }
}
