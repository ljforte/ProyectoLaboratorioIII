﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Stock
    {
        public int id { get; set; }
        public int id_producto { get; set; }
        public Sitio sitio { get; set; }
        public int stock { get; set; }

    }
}
