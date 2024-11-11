using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdImpuesto { get; set; }
        public int IdCliente { get; set; }
        public int Monto { get; set; }
        public int IdVendedor { get; set; }
        public DateTime Date { get; set; }
    }
}
