using System;
using System.Drawing;
using System.Drawing.Printing;

namespace PrintAndSnap.Services.Printing
{
    public class PhotoPrinting
    {
        public void PrintIdPhoto(Bitmap image, string printerName, bool centerImage, string photoSize)
        {
            if (image == null)
                return;

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = printerName;

            // ✅ KEEP THIS (important for printer)
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            pd.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
            pd.OriginAtMargins = true;

            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                if (centerImage)
                {

                    Rectangle pageArea = e.PageBounds;

                    float ratio = Math.Min(
                        (float)pageArea.Width / image.Width,
                        (float)pageArea.Height / image.Height
                    );

                    int drawW = (int)(image.Width * ratio);
                    int drawH = (int)(image.Height * ratio);

                    int x = (pageArea.Width - drawW) / 2;
                    int y = (pageArea.Height - drawH) / 2;

                    g.DrawImage(image, x, y, drawW, drawH);
                }
                else
                {
                    Rectangle area = e.MarginBounds;

                    bool isMultiple = photoSize == "multiple";

                    // 🔥 SCALE IMAGE TO FIT PRINT AREA
                    float ratio = Math.Min(
                        (float)area.Width / image.Width,
                        (float)area.Height / image.Height
                    );

                    int drawW = (int)(image.Width * ratio);
                    int drawH = (int)(image.Height * ratio);

                    if (isMultiple)
                    {
                        // ✅ CENTER MULTIPLE
                        int x = area.Left + (area.Width - drawW) / 2;
                        int y = area.Top + (area.Height - drawH) / 2;

                        g.DrawImage(image, x, y, drawW, drawH);
                    }
                    else
                    {
                        // SINGLE (NOT SCALED)
                        g.DrawImage(image, area.Left, area.Top);
                    }
                }

            };

            pd.Print();
            pd.Dispose();
        }

        public void PrintFunPhoto(Bitmap image, string printerName)
        {
            if (image == null)
                return;

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = printerName;

            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            // ✅ SET MARGINS (you can tweak this)
            pd.DefaultPageSettings.Margins = new Margins(30, 30, 30, 30);
            pd.OriginAtMargins = true;

            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Rectangle area = e.MarginBounds;

                // 🔥 SCALE TO FIT (no stretching)
                float ratio = Math.Min(
                    (float)area.Width / image.Width,
                    (float)area.Height / image.Height
                );

                int drawW = (int)(image.Width * ratio);
                int drawH = (int)(image.Height * ratio);

                // 🔥 CENTER IT
                int x = area.Left + (area.Width - drawW) / 2;
                int y = area.Top + (area.Height - drawH) / 2;

                g.DrawImage(image, x, y, drawW, drawH);
            };

            pd.Print();
            pd.Dispose();
        }
    }
}