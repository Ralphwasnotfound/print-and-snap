using System;
using System.Collections.Generic;
using System.Drawing;

namespace PrintAndSnap.Services.PhotoPrinting
{
    public class PhotoLayoutServices
    {
        public Bitmap ApplyFunLayout(List<Bitmap> photos, string layoutType)
        {
            if (photos == null || photos.Count == 0)
                return null;

            int width = 600;
            int height = 800;

            Bitmap canvas = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);

                int margin = 20;

                Rectangle drawArea = new Rectangle(
                    margin,
                    margin,
                    width - margin * 2,
                    height - margin * 2
                );

                // 🔥 VERTICAL STRIP
                if (layoutType == "vertical")
                {
                    int count = Math.Min(photos.Count, 2);
                    int photoHeight = drawArea.Height / count;

                    for (int i = 0; i < count; i++)
                    {
                        int y = drawArea.Y + i * photoHeight;

                        g.DrawImage(
                            photos[i],
                            drawArea.X,
                            y,
                            drawArea.Width,
                            photoHeight
                        );
                    }
                }

                // 🔥 GRID 2x2
                else if (layoutType == "grid")
                {
                    int cols = 2;
                    int rows = 2;

                    int cellW = drawArea.Width / cols;
                    int cellH = drawArea.Height / rows;

                    int index = 0;

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < cols; c++)
                        {
                            if (index >= photos.Count) break;

                            int x = drawArea.X + c * cellW;
                            int y = drawArea.Y + r * cellH;

                            g.DrawImage(photos[index], x, y, cellW, cellH);

                            index++;
                        }
                    }
                }

                // 🔥 DEFAULT
                else
                {
                    g.DrawImage(photos[0], drawArea);
                }
            }

            return canvas;
        }

        public Bitmap GenerateIdLayout(Bitmap photo, string selectedLayout, bool isColored, bool isMultiple)
        {
            if (photo == null)
                return null;

            int dpi = 300;
            int spacing = 20;

            int photoWidth = dpi;
            int photoHeight = dpi;

            // =========================
            // 📏 SIZE SETUP
            // =========================
            if (selectedLayout == "1x1")
            {
                photoWidth = dpi;
                photoHeight = dpi;
            }
            else if (selectedLayout == "2x2")
            {
                photoWidth = 2 * dpi;
                photoHeight = 2 * dpi;
            }
            else if (selectedLayout == "2x1")
            {
                photoWidth = 2 * dpi;
                photoHeight = 1 * dpi;
            }

            // =========================
            // 🟢 SINGLE MODE
            // =========================
            if (!isMultiple)
            {
                // =========================
                // 🔥 2x2 GRID (4 PHOTOS)
                // =========================
                if (selectedLayout == "2x2")
                {
                    int cols = 2;
                    int rows = 2;

                    int canvasWidth = (photoWidth * cols) + spacing * (cols + 1);
                    int canvasHeight = (photoHeight * rows) + spacing * (rows + 1);

                    Bitmap canvas = new Bitmap(canvasWidth, canvasHeight);
                    canvas.SetResolution(300, 300);

                    using (Graphics g = Graphics.FromImage(canvas))
                    {
                        g.Clear(Color.White);

                        for (int r = 0; r < rows; r++)
                        {
                            for (int c = 0; c < cols; c++)
                            {
                                int x = spacing + c * (photoWidth + spacing);
                                int y = spacing + r * (photoHeight + spacing);

                                g.DrawImage(photo, x, y, photoWidth, photoHeight);

                                // ✂️ border
                                g.DrawRectangle(Pens.Black, x, y, photoWidth, photoHeight);
                            }
                        }
                    }

                    return canvas;
                }

                // =========================
                // 🔥 2x1 (FIXED)
                // =========================
                else if (selectedLayout == "2x1")
                {
                    int count = 2;

                    int canvasWidth = photoWidth + spacing * 2;
                    int canvasHeight = (photoHeight * count) + spacing * (count + 1);

                    Bitmap canvas = new Bitmap(canvasWidth, canvasHeight);
                    canvas.SetResolution(300, 300);

                    using (Graphics g = Graphics.FromImage(canvas))
                    {
                        g.Clear(Color.White);

                        for (int i = 0; i < count; i++)
                        {
                            int x = spacing;
                            int y = spacing + i * (photoHeight + spacing);

                            g.DrawImage(photo, x, y, photoWidth, photoHeight);

                            // ✂️ border
                            g.DrawRectangle(Pens.Black, x, y, photoWidth, photoHeight);
                        }
                    }

                    return canvas;
                }

                // =========================
                // 🔥 1x1
                // =========================
                else
                {
                    int canvasWidth = photoWidth + spacing * 2;
                    int canvasHeight = photoHeight + spacing * 2;

                    Bitmap canvas = new Bitmap(canvasWidth, canvasHeight);
                    canvas.SetResolution(300, 300);

                    using (Graphics g = Graphics.FromImage(canvas))
                    {
                        g.Clear(Color.White);
                        g.DrawImage(photo, spacing, spacing, photoWidth, photoHeight);

                        g.DrawRectangle(Pens.Black, spacing, spacing, photoWidth, photoHeight);
                    }

                    return canvas;
                }
            }

            // =========================
            // 🔵 MULTIPLE MODE (A4)
            // =========================
            int pageWidth = (int)(8.27 * dpi);
            int pageHeight = (int)(11.69 * dpi);

            Bitmap sheet = new Bitmap(pageWidth, pageHeight);
            sheet.SetResolution(300, 300);

            using (Graphics g = Graphics.FromImage(sheet))
            {
                g.Clear(Color.White);

                int totalW = photoWidth + spacing;
                int totalH = photoHeight + spacing;

                int cols = pageWidth / totalW;
                int rows = pageHeight / totalH;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        int x = c * totalW + spacing;
                        int y = r * totalH + spacing;

                        g.DrawImage(photo, x, y, photoWidth, photoHeight);
                    }
                }
            }

            return sheet;
        }
    }
}