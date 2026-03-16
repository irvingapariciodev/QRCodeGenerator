namespace QRCodeGenerator.API.Models
{
    public class GenerateQrCodeRequest
    {
        /// <summary>
        /// URL or text to encode in the QR code
        /// </summary>
        public string Content { get; set; }
    }
}