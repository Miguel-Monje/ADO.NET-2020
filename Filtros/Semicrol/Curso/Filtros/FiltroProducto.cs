using System;
using System.Collections.Generic;
using System.Text;

namespace Semicrol.Curso.Filtros
{
     public class FiltroProducto
    {
        private string _id;
        private string _nombre;
        private double _importe;
        private string _categoria;

        public string Id
        {
            get
            {
                return _id;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
        }
        public double Importe
        {
            get
            {
                return _importe;
            }
        }

        public string Categoria
        {
            get
            {
                return _categoria;
            }
        }


        public FiltroProducto AddNumero(string id)
        {
            _id = id;
            return this;
        }
        public FiltroProducto AddFacturaNumero(string nombre)
        {
            _nombre = nombre;
            return this;
        }

        public FiltroProducto AddProductoId(double importe)
        {
            _importe = importe;
            return this;
        }
        public FiltroProducto AddUnidades(string categoria)
        {
            _categoria = categoria;
            return this;
        }

        public FiltroProducto Clear()
        {
            _id = null;
            _nombre = null;
            _importe = 0.0;
            _categoria = null;
            return this;
        }

    }
}
