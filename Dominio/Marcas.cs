using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marcas
    {
        
        public int Id { get; set; }
       [DisplayName("Marcas")]
        public String Descripcion { get; set; }

        public override string ToString()
        {
            return " "+ Descripcion;
        }
    }
}
