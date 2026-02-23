using Microsoft.AspNetCore.Mvc;

namespace QRCodeGenerator.Api.API.Controllers
{
    public class QrCodesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
