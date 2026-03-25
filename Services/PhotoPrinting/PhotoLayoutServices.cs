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

            int layoutWidth = selectedLayout == "1x1" ? dpi : 2 * dpi;
            int layoutHeight = selectedLayout == "1x1" ? dpi : 2 * dpi;

            // SINGLE
            if (!isMultiple)
            {
                Bitmap canvas = new Bitmap(layoutWidth + spacing * 2, layoutHeight + spacing * 2);

                using (Graphics g = Graphics.FromImage(canvas))
                {
                    g.Clear(Color.White);
                    g.DrawImage(photo, spacing, spacing, layoutWidth, layoutHeight);
                }

                return canvas;
            }

            // MULTIPLE (FULL PAGE)
            int pageWidth = (int)(8.27 * dpi);
            int pageHeight = (int)(11.69 * dpi);

            Bitmap sheet = new Bitmap(pageWidth, pageHeight);

            using (Graphics g = Graphics.FromImage(sheet))
            {
                g.Clear(Color.White);

                int totalW = layoutWidth + spacing;
                int totalH = layoutHeight + spacing;

                int cols = pageWidth / totalW;
                int rows = pageHeight / totalH;

                int offsetX = (pageWidth - (cols * totalW)) / 2;
                int offsetY = (pageHeight - (rows * totalH)) / 2;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        int x = offsetX + c * totalW;
                        int y = offsetY + r * totalH;

                        g.DrawImage(photo, x, y, layoutWidth, layoutHeight);
                    }
                }
            }

            return sheet;
        }
    }
}