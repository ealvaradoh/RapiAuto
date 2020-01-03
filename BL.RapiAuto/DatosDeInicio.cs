using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class DatosDeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            /*Usuarios*/
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";
            usuarioAdmin.Activo = true;
            usuarioAdmin.PerfilUsuarioId = 1;

            var usuarioOperador = new Usuario();
            usuarioOperador.Nombre = "operador";
            usuarioOperador.Contrasena = "123";
            usuarioOperador.Activo = false;
            usuarioOperador.PerfilUsuarioId = 3;
            
            contexto.Usuarios.Add(usuarioAdmin);
            contexto.Usuarios.Add(usuarioOperador);

            /*Perfiles de usuario*/
            var PerfilUsuario1 = new PerfilUsuario();
            PerfilUsuario1.Descripcion = "Control Total";
            PerfilUsuario1.PuedeVerVehiculos = true;
            PerfilUsuario1.PuedeVerClientes = true;
            PerfilUsuario1.PuedeVerFacturas = true;
            PerfilUsuario1.PuedeVerReportes = true;
            PerfilUsuario1.PuedeControlarUsuarios = true;

            var PerfilUsuario2 = new PerfilUsuario();
            PerfilUsuario2.Descripcion = "Facturación";
            PerfilUsuario2.PuedeVerVehiculos = false;
            PerfilUsuario2.PuedeVerClientes = false;
            PerfilUsuario2.PuedeVerFacturas = true;
            PerfilUsuario2.PuedeVerReportes = false;
            PerfilUsuario2.PuedeControlarUsuarios = false;

            var PerfilUsuario3 = new PerfilUsuario();
            PerfilUsuario3.Descripcion = "Reportes";
            PerfilUsuario3.PuedeVerVehiculos = false;
            PerfilUsuario3.PuedeVerClientes = false;
            PerfilUsuario3.PuedeVerFacturas = false;
            PerfilUsuario3.PuedeVerReportes = true;
            PerfilUsuario3.PuedeControlarUsuarios = false;


            var PerfilUsuario4 = new PerfilUsuario();
            PerfilUsuario4.Descripcion = "Catálogos";
            PerfilUsuario4.PuedeVerVehiculos = true;
            PerfilUsuario4.PuedeVerClientes = true;
            PerfilUsuario4.PuedeVerFacturas = false;
            PerfilUsuario4.PuedeVerReportes = false;
            PerfilUsuario4.PuedeControlarUsuarios = false;

            contexto.PerfilesUsuarios.Add(PerfilUsuario1);
            contexto.PerfilesUsuarios.Add(PerfilUsuario2);
            contexto.PerfilesUsuarios.Add(PerfilUsuario3);
            contexto.PerfilesUsuarios.Add(PerfilUsuario4);

            /*Tipo de Auto*/
            var tipo1 = new Tipo();
            tipo1.Descripcion = "Sedan";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Pick Up";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Camioneta";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Descripcion = "Van";
            contexto.Tipos.Add(tipo4);

            var tipo5 = new Tipo();
            tipo5.Descripcion = "Mini Van";
            contexto.Tipos.Add(tipo5);

            var tipo6 = new Tipo();
            tipo6.Descripcion = "Furgon";
            contexto.Tipos.Add(tipo6);

            var tipo7 = new Tipo();
            tipo7.Descripcion = "Camion";
            contexto.Tipos.Add(tipo7);

            var tipo8 = new Tipo();
            tipo8.Descripcion = "Panel";
            contexto.Tipos.Add(tipo8);

            var tipo9 = new Tipo();
            tipo9.Descripcion = "Autobus";
            contexto.Tipos.Add(tipo9);

            var tipo10 = new Tipo();
            tipo10.Descripcion = "Tractor";
            contexto.Tipos.Add(tipo10);

            var tipo11 = new Tipo();
            tipo11.Descripcion = "Otros";
            contexto.Tipos.Add(tipo11);

            /*Combustible*/
            var combustible1 = new Combustible();
            combustible1.Descripcion = "Diesel";
            contexto.Combustibles.Add(combustible1);

            var combustible2 = new Combustible();
            combustible2.Descripcion = "Gasolina";
            contexto.Combustibles.Add(combustible2);

            var combustible3 = new Combustible();
            combustible3.Descripcion = "Keroseno";
            contexto.Combustibles.Add(combustible3);

            /*Transmisión*/
            var transmision1 = new Transmision();
            transmision1.Descripcion = "Manual";
            contexto.Transmisiones.Add(transmision1);

            var transmision2 = new Transmision();
            transmision2.Descripcion = "Automatico";
            contexto.Transmisiones.Add(transmision2);

            var transmision3 = new Transmision();
            transmision3.Descripcion = "Triptonica";
            contexto.Transmisiones.Add(transmision3);

            base.Seed(contexto);
        }


    }
}
