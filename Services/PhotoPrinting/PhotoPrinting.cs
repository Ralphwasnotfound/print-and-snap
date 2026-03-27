using System;
using System.Drawing;
using System.Drawing.Printing;

namespace PrintAndSnap.Services.Printing
{
    public class PhotoPrinting
    {
        public void PrintPhoto(Bitmap image, string printerName, bool centerImage)
        {
            if (image == null)
                return;

            PrintDocument pd = new PrintDocument();

            pd.PrinterSettings.PrinterName = printerName;

            // ✅ A4 PAPER
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            // ✅ MARGINS
            pd.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
            pd.OriginAtMargins = true;

            pd.PrintPage += (s, ev) =>
            {
                var g = ev.Graphics;

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Rectangle pageArea = ev.MarginBounds;

                if (centerImage)
                {
                    // 🎯 FUN MODE (CENTER)
                    float ratio = Math.Min(
                        (float)pageArea.Width / image.Width,
                        (float)pageArea.Height / image.Height
                    );

                    int drawW = (int)(image.Width * ratio);
                    int drawH = (int)(image.Height * ratio);

                    int offsetX = pageArea.X + (pageArea.Width - drawW) / 2;
                    int offsetY = pageArea.Y + (pageArea.Height - drawH) / 2;

                    g.DrawImage(image, offsetX, offsetY, drawW, drawH);
                }
                else
                {
                    // 🎯 ID MODE (TOP-LEFT)
                    g.DrawImage(image, pageArea.X, pageArea.Y, image.Width, image.Height);
                }
            };

 

            pd.Print();
        }
    }
}