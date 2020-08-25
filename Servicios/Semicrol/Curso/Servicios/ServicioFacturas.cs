using Semicrol.Curso.Dominio;
using Semicrol.Curso.Filtros;
using Semicrol.Curso.Interfaces;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.Servicios
{
    [Transaction]
    public class ServicioFacturas : IServicioFacturacion
    {
        private IFacturaRepository repoFacturas;
        private ILineaFacturaRepository repoLineas;
       

        public ServicioFacturas(IFacturaRepository repoFacturas, ILineaFacturaRepository repoLineas)
        {
            this.repoFacturas = repoFacturas;
            this.repoLineas = repoLineas;
        }

        public void InsertarFactura(Factura factura)
        {
            repoFacturas.Insertar(factura);
            foreach(LineaFactura lf in factura.LineasFactura)
            {
                repoLineas.Insertar(lf);
            }
        }
        public void BorrarFactura(Factura factura)
        {
            foreach (LineaFactura lf in factura.LineasFactura)
            {
                repoLineas.Borrar(lf);
            }
            repoFacturas.Borrar(factura);
        }
        public void ActualizarFactura(Factura factura)
        {
            repoFacturas.Actualizar(factura);
        }
        public List<Factura> BuscarTodasLasFacturas()
        {
            return repoFacturas.BuscarTodos(new FiltroFactura());
        }

        public List<Factura> BuscarFacturasFiltradas(FiltroFactura filtro)
        {
            return repoFacturas.BuscarTodos(filtro);
        }

        public Factura BuscarFactura(int numero)
        {
            return repoFacturas.BuscarUno(numero);
        }

        public List<Factura> BuscarTodosConLineas()
        {
            return repoFacturas.BuscarTodosConLineas();
        }

        public void InsertarLineaFactura(LineaFactura lineaFactura)
        {
            Factura f = repoFacturas.BuscarUno(lineaFactura.Factura.Numero);
            if(f== null)
            {
                throw new Exception("No se ha encontrado la factura");
            }
            if (f.LineasFactura.Contains(lineaFactura))
            {
                throw new Exception("La linea de factura ya esta asignada");
            }
            f.AddLineaFactura(lineaFactura);

        }

        public void BorrarLineaFactura(LineaFactura lineaFactura)
        {
            Factura f = repoFacturas.BuscarUno(lineaFactura.Factura.Numero);
            f.BorraLineaFactura(lineaFactura);
            repoLineas.Borrar(lineaFactura);
        }

        public void ActualizarLineaFactura(LineaFactura lineaFactura)
        {
            repoLineas.Actualizar(lineaFactura);
        }

        public List<LineaFactura> BuscarTodasLasLineas()
        {
            return repoLineas.BuscarTodos();
        }

        public List<LineaFactura> BuscarTodasLasLineasFiltradas(FiltroLineaFactura filtro)
        {
            return repoLineas.BuscarTodos(filtro);
        }

        public LineaFactura BuscarLineaFactura(int numero, int numeroFactura)
        {
            return repoLineas.BuscarUno(numero, numeroFactura);
        }
    }
}
