using Semicrol.Curso.Dominio;
using Semicrol.Curso.Filtros;
using System.Collections.Generic;

namespace Semicrol.Curso.Interfaces
{
    public interface ILineaFacturaRepository
    {
        void Insertar(LineaFactura factura);
        void Borrar(LineaFactura factura);
        void Actualizar(LineaFactura factura);

        List<LineaFactura> BuscarTodos();
        List<LineaFactura> BuscarTodos(FiltroLineaFactura filtro);
        LineaFactura BuscarUno(int numero, int numeroFactura);
    }
}
