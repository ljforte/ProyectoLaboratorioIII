using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vendedor
    {
        public int IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Comision { get; set; }
        public int Estado { get; set; }
    }
}
