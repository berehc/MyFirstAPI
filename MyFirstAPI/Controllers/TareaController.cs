using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using MyFirstAPI.Services;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        ITareasService _tareasService;

        public TareaController(ITareasService tareasService)
        {
            _tareasService = tareasService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tareasService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            _tareasService.Save(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            _tareasService.Update(id, tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _tareasService.Delete(id);
            return Ok();
        }
    }


}
