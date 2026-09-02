using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace PrintAndSnap.Services
{
    public class SuitOverlayService
    {
        private Bitmap maleSuit;
        private Bitmap femaleSuit;

        public SuitOverlayService()
        {
            LoadSuitImages();
        }

        private void LoadSuitImages()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            string malePath = Path.Combine(
                basePath,
                "Assets",
                "Suits",
                "male_suit.png"
            );

            string femalePath = Path.Combine(
                basePath,
                "Assets",
                "Suits",
                "female_suit.png"
            );

            if (File.Exists(malePath))
                maleSuit = new Bitmap(malePath);

            if (File.Exists(femalePath))
                femaleSuit = new Bitmap(femalePath);
        }

        public Bitmap ApplySuit(Bitmap photo, string gender)
        {
            if (photo == null)
                return null;

            Bitmap suit = null;

            if (gender == "male")
                suit = maleSuit;
            else if (gender == "female")
                suit = femaleSuit;

            // ==========================================
            // IMPORTANT:
            // If the suit wasn't loaded, DON'T silently
            // return the original photo.
            // ==========================================

            if (suit == null)
            {
                throw new Exception(
                    "Suit image was not found.\n\n" +
                    "Expected:\n" +
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Assets",
                        "Suits",
                        gender == "male"
                            ? "male_suit.png"
                            : "female_suit.png"
                    )
                );
            }

            Bitmap result = new Bitmap(
                photo.Width,
                photo.Height,
                PixelFormat.Format32bppArgb
            );

            result.SetResolution(
                photo.HorizontalResolution,
                photo.VerticalResolution
            );

            using (Graphics g = Graphics.FromImage(result))
            {
                g.Clear(Color.White);

                g.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

                g.SmoothingMode =
                    SmoothingMode.HighQuality;

                g.PixelOffsetMode =
                    PixelOffsetMode.HighQuality;

                g.CompositingMode =
                    CompositingMode.SourceOver;

                // ==========================================
                // DRAW PERSON
                // ==========================================

                g.DrawImage(
                    photo,
                    new Rectangle(
                        0,
                        0,
                        photo.Width,
                        photo.Height
                    )
                );

                // ==========================================
                // SUIT POSITION
                // ==========================================

                int suitTop =
                    (int)(photo.Height * 0.50);

                int suitHeight =
                    photo.Height - suitTop;

                Rectangle suitRectangle =
                    new Rectangle(
                        0,
                        suitTop,
                        photo.Width,
                        suitHeight
                    );

                // ==========================================
                // DRAW SUIT
                // ==========================================

                g.DrawImage(
                    suit,
                    suitRectangle
                );
            }

            return result;
        }
    }
}