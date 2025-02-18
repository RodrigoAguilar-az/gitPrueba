using gitPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gitPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly BibliotecaContext _autoresContexto;

        public AutorController(BibliotecaContext autoresContexto)
        {
            _autoresContexto = autoresContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Autor> listadoAutor = (from a in _autoresContexto.Autor
                                        select a).ToList();
            if (listadoAutor.Count() == 0)
            {
                return NotFound();

            }

            return Ok(listadoAutor);
        }

    }
}
