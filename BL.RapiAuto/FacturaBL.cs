using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class FacturaBL
    {
        Contexto _contexto;

        public BindingList<Factura> ListaFacturas { get; set; }

        public FacturaBL()
        {
            _contexto = new Contexto();      
        }

        public BindingList<Factura> ObtenerFacturas()
        {
            _contexto.Facturas.Include("FacturaDetalle").Load();
            ListaFacturas = _contexto.Facturas.Local.ToBindingList();

            return ListaFacturas;

        }

        public BindingList<Factura> ObtenerFacturas(string numero)
        {
            _contexto.Facturas.Include("FacturaDetalle")
                .Where(factura => factura.Id.ToString().Contains(numero)).ToList();
            ListaFacturas = _contexto.Facturas.Local.ToBindingList();

            return ListaFacturas;

        }

        public void AgregarFactura()
        {
            var nuevaFactura = new Factura();
            _contexto.Facturas.Add(nuevaFactura);  
        }

        public void AgregarFacturaDetalle(Factura factura)
        {
            if(factura!= null)
            {
                var nuevoDetalle = new FacturaDetalle();
                factura.FacturaDetalle.Add(nuevoDetalle);
            }
        }

        public void RemoverFacturaDetalle(Factura factura, FacturaDetalle facturaDetalle )
        {
            if (factura != null && facturaDetalle != null)
            {
                factura.FacturaDetalle.Remove(facturaDetalle);
            }
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }


        public Resultado GuardarFactura(Factura factura)
        {
            var resultado = Validar(factura);
            if (resultado.Exitoso == false)
            {
                return resultado;     
            }

            CalcularFacturaExistencia(factura);

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }

        private void CalcularFacturaExistencia(Factura factura)
        {
            foreach (var detalle in factura.FacturaDetalle)
            {
                var vehiculo = _contexto.Vehiculos.Find(detalle.VehiculoId);
                if (vehiculo != null)
                {
                    if (factura.Activo == true)
                    {
                        vehiculo.Existencia = vehiculo.Existencia - detalle.Cantidad;
                    }
                    else
                    {
                        vehiculo.Existencia = vehiculo.Existencia + detalle.Cantidad;
                    }
                }
            }
        }

        private Resultado Validar(Factura factura)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (factura == null)
            {
                resultado.Mensaje = "Agregue una factura para poderla salvar";
                resultado.Exitoso = false;

                return resultado;
            }

            if (factura.Id != 0 && factura.Activo == true)
            {
                resultado.Mensaje = "La factura ya fue emitida y no se pueden realizar cambios";
                resultado.Exitoso = false;
            }

            if (factura.Activo == false)
            {
                resultado.Mensaje = "La factura esta anulada y no se pueden realizar cambios en ella";
                resultado.Exitoso = false;
            }

            if (factura.ClienteId == 0)
            {
                resultado.Mensaje = "Seleecione un cliente";
                resultado.Exitoso = false;
            }

            if (factura.FacturaDetalle.Count == 0)
            {
                resultado.Mensaje = "Agregue producto a la factura";
                resultado.Exitoso = false;
            }

            foreach (var detalle in factura .FacturaDetalle )
            {
                if (detalle.VehiculoId == 0)
                {
                    resultado.Mensaje = "Seleccione vehiculos validos";
                    resultado.Exitoso = false;
                }
            }

            return resultado;
        }

        public void CalcularFactura(Factura factura)
        {
            if (factura !=null)
            {
                double subtotal = 0;
                foreach (var detalle in factura.FacturaDetalle )
                {
                    var vehiculo = _contexto.Vehiculos.Find(detalle.VehiculoId);
                    if (vehiculo != null)
                    {
                        detalle.Precio = vehiculo.Precio;
                        detalle.Total = detalle.Cantidad * vehiculo.Precio;

                        subtotal += detalle.Total;
                    }
                }
                factura.Subtotal = subtotal;
                factura.Impuesto = subtotal * 0.15;
                factura.Total = subtotal + factura.Impuesto;
            }
        }

        public bool AnularFactura(int id)
        {
            foreach (var factura in ListaFacturas )
            {
                if (factura.Id == id)
                {
                    factura.Activo = false;
                    CalcularFacturaExistencia(factura);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }

    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
        public BindingList<FacturaDetalle> FacturaDetalle { get; set; }
        public double Subtotal { get; set; }
        public double  Impuesto { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public Factura()
        {
            Fecha = DateTime.Now;
            FacturaDetalle = new BindingList<FacturaDetalle>();
            Activo = true;
        }
        
    }

    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

        public FacturaDetalle()
        {
            Cantidad = 1;

        }
    }
}
