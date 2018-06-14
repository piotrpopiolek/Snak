using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Net.Sockets;

namespace Antycheat
{
    class Screenshot
    {
        /// <summary>
        /// Starts sending screenshots
        /// </summary>
        /// 
        public static bool screen = false;

        public static bool running = true;

        public static string ipSerwera;

        public static void startPreview()
        {
            while(running)
            {
                while (screen)
                {
                    Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);

                        int quality = 10;
                        EncoderParameters encoderParams = GetEncoderParameters(quality);
                        ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                        Image image = new Bitmap(bmp);
                        Byte[] imageInBytes = imageToByteArray(image, jpegCodec, encoderParams);

                        WyslijWiadomoscUDP(imageInBytes);
                    }
                    
                }
                Thread.Sleep(50);
            }
        }

        public static byte[] imageToByteArray(Image image, ImageCodecInfo imageCodecInfo, EncoderParameters encoderParameters)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, imageCodecInfo, encoderParameters);
                return ms.ToArray();
            }
        }

        public static Image byteArrayToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        private static EncoderParameters GetEncoderParameters(int quality)
        {
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            return encoderParams;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        /// <summary>
        /// Converts image to byte array.
        /// </summary>
        /// <param name="imagefilePath">File path of an image</param>
        /// <returns>Byte array of an image</returns>
        public static byte[] imageToByteArray(String imagefilePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagefilePath);
            return imageArray;
        }

        /// <summary>
        /// Saves an image.
        /// </summary>
        /// <param name="imageByte">Byte array of an image</param>
        /// <param name="fileName">Name of file</param>
        /// <param name="clientName">Name of a client</param>
        public static void saveAsImage(byte[] imageByte, String fileName, String clientName)
        {
            MemoryStream ms = new MemoryStream(imageByte);
            Image image = Image.FromStream(ms);
            String path = "screens\\" + clientName;
            createDirIfNotExists(path);
            image.Save(path + "\\" + fileName);
        }

        private static void createDirIfNotExists(String path)
        {
            System.IO.Directory.CreateDirectory(path);
        }

        private static void WyslijWiadomoscUDP(byte[] tablica)
        {
            try
            {
                UdpClient klient = new UdpClient(ipSerwera, 43220);
                klient.Send(tablica, tablica.Length);
                klient.Close();
            }
            catch(Exception e)
            {

            }
        }
    }
}