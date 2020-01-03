using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class VehiculosBL
    {
        Contexto _contexto;
        public BindingList<Vehiculo> ListaVehiculos { get; set; }

        public VehiculosBL()
        {
            _contexto = new Contexto();
            ListaVehiculos = new BindingList<Vehiculo>();

        }
        public BindingList<Vehiculo> ObtenerVehiculos()
        {
            _contexto.Vehiculos.Load();
            ListaVehiculos = _contexto.Vehiculos.Local.ToBindingList();
            return ListaVehiculos;
        }
        public BindingList<Vehiculo> ObtenerVehiculos(string descripcionModelo)
        {
            _contexto.Vehiculos.Where(vehiculo => vehiculo.Modelo.Contains(descripcionModelo) == true).ToList();
            ListaVehiculos = _contexto.Vehiculos.Local.ToBindingList();

            return ListaVehiculos;
        }
        public Resultado GuardarVehiculo(Vehiculo vehiculo)
        {
            var resultado = Validar(vehiculo);
            if (resultado.Exitoso==false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }
        public void AgregarVehiculo()
        {
            var nuevoVehiculo = new Vehiculo();
            nuevoVehiculo.TransmisionId = 1;
            nuevoVehiculo.TipoId = 1;
            nuevoVehiculo.CombustibleId = 1;
            ListaVehiculos.Add(nuevoVehiculo);
        }
        public bool EliminarVehiculo(int id)
        {
            foreach (var vehiculo in ListaVehiculos)
            {
                if (vehiculo.Id == id)
                {
                    ListaVehiculos.Remove(vehiculo);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        private Resultado Validar(Vehiculo vehiculo)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (vehiculo == null)
            {
                resultado.Mensaje = "Agregue un vehiculo valido";
                resultado.Exitoso = false;

                return resultado ;
            }

            if (string.IsNullOrEmpty(vehiculo.Marca) == true)
            {
                resultado.Mensaje = "Ingrese una marca";
                resultado.Exitoso = false;
            }
            if (string.IsNullOrEmpty(vehiculo.Modelo) == true)
            {
                resultado.Mensaje = "Ingrese un modelo";
                resultado.Exitoso = false;
            }
            if (string.IsNullOrEmpty(vehiculo.Color) == true)
            {
                resultado.Mensaje = "Ingrese un modelo";
                resultado.Exitoso = false;
            }
            if (vehiculo.Año < 0)
            {
                resultado.Mensaje = "Ingrese un año";
                resultado.Exitoso = false;
            }

            if (vehiculo.Kilometraje < 0)
            {
                resultado.Mensaje = "El kilometraje debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            if (vehiculo.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (string.IsNullOrEmpty(vehiculo.Cilindraje) == true)
            {
                resultado.Mensaje = "Ingrese un Cilindraje";
                resultado.Exitoso = false;
            }
            if (vehiculo.CombustibleId == 0)
            {
                resultado.Mensaje = "Ingrese un tipo de combustible";
                resultado.Exitoso = false;
            }
            if (vehiculo.TipoId == 0)
            {
                resultado.Mensaje = "Ingrese un Tipo";
                resultado.Exitoso = false;
            }
            if (vehiculo.TransmisionId == 0)
            {
                resultado.Mensaje = "Ingrese un tipo de transmision";
                resultado.Exitoso = false;
            }

            return resultado;
        }
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }
        public void RefrescarDatos(int vehiculoId)
        {
            var vehiculo = _contexto.Vehiculos.Find(vehiculoId);

            if (vehiculo != null)
            {
                _contexto.Entry(vehiculo).Reload();
            }
        }
    }

    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Año { get; set; }
        public double Precio { get; set; }
        public int Kilometraje { get; set; }
        public string Cilindraje { get; set; }
        public byte[] Foto { get; set; }
        public bool Activo { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public int CombustibleId { get; set; }
        public Combustible Combustible { get; set; }
        public int TransmisionId { get; set; }
        public Transmision Transmision { get; set; }
        public int Existencia { get; set; }

    }
}
