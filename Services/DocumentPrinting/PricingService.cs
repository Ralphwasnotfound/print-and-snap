using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PrintAndSnap.Services
{
    public class PricingService
    {
        public int BwPrice { get; set; } = 5;
        public int ColorPrice { get; set; } = 10;

        // =========================
        // CALCULATE TOTAL
        // =========================
        public int CalculateTotal(
            int totalPages,
            int copies,
            bool printAll,
            bool singlePage,
            int singlePageNumber,
            bool printRange,
            string pageRange,
            bool isColored,
            List<bool> pageIsColored
        )
        {
            int pagesToPrint = totalPages;

            if (singlePage)
                pagesToPrint = 1;
            else if (printRange)
                pagesToPrint = CountSelectedPages(pageRange, totalPages);

            int total = 0;

            if (!isColored)
            {
                total = pagesToPrint * copies * BwPrice;
            }
            else
            {
                int selectedTotal = 0;

                if (printAll)
                {
                    foreach (var isColor in pageIsColored)
                        selectedTotal += isColor ? ColorPrice : BwPrice;
                }
                else if (singlePage)
                {
                    int index = singlePageNumber - 1;

                    if (index >= 0 && index < pageIsColored.Count)
                        selectedTotal = pageIsColored[index] ? ColorPrice : BwPrice;
                }
                else if (printRange)
                {
                    var parts = pageRange.Split('-');

                    if (parts.Length == 2 &&
                        int.TryParse(parts[0], out int start) &&
                        int.TryParse(parts[1], out int end))
                    {
                        start -= 1;
                        end -= 1;

                        for (int i = start; i <= end && i < pageIsColored.Count; i++)
                        {
                            selectedTotal += pageIsColored[i] ? ColorPrice : BwPrice;
                        }
                    }
                }

                total = selectedTotal * copies;
            }

            return total;
        }

        // =========================
        // COUNT PAGES
        // =========================
        public int CountSelectedPages(string input, int totalPages)
        {
            if (string.IsNullOrWhiteSpace(input) || input == "e.g. 1-5")
                return 0;

            try
            {
                if (input.Contains("-"))
                {
                    var parts = input.Replace(" ", "").Split('-');

                    if (parts.Length != 2)
                        return 0;

                    if (!int.TryParse(parts[0], out int start) ||
                        !int.TryParse(parts[1], out int end))
                        return 0;

                    if (start >= 1 && end <= totalPages && start <= end)
                        return end - start + 1;
                }
                else
                {
                    if (int.TryParse(input, out int single))
                    {
                        if (single >= 1 && single <= totalPages)
                            return 1;
                    }
                }
            }
            catch { }

            return 0;
        }

        // =========================
        // COLOR ANALYSIS
        // =========================
        public List<bool> AnalyzeDocumentColors(string pdfPath)
        {
            List<bool> result = new List<bool>();

            using (var document = PdfDocument.Load(pdfPath))
            {
                for (int i = 0; i < document.PageCount; i++)
                {
                    using (var img = document.Render(i, 50, 50, true))
                    using (var bmp = new Bitmap(img))
                    {
                        result.Add(PageHasColorFast(bmp));
                    }
                }
            }

            return result;
        }

        private bool PageHasColorFast(Bitmap bitmap)
        {
            for (int x = 0; x < bitmap.Width; x += 5)
            {
                for (int y = 0; y < bitmap.Height; y += 5)
                {
                    Color pixel = bitmap.GetPixel(x, y);

                    if (pixel.R != pixel.G || pixel.G != pixel.B)
                        return true;
                }
            }

            return false;
        }
    }
}