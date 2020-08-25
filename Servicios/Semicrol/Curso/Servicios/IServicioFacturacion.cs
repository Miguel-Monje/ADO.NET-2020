using Semicrol.Curso.Dominio;
using Semicrol.Curso.Filtros;
using Semicrol.Curso.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.Servicios
{
    interface IServicioFacturacion 
    {
        void InsertarFactura(Factura factura);
        void BorrarFactura(Factura factura);
        void ActualizarFactura(Factura factura);
        List<Factura> BuscarTodasLasFacturas();
        List<Factura> BuscarFacturasFiltradas(FiltroFactura filtro);
        Factura BuscarFactura(int numero);
        List<Factura> BuscarTodosConLineas();

        void InsertarLineaFactura(LineaFactura lineaFactura);
        void BorrarLineaFactura(LineaFactura lineaFactura);
        void ActualizarLineaFactura(LineaFactura lineaFactura);
        List<LineaFactura> BuscarTodasLasLineas();
        List<LineaFactura> BuscarTodasLasLineasFiltradas(FiltroLineaFactura filtro);
        LineaFactura BuscarLineaFactura(int numero, int numeroFactura);
    }
}
