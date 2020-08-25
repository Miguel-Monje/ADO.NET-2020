using System;
using System.Collections.Generic;
using System.Text;

namespace Semicrol.Curso.Dominio
{
    public class Producto
    {


        public string Id { get; set; }
        public string Nombre { get; set; }
        public double Importe { get; set; }
        public string Categoria { get; set; }

        public Producto(string id, string nombre, double importe, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Importe = importe;
            Categoria = categoria;
        }

        public Producto(string id){
            Id = id;
        }
    }
}
