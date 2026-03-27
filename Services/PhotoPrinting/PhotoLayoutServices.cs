using System;
using System.Collections.Generic;
using System.Drawing;

namespace PrintAndSnap.Services.PhotoPrinting
{
    public class PhotoLayoutServices
    {
        public Bitmap ResizeTo4x6(Bitmap original)
        {
            int width = 1200;
            int height = 1800;

            Bitmap canvas = new Bitmap(width, height);
            canvas.SetResolution(300, 300);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);

                float ratio = Math.Min(
                    (float)width / original.Width,
                    (float)height / original.Height
                );

                int drawW = (int)(original.Width * ratio);
                int drawH = (int)(original.Height * ratio);

                int offsetX = (width - drawW) / 2;
                int offsetY = (height - drawH) / 2;

                g.DrawImage(original, offsetX, offsetY, drawW, drawH);
            }

            return canvas;
        }

        public Bitmap ApplyDownloadLayout(List<Bitmap> photos, string layoutType)
        {
            if (photos == null || photos.Count == 0)
                return null;

            int width = 1080;
            int height = 1920;

            Bitmap canvas = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White); // ✅ background

                int outerPaddingTop = 20;
                int outerPaddingBottom = 20;
                int outerPaddingLeft = 10;
                int outerPaddingRight = 10;

                // =========================
                // 🔥 VERTICAL STRIP
                // =========================
                if (layoutType == "vertical")
                {
                    int count = 4;
                    int verticalGap = 25;

                    int availableHeight = height - outerPaddingTop - outerPaddingBottom - (verticalGap * (count - 1));
                    int cellHeight = availableHeight / count;
                    int cellWidth = width - outerPaddingLeft - outerPaddingRight;

                    int y = outerPaddingTop;

                    for (int i = 0; i < count; i++)
                    {
                        Bitmap img = photos[i % photos.Count];

                        int innerMargin = 8;

                        int contentW = cellWidth - (innerMargin * 2);
                        int contentH = cellHeight - (innerMargin * 2);

                        float ratio = Math.Min(
                            (float)contentW / img.Width,
                            (float)contentH / img.Height
                        );

                        int drawW = (int)(img.Width * ratio);
                        int drawH = (int)(img.Height * ratio);

                        int x = outerPaddingLeft;

                        int offsetX = x + innerMargin + (contentW - drawW) / 2;
                        int offsetY = y + innerMargin + (contentH - drawH) / 2; // ✅ FIXED

                        g.DrawImage(img, offsetX, offsetY, drawW, drawH);

                        y += cellHeight + verticalGap;
                    }
                }

                // =========================
                // 🔥 GRID
                // =========================
                else if (layoutType == "grid")
                {
                    int rows = 3; // 3 big sections
                    int outerGap = 20; // space BETWEEN sections only

                    int totalGapY = outerGap * (rows - 1);

                    int cellWidth = width - outerPaddingLeft - outerPaddingRight;
                    int cellHeight = (height - outerPaddingTop - outerPaddingBottom - totalGapY) / rows;

                    int index = 0;

                    for (int r = 0; r < rows; r++)
                    {
                        int x = outerPaddingLeft;
                        int y = outerPaddingTop + r * (cellHeight + outerGap);

                        // 🔥 EACH CELL = 2x2 (4 photos)
                        int miniCols = 2;
                        int miniRows = 2;

                        for (int mr = 0; mr < miniRows; mr++)
                        {
                            for (int mc = 0; mc < miniCols; mc++)
                            {
                                Bitmap img = photos[index % photos.Count];

                                int mx = x + (mc * cellWidth / miniCols);
                                int my = y + (mr * cellHeight / miniRows);

                                // 🔥 FIX: last column/row takes remaining pixels
                                int miniW = (mc == miniCols - 1)
                                    ? (x + cellWidth) - mx
                                    : (cellWidth / miniCols);

                                int miniH = (mr == miniRows - 1)
                                    ? (y + cellHeight) - my
                                    : (cellHeight / miniRows);

                                // ✅ FULL BLEED (NO MARGIN AT ALL)
                                int contentW = miniW;
                                int contentH = miniH;

                                float ratio = Math.Max(
                                    (float)contentW / img.Width,
                                    (float)contentH / img.Height
                                );

                                int drawW = (int)(img.Width * ratio);
                                int drawH = (int)(img.Height * ratio);

                                int offsetX = mx + (contentW - drawW) / 2;
                                int offsetY = my + (contentH - drawH) / 2;

                                g.DrawImage(img, offsetX, offsetY, drawW, drawH);

                                index++;
                            }
                        }
                    }
                }
            }

            return canvas;
        }
        public Bitmap ApplyFunLayout(List<Bitmap> photos, string layoutType, bool showCutLines)
        {
            if (photos == null || photos.Count == 0)
                return null;

            int width = 1200;
            int height = 1800;

            Bitmap canvas = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);

                // 🔥 QUALITY
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                int padding = 20;

                // =========================
                // VERTICAL STRIP
                // =========================
                if (layoutType == "vertical")
                {
                    int outerPaddingTop = 40;
                    int outerPaddingBottom = 70;
                    int outerPaddingLeft = 20;
                    int outerPaddingRight = 20;
                    

                    int spacing = 1; 

                    int rows = 4;
                    int cols = 2;

                    int totalSpacingX = spacing * (cols - 1);
                    int totalSpacingY = spacing * (rows - 1);

                    int cellWidth = (canvas.Width - outerPaddingLeft - outerPaddingRight - totalSpacingX) / cols;
                    int cellHeight = cellWidth * 2 / 3; 

                    int startX = outerPaddingLeft;
                    int totalUsedHeight = (cellHeight * rows) + totalSpacingY;
                    int remainingHeight = canvas.Height - outerPaddingTop - outerPaddingBottom - totalUsedHeight;

                    //push layout down slightly to balance top & bottom
                    int startY = outerPaddingTop + (remainingHeight / 2);

                    int index = 0;

                    // =========================
                    // DRAW 2x2 (4 PHOTOS)
                    // =========================
                    for (int row = 0; row < rows; row++)
                    {
                        
                        for (int col = 0; col < cols; col++)
                        {
                            // position of each cell
                            int x = startX + col * (cellWidth + spacing);
                            int y = startY + row * (cellHeight + spacing);

                            // get image
                            Bitmap img = photos[index % photos.Count];

                            // inner margin
                            int innerMargin = 10;

                            int contentWidth = cellWidth - (innerMargin * 2);
                            int contentHeight = cellHeight - (innerMargin * 2);

                            float ratio = Math.Min(
                                (float)contentWidth / img.Width,
                                (float)contentHeight / img.Height
                            );

                            int drawW = (int)(img.Width * ratio);
                            int drawH = (int)(img.Height * ratio);

                            // CENTER inside each cut cell
                            int offsetX = x + innerMargin + (contentWidth - drawW) / 2;
                            int offsetY = y + innerMargin + (contentHeight - drawH) / 2;

                            g.DrawImage(img, offsetX, offsetY, drawW, drawH);

                            index++;
                        }
                    }

                    // =========================
                    // ✂️ CUT GUIDES
                    // =========================

                    if (showCutLines)
                    {
                        using (Pen cutPen = new Pen(Color.FromArgb(150, 150, 150), 2))
                        {
                            cutPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                            int left = outerPaddingLeft;
                            int right = canvas.Width - outerPaddingRight;
                            int top = outerPaddingTop;
                            int bottom = canvas.Height - outerPaddingBottom;

                            // outer border
                            g.DrawLine(cutPen, left, top, right, top);
                            g.DrawLine(cutPen, left, bottom, right, bottom);
                            g.DrawLine(cutPen, left, top, left, bottom);
                            g.DrawLine(cutPen, right, top, right, bottom);

                            // 🔥 ONLY vertical middle cut
                            int midX = padding + cellWidth + (spacing / 2);
                            g.DrawLine(cutPen, midX, top, midX, bottom);
                        }
                    }
                    
                }

                // =========================
                // GRID 2x2 (with cut lines)
                // =========================
                else if (layoutType == "grid")
                {
                    int cols = 2;
                    int rows = 3;

                    // 🔥 COPY FROM VERTICAL (balanced cut margins)
                    int outerPaddingTop = 40;
                    int outerPaddingBottom = 70;
                    int outerPaddingLeft = 20;
                    int outerPaddingRight = 20;

                    int spacing = 10;

                    int totalSpacingX = spacing * (cols - 1);
                    int totalSpacingY = spacing * (rows - 1);

                    int cellWidth = (canvas.Width - outerPaddingLeft - outerPaddingRight - totalSpacingX) / cols;

                    int cellHeight = cellWidth * 3 / 4;

                    int totalUsedHeight = (cellHeight * rows) + totalSpacingY;
                    int remainingHeight = canvas.Height - outerPaddingTop - outerPaddingBottom - totalUsedHeight;

                    // CENTER LIKE VERTICAL
                    int startX = outerPaddingLeft;
                    int startY = outerPaddingTop + (remainingHeight / 2 );

                    int index = 0;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            int x = startX + col * (cellWidth + spacing);
                            int y = startY + row * (cellHeight + spacing);

                            int innerMargin = 10;

                            int miniCellWidth = (cellWidth - (innerMargin * 2)) / 2;
                            int miniCellHeight = (cellHeight - (innerMargin * 2)) / 2;

                            for (int r = 0; r < 2; r++)
                            {
                                for (int c = 0; c < 2; c++)
                                {
                                    Bitmap img = photos[index % photos.Count];

                                    int mx = x + innerMargin + c * miniCellWidth;
                                    int my = y + innerMargin + r * miniCellHeight;

                                    g.DrawImage(img, mx, my, miniCellWidth, miniCellHeight);

                                    index++;
                                }
                            }
                        }
                    }

                    // =========================
                    // ✂️ CUT LINES 
                    // =========================
                    if (showCutLines)
                    {
                        using (Pen cutPen = new Pen(Color.FromArgb(150, 150, 150), 2))
                        {
                            cutPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                            int left = outerPaddingLeft;
                            int right = canvas.Width - outerPaddingRight;
                            int top = outerPaddingTop;
                            int bottom = canvas.Height - outerPaddingBottom;

                            // outer border
                            g.DrawLine(cutPen, left, top, right, top);
                            g.DrawLine(cutPen, left, bottom, right, bottom);
                            g.DrawLine(cutPen, left, top, left, bottom);
                            g.DrawLine(cutPen, right, top, right, bottom);

                            // 🔥 vertical middle cut (same logic)
                            int midX = startX + cellWidth + (spacing / 2);
                            g.DrawLine(cutPen, midX, top, midX, bottom);
                        }
                    }
                    
                }
                // =========================
                // EFAULT
                // =========================
                else
                {
                    Rectangle drawArea = new Rectangle(
                        padding,
                        padding,
                        width - padding * 2,
                        height - padding * 2
                    );

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