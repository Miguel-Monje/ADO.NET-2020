using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.Filtros
{
    public class FiltroLineaFactura
    {
        private int _numero;
        private int _facturaNumero;
        private string _productoId;
        private int _unidades;


        public int Numero
        {
            get
            {
                return _numero;
            }
        }

        public int FacturaNumero
        {
            get
            {
                return _facturaNumero;
            }
        }
        public string ProductoId
        {
            get
            {
                return _productoId;
            }
        }

        public int Unidades
        {
            get
            {
                return _unidades;
            }
        }


        public FiltroLineaFactura AddNumero(int numero)
        {
            _numero = numero;
            return this;
        }
        public FiltroLineaFactura AddFacturaNumero(int facturaNumero)
        {
            _facturaNumero = facturaNumero;
            return this;
        }

        public FiltroLineaFactura AddProductoId(string productoId)
        {
            _productoId = productoId;
            return this;
        }
        public FiltroLineaFactura AddUnidades(int unidades)
        {
            _unidades = unidades;
            return this;
        }

        public FiltroLineaFactura Clear()
        {
            _numero = 0;
            _facturaNumero = 0;
            _productoId = null;
            _unidades = 0;
            return this;
        }
    }
}
