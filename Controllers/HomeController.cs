using Microsoft.AspNetCore.Mvc;
using Todo_API_ASPNET.Data;
using Todo_API_ASPNET.Models;

namespace Todo_API_ASPNET.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public List<TodoModel> Get([FromServices] AppDbContext context)
        {
            return context.Todos.ToList();
        }

        [HttpPost("/")]
        public TodoModel Post(
                [FromBody] TodoModel todo,
                [FromServices] AppDbContext context)
        {

            context.Todos.Add(todo);
            context.SaveChanges();
            return todo;
        }
        // Buscando por uma id
        [HttpGet("/{id:int}")]
        public TodoModel GetById(
                [FromRoute] int id,
                [FromServices] AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }

        // Atualizando o registro
        [HttpPut("/{id:int}")]
        public TodoModel Put(
                [FromRoute] int id,
                [FromBody] TodoModel todo,
                [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return todo;

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return model;

        }

        // Deletando o registro
        [HttpDelete("/{id:int}")]
        public TodoModel Delete(
                [FromRoute] int id,
                [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            context.Remove(model);
            context.SaveChanges();
            return model;
        }
    }
}
