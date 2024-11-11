using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleFactura
    {
        public int IdCompra { get; set; }
        public int IdFactura { get; set; }
        public int Sku { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
    }
}
