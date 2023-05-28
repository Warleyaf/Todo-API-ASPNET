using Microsoft.AspNetCore.Mvc;

namespace Todo_API_ASPNET.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public string Get() {
            return "Ola meu chapa";
        }
    }
}
