using System.Drawing;
using System.Drawing.Imaging;

namespace PrintAndSnap.Services.PhotoPrinting
{
    public class FilterServices
    {
        public Bitmap ApplyFunFilter(Bitmap original, string funFilter)
        {
            if (original == null)
                return null;

            switch (funFilter)
            {
                case "black":
                    return ConvertToGrayscale(original);

                case "warm":
                    return ApplyWarmFilter(original);

                case "minimal":
                    return ApplyMinimalFilter(original);

                case "none":
                default:
                    return (Bitmap)original.Clone();
            }
        }

        // =========================
        // BLACK & WHITE
        // =========================
        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap gray = new Bitmap(
                original.Width,
                original.Height,
                PixelFormat.Format24bppRgb
            );

            using (Graphics g = Graphics.FromImage(gray))
            using (ImageAttributes attributes = new ImageAttributes())
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                        new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                        new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    }
                );

                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(
                    original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0,
                    0,
                    original.Width,
                    original.Height,
                    GraphicsUnit.Pixel,
                    attributes
                );
            }

            return gray;
        }

        // =========================
        // WARM
        // =========================
        private Bitmap ApplyWarmFilter(Bitmap original)
        {
            Bitmap warm = new Bitmap(
                original.Width,
                original.Height,
                PixelFormat.Format24bppRgb
            );

            using (Graphics g = Graphics.FromImage(warm))
            using (ImageAttributes attributes = new ImageAttributes())
            {
                ColorMatrix matrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] { 1.10f, 0, 0, 0, 0 },
                        new float[] { 0, 1.00f, 0, 0, 0 },
                        new float[] { 0, 0, 0.90f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0.05f, 0.02f, 0, 0, 1 }
                    }
                );

                attributes.SetColorMatrix(matrix);

                g.DrawImage(
                    original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0,
                    0,
                    original.Width,
                    original.Height,
                    GraphicsUnit.Pixel,
                    attributes
                );
            }

            return warm;
        }

        // =========================
        // MINIMAL
        // =========================
        private Bitmap ApplyMinimalFilter(Bitmap original)
        {
            Bitmap minimal = new Bitmap(
                original.Width,
                original.Height,
                PixelFormat.Format24bppRgb
            );

            using (Graphics g = Graphics.FromImage(minimal))
            using (ImageAttributes attributes = new ImageAttributes())
            {
                // Very subtle enhancement:
                // slightly brighter and softer colors.
                ColorMatrix matrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] { 1.03f, 0, 0, 0, 0 },
                        new float[] { 0, 1.03f, 0, 0, 0 },
                        new float[] { 0, 0, 1.03f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0.01f, 0.01f, 0.01f, 0, 1 }
                    }
                );

                attributes.SetColorMatrix(matrix);

                g.DrawImage(
                    original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0,
                    0,
                    original.Width,
                    original.Height,
                    GraphicsUnit.Pixel,
                    attributes
                );
            }

            return minimal;
        }
    }
}