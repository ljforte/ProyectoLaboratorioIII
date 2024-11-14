using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categorias
    {
        
        public int Id { get; set; }
        [DisplayName("Categoria")]
        public string nombre { get; set; }

        public override string ToString()
        {
            return nombre;
        }

    }
}
