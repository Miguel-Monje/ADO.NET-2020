


using Semicrol.Curso.Dominio;
using Semicrol.Curso.PersistenciaADO;
using System;
using System.Collections.Generic;

namespace ADO.NET.FacturacionRepository
{
    class Program01
    {

        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            List<Factura> lista = repositorio.BuscarTodosConLineas();

            foreach(Factura f in lista)
            {
                Console.WriteLine("Factura Numero: " + f.Numero + " Concepto: " + f.Concepto);
                Console.WriteLine("************");
                
                foreach(LineaFactura lf in f.LineasFactura)
                {
                    Console.WriteLine("Numero: " + lf.Numero + " con unidades: " + lf.Unidades + " de producto: " + lf.ProductoId);
                }

                Console.WriteLine("************");
                Console.WriteLine("");
            }

            Console.ReadLine();

        }
    }
}
