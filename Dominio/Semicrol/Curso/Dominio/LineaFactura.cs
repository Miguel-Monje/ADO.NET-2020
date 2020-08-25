using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.Dominio
{
     public class LineaFactura
    {
        

        public int Numero { get; set; }
        public Factura Factura { get; set; }
        public string ProductoId { get; set; }
        public int Unidades { get; set; }

        public LineaFactura(int numero, Factura factura, string productoId, int unidades)
        {
            Numero = numero;
            Factura = factura;
            ProductoId = productoId;
            Unidades = unidades;
        }

        public LineaFactura(int numero, Factura factura)
        {
            Numero = numero;
            Factura = factura;
        }

        public override bool Equals(object obj)
        {
            var factura = obj as LineaFactura;
            return factura != null &&
                   Numero == factura.Numero &&
                   EqualityComparer<Factura>.Default.Equals(Factura, factura.Factura);
        }

        public override int GetHashCode()
        {
            var hashCode = 1881808180;
            hashCode = hashCode * -1521134295 + Numero.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Factura>.Default.GetHashCode(Factura);
            return hashCode;
        }
    }
}
