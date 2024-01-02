using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAPIController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello API";
        }
    }
}
