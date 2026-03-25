using System;
using System.Drawing;
using System.IO;

namespace PrintAndSnap.Services.PhotoPrinting
{
    public class PhotoService
    {
        public Bitmap Capture(Bitmap frame)
        {
            return new Bitmap(frame);
        }

        public string SavePhoto(Bitmap image)
        {
            string folder = @"C:\PrintAndSnap\photos";
            Directory.CreateDirectory(folder);

            string fileName = "photo_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
            string fullPath = Path.Combine(folder, fileName);

            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            return fullPath;
        }

        

        
    }
}