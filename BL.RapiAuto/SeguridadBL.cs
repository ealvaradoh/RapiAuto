using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class SeguridadBL
    {
        Contexto _contexto;
        public BindingList<Usuario> ListaUsuarios { get; set; }

        public SeguridadBL()
        {
            _contexto = new Contexto();
            ListaUsuarios = new BindingList<Usuario>();
        }

        public BindingList<Usuario> ObtenerUsuarios()
        {
            _contexto.Usuarios.Load();
            ListaUsuarios = _contexto.Usuarios.Local.ToBindingList();
            return ListaUsuarios;
        }

        public void AgregarUsuario()
        {
            var NuevoUsuario = new Usuario();
            ListaUsuarios.Add(NuevoUsuario);
        }

        public Resultado GuardarUsuario(Usuario usuario)
        {
            var resultado = validar(usuario);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }


        public bool EliminarUsuario(int id)
        {
            foreach(var usuario in ListaUsuarios)
            {
                if(usuario.Id== id)
                {
                    ListaUsuarios.Remove(usuario);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Resultado validar(Usuario usuario)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (usuario == null)
            {
                resultado.Mensaje = "Agregue un usurio valido";
                resultado.Exitoso = false;

                return resultado;
            }
            if (string.IsNullOrEmpty(usuario.Nombre) == true)
            {
                resultado.Mensaje = "Debe ingresar un nombre de usuario";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(usuario.PerfilUsuarioId.ToString()) == true)
            {
                resultado.Mensaje = "Debe ingresar un perfil de usuario";
                resultado.Exitoso = false;
            }
            return resultado;
        }

        public Resultado Autorizar(string usuario, string contrasena)
        {
            var resultado = new Resultado();
            var usuarios = _contexto.Usuarios.ToList();
            var perfil = _contexto.PerfilesUsuarios.ToList();

            foreach (var usuarioDB in usuarios)
            {
                if (usuario == usuarioDB.Nombre && contrasena == usuarioDB.Contrasena)
                {
                    if (usuarioDB.Activo == true)
                    {
                        resultado.Exitoso = true;
                        resultado.Usuario = usuarioDB;
                        return resultado;
                    }
                    else
                    {
                        resultado.Exitoso = false;
                        resultado.Mensaje = "Este usuario está inactivo";
                        return resultado;
                    }
                }
            }
            resultado.Mensaje = "Usuario o contraseña no existe";
            return resultado;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }

        public int PerfilUsuarioId { get; set; }
        public PerfilUsuario PerfilUsuario { get; set; }
    }
}
