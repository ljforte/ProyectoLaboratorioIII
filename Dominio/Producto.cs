using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public  int Id{ get; set; }
        [DisplayName("Articulo")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marcas MarcasCls;
        public Categorias CategoriasCls;
        public decimal Precio { get; set; }
        public ArtImg Imagen;
        public int IdProveedor { get; set; }
        public bool Estado {  get; set; }
    }   
}
