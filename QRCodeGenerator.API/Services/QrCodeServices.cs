using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QRCodeGenerator.Services
{
    public class QrCodeService
    {
        public byte[] GenerateQrCode(string inputURL)
        {
            const int maxURLLenght = 200;

            if (string.IsNullOrEmpty(inputURL) || string.IsNullOrWhiteSpace(inputURL))
                return null;

            if (inputURL.Length > maxURLLenght)
                return null;

            if (!IsValidUTF8(inputURL))
                return null;

            try
            {
                var generator = new QRCoder.QRCodeGenerator();
                QRCodeData data = generator.CreateQrCode(inputURL, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new(data);

                Bitmap qrImage = qrCode.GetGraphic(10);

                using MemoryStream ms = new();
                qrImage.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error creating the image {ex.Message}.");
                return null;
            }
        }

        public bool IsValidUTF8(string inputURL)
        {
            try
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(inputURL);
                var decodedURL = System.Text.Encoding.UTF8.GetString(bytes);
                return decodedURL.Equals(inputURL);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}