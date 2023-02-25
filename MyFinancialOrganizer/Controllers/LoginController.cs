using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyFinancialOrganizer.Application.AuthenticationService;

namespace MyFinancialOrganizer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authenticate()
        {
            var token = TokenService.GenerateToken("Sudo su", _configuration.GetValue<string>("Secret"));

            return Ok(token);
        }
    }
}
