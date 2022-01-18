using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using storeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class storeApiRest : ControllerBase
    {
        readonly private storeapiContext Context;
        public storeApiRest(storeapiContext _context)
        {
            Context = _context;
        }

        [HttpPost("usuarios")]
        public ActionResult<Usuario> Post([FromBody] Usuario user)
        {
            var result = Context.Usuarios
                .Where(x => x.Email == user.Email && x.Password == user.Password)
                .Select(x => new { x.Password, x.Email}).ToList();

            if (result.Count == 0)
                return StatusCode(400, ResponseEntity<String>.error("ERROR"));

                return StatusCode(200, ResponseEntity<String>.resp("BIEN", ""));
        }

        [HttpGet("products")]
        public ActionResult<Producto> Get()
        {
            var result = Context.Productos.ToList();

            if (result.Count == 0)
                return StatusCode(404, ResponseEntity<String>.error("ERROR"));

            return StatusCode(200, ResponseEntity<List<Producto>>.resp("BIEN", result));
        }
    }
}
