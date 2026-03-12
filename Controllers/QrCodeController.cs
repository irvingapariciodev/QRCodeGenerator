using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Services;

namespace QRCodeGenerator.API.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class QrCodeController : ControllerBase
    {
        private readonly QrCodeService _qrCodeService;
        const int maxURLLenght = 200;

        public QrCodeController(QrCodeService qrCodeService) => _qrCodeService = qrCodeService;

        [HttpPost]
        [Produces("image/png")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status400BadRequest)]
        public IActionResult GenerateQrCode([FromBody] string content)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content)){
                return BadRequest("URL cannot be empty.");
            }

            if (content.Length > maxURLLenght)
            {
                return BadRequest($"URL cannot be greather than {maxURLLenght} characters.");
            }

            if(!_qrCodeService.IsValidUTF8(content))
            {
                return BadRequest("URL must be a valid UTF-8 string.");
            }

            var qrCodeImage = _qrCodeService.GenerateQrCode(content.Trim());
            return File(qrCodeImage, "image/png", "QRCode.png");
        }
    }
}
