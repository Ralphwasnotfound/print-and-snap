using System.Drawing;

namespace PrintAndSnap.Services.PhotoPrinting
{
    public class FrameServices
    {
        public Bitmap ApplyFunFrame(Bitmap photo, string funFrame)
        {
            if (photo == null)
                return null;

            Bitmap safePhoto;

            try
            {
                // 🔥 THIS WILL FAIL if disposed
                safePhoto = (Bitmap)photo.Clone();
            }
            catch
            {
                // 💥 photo is disposed or invalid
                return null;
            }

            Bitmap canvas = new Bitmap(safePhoto.Width, safePhoto.Height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(safePhoto, 0, 0, safePhoto.Width, safePhoto.Height);

                if (funFrame == "minimal")
                {
                    using (Pen pen = new Pen(Color.Black, 5))
                    {
                        g.DrawRectangle(pen, 5, 5, canvas.Width - 10, canvas.Height - 10);
                    }
                }
                else if (funFrame == "cute")
                {
                    using (Pen pen = new Pen(Color.Pink, 8))
                    {
                        g.DrawRectangle(pen, 5, 5, canvas.Width - 10, canvas.Height - 10);
                    }

                    using (Brush b = new SolidBrush(Color.Pink))
                    {
                        g.FillEllipse(b, 5, 5, 20, 20);
                        g.FillEllipse(b, canvas.Width - 25, 5, 20, 20);
                        g.FillEllipse(b, 5, canvas.Height - 25, 20, 20);
                        g.FillEllipse(b, canvas.Width - 25, canvas.Height - 25, 20, 20);
                    }
                }
            }

            safePhoto.Dispose();

            return canvas;
        }
    }
}