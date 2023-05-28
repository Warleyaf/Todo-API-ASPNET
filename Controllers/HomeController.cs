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
    }
}
