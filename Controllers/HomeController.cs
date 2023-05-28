using Microsoft.AspNetCore.Mvc;
using Todo_API_ASPNET.Data;
using Todo_API_ASPNET.Models;

namespace Todo_API_ASPNET.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public List<TodoModel> Get([FromServices] AppDbContext context) {
            return context.Todos.ToList();
        }
    }
}
