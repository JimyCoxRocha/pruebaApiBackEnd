using System;
using System.Collections.Generic;

#nullable disable

namespace storeAPI.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }
    }
}
