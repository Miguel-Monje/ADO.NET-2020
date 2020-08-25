using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.Dominio
{
     public class Factura
    {
       

        public int Numero { get; set; }
        public string Concepto { get; set; }
        public List<LineaFactura> LineasFactura { get; set; }

        public Factura(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
            LineasFactura = new List<LineaFactura>();
        }
        public Factura(int numero)
        {
            Numero = numero;
        }

        public void AddLineaFactura(LineaFactura lf)
        {
            LineasFactura.Add(lf);
        }
        public void BorraLineaFactura(LineaFactura lf)
        {
            LineasFactura.Remove(lf);
        }





        public override bool Equals(object obj)
        {
            var factura = obj as Factura;
            return factura != null &&
                   Numero == factura.Numero;
        }

        public override int GetHashCode()
        {
            return -1449941195 + Numero.GetHashCode();
        }
    }
}
