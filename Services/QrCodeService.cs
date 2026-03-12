using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QRCodeGenerator.Services
{
    public class QrCodeService
    {
        public byte[] GenerateQrCode(string url)
        {
            var generator = new QRCoder.QRCodeGenerator();

            QRCodeData data = generator.CreateQrCode(
                url,
                QRCoder.QRCodeGenerator.ECCLevel.Q
            );

            QRCode qrCode = new(data);

            Bitmap qrImage = qrCode.GetGraphic(10);

            using MemoryStream ms = new();
            qrImage.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public bool IsValidUTF8(string url)
        {
            try
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(url);
                var decodedURL = System.Text.Encoding.UTF8.GetString(bytes);
                return decodedURL.Equals(url);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
