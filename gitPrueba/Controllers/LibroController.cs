using gitPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gitPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly BibliotecaContext _bibliotecaContexto;

        public LibroController(BibliotecaContext bibliotecaContexto)
        {
            _bibliotecaContexto = bibliotecaContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Libro> listaLibros = (from e in _bibliotecaContexto.Libro select e).ToList();

            if (listaLibros.Count == 0)
            {
                return NotFound();
            }
            return Ok(listaLibros);
        }
    }
}
