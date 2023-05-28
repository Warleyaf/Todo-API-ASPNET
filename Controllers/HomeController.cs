using Microsoft.AspNetCore.Mvc;
using Todo_API_ASPNET.Data;
using Todo_API_ASPNET.Models;

namespace Todo_API_ASPNET.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            return Ok(context.Todos.ToList());
        }

        [HttpPost("/")]
        public IActionResult Post(
                [FromBody] TodoModel todo,
                [FromServices] AppDbContext context)
        {

            context.Todos.Add(todo);
            context.SaveChanges();
            return Created($"/{todo.Id}", todo);
        }
        // Buscando por uma id
        [HttpGet("/{id:int}")]
        public IActionResult GetById(
                [FromRoute] int id,
                [FromServices] AppDbContext context)
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todos == null)
                return NotFound();
            return Ok(todos);
        }

        // Atualizando o registro
        [HttpPut("/{id:int}")]
        public IActionResult Put(
                [FromRoute] int id,
                [FromBody] TodoModel todo,
                [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return Ok(model);

        }

        // Deletando o registro
        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
                [FromRoute] int id,
                [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();
            context.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}
