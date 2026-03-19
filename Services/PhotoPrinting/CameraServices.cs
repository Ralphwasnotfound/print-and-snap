using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace PrintAndSnap.Services.PhotoPrinting
{
    public class CameraService
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private NewFrameEventHandler frameHandler;

        public event Action<Bitmap> OnFrameCaptured;

        public void StartCamera()
        {
            StopCamera();

            Thread.Sleep(500);

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
                throw new Exception("No camera detected.");

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);

            frameHandler = (s, e) =>
            {
                Bitmap frame = (Bitmap)e.Frame.Clone();
                OnFrameCaptured?.Invoke(frame);
            };

            videoSource.NewFrame += frameHandler;

            videoSource.Start();
        }

        public void StopCamera()
        {
            if (videoSource != null)
            {
                try
                {
                    if (videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                        videoSource.WaitForStop();
                    }

                    if (frameHandler != null)
                    {
                        videoSource.NewFrame -= frameHandler;
                        frameHandler = null;
                    }

                    videoSource = null;
                }
                catch { }
            }
        }
    }
}