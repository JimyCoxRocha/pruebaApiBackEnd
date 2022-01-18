using System;
using System.Collections.Generic;

#nullable disable

namespace storeAPI.Models
{
    public partial class Usuario
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
