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

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var libro = (from l in _bibliotecaContexto.Libro
                         join a in _bibliotecaContexto.Autor
                         on l.AutorId equals a.Id
                         where l.Id == id
                         select new
                         {
                             l.Titulo,
                             a.Nombre
                         }).FirstOrDefault();

            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarLibro([FromBody] Libro libro)
        {
            try
            {
                _bibliotecaContexto.Libro.Add(libro);
                _bibliotecaContexto.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
