using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encoder = System.Drawing.Imaging.Encoder;

namespace gym_management_system.Manger
{
    public class MangeImage
    {
        private Image image;
        private string base64Image;

        public Image Image { get => image; set => image = value; }
        public string Base64Image { get => base64Image; set => base64Image = value; }

        public Image ConvertBase64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image = Image.FromStream(ms);
                    return Image;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error converting base64 to image: " + ex.Message);
                return null;
            }
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == mimeType)
                {
                    return codec;
                }
            }
            return null;
        }

        public long GetFileSizeInBytes(string filePath)
        {
            long fileSize = -1;

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                fileSize = fileInfo.Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting file size: {ex.Message}");
            }

            return fileSize / 1024;
        }

        public Image CompressImageSize(Image originalImage)
        {
            if (originalImage == null)
            {
                Console.WriteLine("Error CompressImageSize: orignalImage is equal null");
                base64Image = null;
                return null;
            }
            double imageSizeInKB;

            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 15L);

            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            using (MemoryStream memoryStream = new MemoryStream())
            {

                originalImage.Save(memoryStream, jpegCodec, encoderParameters);
                Base64Image = Convert.ToBase64String(memoryStream.ToArray());
                byte[] imageBytes = Convert.FromBase64String(Base64Image);
                imageSizeInKB = imageBytes.Length / 1024.0;
                if (imageSizeInKB > 350)
                {
                    Base64Image = "";
                    Console.WriteLine("Error CompressImageSize: imageSize is Big");
                    return null;
                }
            }
            image = ConvertBase64ToImage(Base64Image);
            return image;
        }

        public string CompressImageSizeGetBase64(Image originalImage)
        {
            if (originalImage == null)
            {
                Console.WriteLine("Error CompressImageSizeGetBase64: orignalImage is equal null");
                base64Image = null;
                return null;
            }
            double imageSizeInKB;

            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 15L);

            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            using (MemoryStream memoryStream = new MemoryStream())
            {

                originalImage.Save(memoryStream, jpegCodec, encoderParameters);
                Base64Image = Convert.ToBase64String(memoryStream.ToArray());
                byte[] imageBytes = Convert.FromBase64String(Base64Image);
                imageSizeInKB = imageBytes.Length / 1024.0;
                if (imageSizeInKB > 350)
                {
                    Base64Image = "";
                    Console.WriteLine("Error CompressImageSizeGetBase64: imageSize is Big");
                    return null;
                }
            }
            return base64Image;
        }

        public string ConvertImageToBase64(Image image)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    string base64String = Convert.ToBase64String(ms.ToArray());
                    return base64String;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image to Base64: {ex.Message}");
                return null;
            }
        }
    }
}
