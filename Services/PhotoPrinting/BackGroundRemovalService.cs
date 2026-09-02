using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace PrintAndSnap.Services
{
    public class BackgroundRemovalService
    {
        private readonly InferenceSession session;

        public BackgroundRemovalService()
        {
            string modelPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Models",
                "u2netp.onnx"
            );

            if (!File.Exists(modelPath))
            {
                throw new FileNotFoundException(
                    "Background removal model was not found.",
                    modelPath
                );
            }

            session = new InferenceSession(modelPath);
        }

        public Bitmap RemoveBackground(Bitmap source)
        {
            if (source == null)
                return null;

            int originalWidth = source.Width;
            int originalHeight = source.Height;

            // ==========================================
            // RESIZE IMAGE TO U2-NET INPUT SIZE
            // ==========================================

            Bitmap resized = new Bitmap(320, 320);

            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;

                g.DrawImage(
                    source,
                    new Rectangle(0, 0, 320, 320)
                );
            }

            // ==========================================
            // CREATE INPUT TENSOR
            // ==========================================

            var input = new DenseTensor<float>(
                new[] { 1, 3, 320, 320 }
            );

            float[] mean =
            {
        0.485f,
        0.456f,
        0.406f
    };

            float[] std =
            {
        0.229f,
        0.224f,
        0.225f
    };

            for (int y = 0; y < 320; y++)
            {
                for (int x = 0; x < 320; x++)
                {
                    Color pixel = resized.GetPixel(x, y);

                    float r = pixel.R / 255f;
                    float green = pixel.G / 255f;
                    float b = pixel.B / 255f;

                    input[0, 0, y, x] =
                        (r - mean[0]) / std[0];

                    input[0, 1, y, x] =
                        (green - mean[1]) / std[1];

                    input[0, 2, y, x] =
                        (b - mean[2]) / std[2];
                }
            }

            // ==========================================
            // RUN AI MODEL
            // ==========================================

            string inputName = session.InputMetadata.Keys.First();

            IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results =
                session.Run(
                    new[]
                    {
                NamedOnnxValue.CreateFromTensor(
                    inputName,
                    input
                )
                    }
                );

            try
            {
                var output = results.First().AsTensor<float>();

                // ==========================================
                // FIND MASK MIN / MAX
                // ==========================================

                float min = float.MaxValue;
                float max = float.MinValue;

                for (int i = 0; i < output.Length; i++)
                {
                    float value = output.GetValue(i);

                    if (value < min)
                        min = value;

                    if (value > max)
                        max = value;
                }

                // ==========================================
                // CREATE CLEAN BINARY MASK
                // ==========================================

                bool[,] foreground = new bool[320, 320];

                for (int y = 0; y < 320; y++)
                {
                    for (int x = 0; x < 320; x++)
                    {
                        float value = output[0, 0, y, x];

                        value =
                            (value - min) /
                            (max - min + 0.000001f);

                        // ==================================
                        // FOREGROUND THRESHOLD
                        // ==================================

                        foreground[x, y] = value > 0.30f;
                    }
                }

                // ==========================================
                // KEEP ONLY LARGEST CONNECTED OBJECT
                // ==========================================

                bool[,] cleanedMask =
                    KeepLargestComponent(foreground);

                // ==========================================
                // CLEAN SMALL HOLES / NOISE
                // ==========================================

                cleanedMask =
                    CleanMask(cleanedMask);

                // ==========================================
                // CREATE MASK BITMAP
                // ==========================================

                Bitmap maskSmall = new Bitmap(
                    320,
                    320,
                    PixelFormat.Format24bppRgb
                );

                try
                {
                    for (int y = 0; y < 320; y++)
                    {
                        for (int x = 0; x < 320; x++)
                        {
                            if (cleanedMask[x, y])
                            {
                                maskSmall.SetPixel(
                                    x,
                                    y,
                                    Color.White
                                );
                            }
                            else
                            {
                                maskSmall.SetPixel(
                                    x,
                                    y,
                                    Color.Black
                                );
                            }
                        }
                    }

                    // ==========================================
                    // RESIZE MASK TO ORIGINAL PHOTO SIZE
                    // ==========================================

                    Bitmap mask = new Bitmap(
                        originalWidth,
                        originalHeight
                    );

                    try
                    {
                        using (Graphics g = Graphics.FromImage(mask))
                        {
                            g.InterpolationMode =
                                InterpolationMode.HighQualityBicubic;

                            g.DrawImage(
                                maskSmall,
                                new Rectangle(
                                    0,
                                    0,
                                    originalWidth,
                                    originalHeight
                                )
                            );
                        }

                        // ==========================================
                        // CREATE FINAL WHITE BACKGROUND
                        // ==========================================

                        Bitmap result = new Bitmap(
                            originalWidth,
                            originalHeight,
                            PixelFormat.Format24bppRgb
                        );

                        // ==========================================
                        // COMPOSITE PERSON OVER WHITE
                        // ==========================================

                        for (int y = 0; y < originalHeight; y++)
                        {
                            for (int x = 0; x < originalWidth; x++)
                            {
                                Color originalPixel =
                                    source.GetPixel(x, y);

                                Color maskPixel =
                                    mask.GetPixel(x, y);

                                float alpha =
                                    maskPixel.R / 255f;

                                int r = (int)(
                                    originalPixel.R * alpha +
                                    255 * (1 - alpha)
                                );

                                int green = (int)(
                                    originalPixel.G * alpha +
                                    255 * (1 - alpha)
                                );

                                int b = (int)(
                                    originalPixel.B * alpha +
                                    255 * (1 - alpha)
                                );

                                result.SetPixel(
                                    x,
                                    y,
                                    Color.FromArgb(
                                        255,
                                        r,
                                        green,
                                        b
                                    )
                                );
                            }
                        }

                        return result;
                    }
                    finally
                    {
                        mask.Dispose();
                    }
                }
                finally
                {
                    maskSmall.Dispose();
                }
            }
            finally
            {
                results.Dispose();
                resized.Dispose();
            }
        }

        private bool[,] KeepLargestComponent(bool[,] mask)
        {
            int width = mask.GetLength(0);
            int height = mask.GetLength(1);

            bool[,] visited = new bool[width, height];
            bool[,] largest = new bool[width, height];

            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            int largestCount = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!mask[x, y] || visited[x, y])
                        continue;

                    System.Collections.Generic.Queue<Point> queue =
                        new System.Collections.Generic.Queue<Point>();

                    System.Collections.Generic.List<Point> component =
                        new System.Collections.Generic.List<Point>();

                    queue.Enqueue(new Point(x, y));
                    visited[x, y] = true;

                    while (queue.Count > 0)
                    {
                        Point current = queue.Dequeue();

                        component.Add(current);

                        for (int i = 0; i < 8; i++)
                        {
                            int nx = current.X + dx[i];
                            int ny = current.Y + dy[i];

                            if (nx < 0 || nx >= width ||
                                ny < 0 || ny >= height)
                                continue;

                            if (visited[nx, ny])
                                continue;

                            if (!mask[nx, ny])
                                continue;

                            visited[nx, ny] = true;

                            queue.Enqueue(
                                new Point(nx, ny)
                            );
                        }
                    }

                    if (component.Count > largestCount)
                    {
                        largestCount = component.Count;

                        largest = new bool[width, height];

                        foreach (Point point in component)
                        {
                            largest[point.X, point.Y] = true;
                        }
                    }
                }
            }

            return largest;
        }

        private bool[,] CleanMask(bool[,] mask)
        {
            int width = mask.GetLength(0);
            int height = mask.GetLength(1);

            bool[,] result =
                new bool[width, height];

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int neighbors = 0;

                    for (int yy = -1; yy <= 1; yy++)
                    {
                        for (int xx = -1; xx <= 1; xx++)
                        {
                            if (mask[x + xx, y + yy])
                                neighbors++;
                        }
                    }

                    // Keep pixel if it has enough neighboring
                    // foreground pixels.
                    result[x, y] = neighbors >= 2;
                }
            }

            return result;
        }
    }
}