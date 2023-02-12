using OpenCvSharp;

namespace FaceDetectorVideo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load the face classifier
            CascadeClassifier faceClassifier = new CascadeClassifier("C:\\Users\\Micro\\source\\repos\\Portfolio\\FaceDetector\\FaceDetectorVideo\\haarcascade_frontalface_default.xml");

            // Open the video capture
            VideoCapture capture = new VideoCapture("C:\\Users\\Micro\\source\\repos\\Portfolio\\FaceDetector\\FaceDetectorVideo\\video.mov"); // 0 is the default camera index

            // Create a window to display the video
            Window window = new Window("Faces");

            // Loop through each frame of the video
            while (true)
            {
                // Read a frame from the video
                Mat frame = new Mat();
                capture.Read(frame);

                // Check the size of the frame
                if (frame.Size().Width <= 0 || frame.Size().Height <= 0)
                {
                    Console.WriteLine("Error: The frame has zero width or height.");
                    break;
                }

                // Detect faces in the frame
                Rect[] faces = faceClassifier.DetectMultiScale(
                    frame,
                    scaleFactor: 1.1,
                    minNeighbors: 3,
                    flags: HaarDetectionTypes.ScaleImage,
                    minSize: new Size(30, 30)
                );

                // Draw rectangles around the detected faces
                foreach (Rect face in faces)
                {
                    Cv2.Rectangle(frame, face, new Scalar(0, 255, 0), 2);
                }

                // Show the frame with the faces marked
                window.ShowImage(frame);

                // Break the loop if the user presses the Esc key
                if (Cv2.WaitKey(30) == 27)
                {
                    break;
                }
            }

            // Release the video capture and close the window
            capture.Release();
            window.Close();
        }
    }
}