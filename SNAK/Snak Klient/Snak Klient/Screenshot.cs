using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antycheat
{
    class Screenshot
    {
        /// <summary>
        /// Creates and saves a screenshot.
        /// Returns name of created file.
        /// </summary>
        /// <returns>Name of created file</returns>
        public static String takeScreenShot()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            String fileName = DateTime.Now.ToString("MMddyyyy-HHmmssff") + ".png";
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                createDirIfNotExists("screens");
                bmp.Save("screens\\" + fileName);
            }
            return fileName;
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
    }
}