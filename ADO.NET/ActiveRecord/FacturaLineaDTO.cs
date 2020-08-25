using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ActiveRecord
{
    class FacturaLineaDTO
    {
        
        public int NumeroFactura { get; set; }
        public string ConceptoFactura { get; set; }
        public string ProductoId { get; set; }
        public int Unidades { get; set; }

        public FacturaLineaDTO(int numeroFactura, string conceptoFactura, string productoId, int unidades)
        {
            NumeroFactura = numeroFactura;
            ConceptoFactura = conceptoFactura;
            ProductoId = productoId;
            Unidades = unidades;
        }
    }
}
