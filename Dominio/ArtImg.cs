using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArtImg
    {
        [DisplayName("ArticuloImagen")]
        public int Id { get; set; }
        public string IdArticulo { get; set; }
        public string ImagenUrl { get; set; }
        public string Desc { get; set; }
        public override string ToString()
        {
            return ImagenUrl;
        }
    }

}
