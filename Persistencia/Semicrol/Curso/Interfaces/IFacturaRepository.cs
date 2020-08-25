using Semicrol.Curso.Dominio;
using Semicrol.Curso.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.Interfaces
{
    public interface IFacturaRepository
    {
        void Insertar(Factura factura);
        void Borrar(Factura factura);
        void Actualizar(Factura factura);

        List<Factura> BuscarTodos();
        List<Factura> BuscarTodosConLineas();
        List<Factura> BuscarTodos(FiltroFactura filtro);
        Factura BuscarUno(int numero);
    }
}
