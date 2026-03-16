using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.API.Models;
using QRCodeGenerator.Services;

namespace QRCodeGenerator.API.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class QrCodeController : ControllerBase
    {
        private readonly QrCodeService _qrCodeService;
        const int maxURLLenght = 200;

        public QrCodeController(QrCodeService qrCodeService) => _qrCodeService = qrCodeService;

        [HttpPost("Generate")]
        [Produces("image/png")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status400BadRequest)]
        public IActionResult GenerateQrCode([FromBody] GenerateQrCodeRequest content)
        {
            try
            {
                if (string.IsNullOrEmpty(content.Content) || string.IsNullOrWhiteSpace(content.Content))
                {
                    return BadRequest("URL cannot be empty.");
                }

                if (content.Content.Length > maxURLLenght)
                {
                    return BadRequest($"URL cannot be greather than {maxURLLenght} characters.");
                }

                if (!_qrCodeService.IsValidUTF8(content.Content))
                {
                    return BadRequest("URL must be a valid UTF-8 string.");
                }

                var qrCodeImage = _qrCodeService.GenerateQrCode(content.Content.Trim());

                if (qrCodeImage == null || qrCodeImage.Length == 0)
                {
                    return BadRequest("Failed to generate QR code.");
                }

                return File(qrCodeImage, "image/png", "QRCode.png");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
            $"Internal server error: {ex.Message}");
            }
        }
    }
}
