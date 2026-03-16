using QRCodeGenerator.API.Models;
using QRCodeGenerator.Services;

namespace QRCodeGenerator.Tests.Application
{
    [TestClass]
    public class QrCodeServiceTest
    {
        private QrCodeService _qrCodeService;

        [TestInitialize]
        public void Setup()
        {
            _qrCodeService = new QrCodeService();
        }

        [TestMethod]
        public void GenerateQrCode_WithValidInput_ReturnsImage()
        {
            // Input URL for QR code generation
            // Input URL for QR code generation
            var inputURL = new GenerateQrCodeRequest
            {
                Content = "https://www.google.com"
            };

            // Generate the QR code
            var result = _qrCodeService.GenerateQrCode(inputURL.Content);

            // Assert that the result is not null and that the generation time is within acceptable limits (e.g., less than 1 second)
            Assert.IsNotNull(result);

            // Assert that the result is a byte array and has a length greater than 0 (indicating that an image was generated)
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GenerateQrCode_ResponseTimeIsAcceptable()
        {
            // Input URL for QR code generation
            var inputURL = new GenerateQrCodeRequest
            {
                Content = "https://www.google.com"
            };

            // Start a stopwatch to measure the time taken for QR code generation
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Generate the QR code
            var result = _qrCodeService.GenerateQrCode(inputURL.Content);

            // Stop the stopwatch after the QR code generation is complete
            stopwatch.Stop();

            // Assert that the result is not null and that the generation time is within acceptable limits (e.g., less than 1 second)
            Assert.IsNotNull(result);

            // Assert that the QR code generation time is less than 1 second (1000 milliseconds)
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000, "QR code generation took too long.");
        }

        [TestMethod]
        public void GenerateQrCode_WithWhitespaceInput_ReturnsNull()
        {
            // Input URL for QR code generation
            var inputURL = new GenerateQrCodeRequest
            {
                Content = string.Empty
            };

            // Generate the QR code
            var result = _qrCodeService.GenerateQrCode(inputURL.Content);

            // Assert that the result is null, indicating that QR code generation failed due to invalid input
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GenerateQrCode_InputExceedsMaxLength_ReturnsNull()
        {
            // Arrange
            var inputURL = new GenerateQrCodeRequest
            {
                Content = new string('A', 2050)
            };

            // Act
            var result = _qrCodeService.GenerateQrCode(inputURL.Content);

            // Assert
            Assert.IsNull(result);
        }
    }
}
