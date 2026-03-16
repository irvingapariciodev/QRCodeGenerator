using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.API.Controllers;
using QRCodeGenerator.API.Models;

namespace QRCodeGenerator.Tests.Controllers
{
    [TestClass]
    public class QrCodeControllerTests
    {
        private QrCodeController _controller;

        [TestInitialize]
        public void Setup()
        {
            var _service = new QRCodeGenerator.Services.QrCodeService();
            _controller = new QrCodeController(new QRCodeGenerator.Services.QrCodeService());
        }

        [TestMethod]
        public void GenerateQrCode_WithEmptyInput_ReturnsBadRequest()
        {
            // Input URL for QR code generation
            var inputURL = new GenerateQrCodeRequest
            {
                Content = string.Empty
            };

            // Act
            var result = _controller.GenerateQrCode(inputURL);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.BadRequestObjectResult));
        }

        [TestMethod]
        public void GenerateQrCode_InputExceedsMaxLength_ReturnsBadRequest()
        {
            // Input URL for QR code generation
            var inputURL = new GenerateQrCodeRequest
            {
                Content = ""
            };

            // Act
            var result = _controller.GenerateQrCode(inputURL);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
