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

            if (funFilter == "none")
                return (Bitmap)original.Clone();

            if (funFilter == "black")
                return ConvertToGrayscale(original);

            if (funFilter == "warm")
                return ApplyWarmFilter(original);

            return (Bitmap)original.Clone();
        }

        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap gray = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(gray))
            {
                var colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] {.3f, .3f, .3f, 0, 0},
                        new float[] {.59f, .59f, .59f, 0, 0},
                        new float[] {.11f, .11f, .11f, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                    });

                var attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }

            return gray;
        }

        private Bitmap ApplyWarmFilter(Bitmap original)
        {
            Bitmap warm = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(warm))
            {
                float[][] matrix =
                {
                    new float[] {1.1f, 0, 0, 0, 0},
                    new float[] {0, 1.0f, 0, 0, 0},
                    new float[] {0, 0, 0.9f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0.05f, 0.02f, 0, 0, 1}
                };

                ColorMatrix cm = new ColorMatrix(matrix);
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);

                g.DrawImage(original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel,
                    ia);
            }

            return warm;
        }
    }
}