using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor
    {
        public int id_proveedor { get; set; }

        [DisplayName("Nombre del Proveedor")]
        public string nombre { get; set; }

        [DisplayName("Dirección ID")]
        public int direccionID { get; set; }
        public int CantidadArticulos { get; set; }

        public override string ToString()
        {
            return $"{nombre} (ID: {id_proveedor})";
        }
    }
}
