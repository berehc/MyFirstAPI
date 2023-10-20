using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using MyFirstAPI.Services;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_categoriaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            _categoriaService.Save(categoria);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Categoria categoria)
        {
            _categoriaService.Update(id,categoria);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            _categoriaService.Delete(id);
            return Ok();
        }
    }
}
