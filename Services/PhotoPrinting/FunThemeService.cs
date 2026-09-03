using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace PrintAndSnap.Services
{
    public class FunThemeService
    {
        private readonly string themeFolder =
    Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "Assets",
        "Themes"
    );

        public Bitmap ApplyTheme(
    Bitmap photo,
    string theme,
    bool removeBackground)
        {
            if (photo == null)
                return null;

            if (string.IsNullOrEmpty(theme) || theme == "none")
                return new Bitmap(photo);

            string themeFile = GetThemeFile(theme);

            if (!File.Exists(themeFile))
            {
                throw new FileNotFoundException(
                    "FUN theme image not found.",
                    themeFile
                );
            }

            using (Bitmap background = new Bitmap(themeFile))
            {
                Bitmap result = new Bitmap(
                    background.Width,
                    background.Height,
                    PixelFormat.Format32bppArgb
                );

                result.SetResolution(
                    background.HorizontalResolution,
                    background.VerticalResolution
                );

                using (Graphics g = Graphics.FromImage(result))
                {
                    g.SmoothingMode =
                        SmoothingMode.HighQuality;

                    g.InterpolationMode =
                        InterpolationMode.HighQualityBicubic;

                    g.PixelOffsetMode =
                        PixelOffsetMode.HighQuality;

                    g.CompositingMode =
                        CompositingMode.SourceOver;

                    // =====================================
                    // 1. DRAW THEME
                    // =====================================

                    g.DrawImage(
                        background,
                        new Rectangle(
                            0,
                            0,
                            result.Width,
                            result.Height
                        )
                    );

                    // =====================================
                    // 2. PREPARE PHOTO
                    // =====================================

                    Bitmap photoToDraw = null;

                    if (removeBackground)
                    {
                        // =================================
                        // REMOVE WHITE BACKGROUND
                        // FROM AI RESULT
                        // =================================

                        photoToDraw = new Bitmap(
                            photo.Width,
                            photo.Height,
                            PixelFormat.Format32bppArgb
                        );

                        photoToDraw.SetResolution(
                            photo.HorizontalResolution,
                            photo.VerticalResolution
                        );

                        for (int y = 0; y < photo.Height; y++)
                        {
                            for (int x = 0; x < photo.Width; x++)
                            {
                                Color pixel =
                                    photo.GetPixel(x, y);

                                bool isWhite =
                                    pixel.R > 200 &&
                                    pixel.G > 200 &&
                                    pixel.B > 200;

                                if (isWhite)
                                {
                                    photoToDraw.SetPixel(
                                        x,
                                        y,
                                        Color.Transparent
                                    );
                                }
                                else
                                {
                                    photoToDraw.SetPixel(
                                        x,
                                        y,
                                        Color.FromArgb(
                                            255,
                                            pixel.R,
                                            pixel.G,
                                            pixel.B
                                        )
                                    );
                                }
                            }
                        }
                    }
                    else
                    {
                        // =================================
                        // NORMAL BACKGROUND
                        // KEEP ENTIRE ORIGINAL PHOTO
                        // =================================

                        photoToDraw =
                            new Bitmap(photo);
                    }

                    // =====================================
                    // 3. PHOTO AREA OF THE THEME
                    // =====================================
                    //
                    // These percentages match the white
                    // photo area of your theme designs.
                    //
                    // Adjust later if needed.
                    // =====================================

                    int photoAreaWidth =
                        (int)(result.Width * 0.70);

                    int photoAreaHeight =
                        (int)(result.Height * 0.67);

                    int photoAreaX =
                        (result.Width - photoAreaWidth) / 2;

                    int photoAreaY =
                        (int)(result.Height * 0.17);

                    Rectangle photoArea =
                        new Rectangle(
                            photoAreaX,
                            photoAreaY,
                            photoAreaWidth,
                            photoAreaHeight
                        );

                    // =====================================
                    // 4. KEEP PHOTO ASPECT RATIO
                    // =====================================

                    float scaleX =
                        (float)photoArea.Width /
                        photoToDraw.Width;

                    float scaleY =
                        (float)photoArea.Height /
                        photoToDraw.Height;

                    float scale =
                        Math.Min(scaleX, scaleY);

                    int drawWidth =
                        (int)(photoToDraw.Width * scale);

                    int drawHeight =
                        (int)(photoToDraw.Height * scale);

                    // =====================================
                    // 5. CENTER PHOTO
                    // =====================================

                    int drawX =
                        photoArea.X +
                        (photoArea.Width - drawWidth) / 2;

                    int drawY =
                        photoArea.Y +
                        (photoArea.Height - drawHeight) / 2;

                    Rectangle drawRectangle =
                        new Rectangle(
                            drawX,
                            drawY,
                            drawWidth,
                            drawHeight
                        );

                    // =====================================
                    // 6. DRAW PHOTO
                    // =====================================

                    g.DrawImage(
                        photoToDraw,
                        drawRectangle
                    );

                    photoToDraw.Dispose();
                }

                return result;
            }
        }

        private string GetThemeFile(string theme)
        {
            switch (theme.ToLower())
            {
                case "beach":
                    return Path.Combine(
                        themeFolder,
                        "beach.png"
                    );

                case "party":
                    return Path.Combine(
                        themeFolder,
                        "party.png"
                    );

                case "love":
                    return Path.Combine(
                        themeFolder,
                        "love.png"
                    );

                case "xmas":
                    return Path.Combine(
                        themeFolder,
                        "xmas.png"
                    );

                default:
                    throw new Exception(
                        "Unknown FUN theme: " + theme
                    );
            }
        }
    }
}