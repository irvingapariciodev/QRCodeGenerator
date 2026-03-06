using Microsoft.AspNetCore.Mvc;

namespace QRCodeGenerator.Api.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QrCodesController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
