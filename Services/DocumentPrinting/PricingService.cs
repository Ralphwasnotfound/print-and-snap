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
            if (totalPages <= 0 || copies <= 0)
                return 0;

            int total = 0;

            // =========================
            // BLACK & WHITE
            // =========================
            if (!isColored)
            {
                int pagesToPrint = 0;

                if (printAll)
                {
                    pagesToPrint = totalPages;
                }
                else if (singlePage)
                {
                    // Example: page 2 = exactly 1 page
                    if (singlePageNumber >= 1 && singlePageNumber <= totalPages)
                        pagesToPrint = 1;
                }
                else if (printRange)
                {
                    // Example: 1-5 = 5 pages
                    pagesToPrint = CountSelectedPages(pageRange, totalPages);
                }

                total = pagesToPrint * copies * BwPrice;
            }

            // =========================
            // COLOR / MIXED DOCUMENT
            // =========================
            else
            {
                int selectedTotal = 0;

                if (printAll)
                {
                    for (int i = 0; i < pageIsColored.Count && i < totalPages; i++)
                    {
                        selectedTotal += pageIsColored[i]
                            ? ColorPrice
                            : BwPrice;
                    }
                }
                else if (singlePage)
                {
                    // Example: user enters 2 → print/pricing is for page 2
                    int index = singlePageNumber - 1;

                    if (index >= 0 && index < pageIsColored.Count)
                    {
                        selectedTotal = pageIsColored[index]
                            ? ColorPrice
                            : BwPrice;
                    }
                }
                else if (printRange)
                {
                    if (TryParsePageRange(pageRange, totalPages, out int start, out int end))
                    {
                        start--; // Convert to zero-based
                        end--;

                        for (int i = start; i <= end && i < pageIsColored.Count; i++)
                        {
                            selectedTotal += pageIsColored[i]
                                ? ColorPrice
                                : BwPrice;
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
            if (!TryParsePageRange(input, totalPages, out int start, out int end))
                return 0;

            return end - start + 1;
        }


        // =========================
        // PARSE PAGE RANGE
        // =========================
        private bool TryParsePageRange(
            string input,
            int totalPages,
            out int start,
            out int end)
        {
            start = 0;
            end = 0;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim().Replace(" ", "");

            if (input == "e.g.1-5" || input == "e.g.1-5")
                return false;

            // Must contain exactly one "-"
            var parts = input.Split('-');

            if (parts.Length != 2)
                return false;

            if (!int.TryParse(parts[0], out start))
                return false;

            if (!int.TryParse(parts[1], out end))
                return false;

            // Valid page range
            if (start < 1)
                return false;

            if (end < 1)
                return false;

            if (start > end)
                return false;

            if (start > totalPages)
                return false;

            if (end > totalPages)
                return false;

            return true;
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