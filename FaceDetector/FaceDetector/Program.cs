using OpenCvSharp;

namespace FaceDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Carregar a imagem
            Mat image = new Mat("C:\\Users\\Micro\\source\\repos\\Portfolio\\FaceDetector\\FaceDetector\\imagem.jpg", ImreadModes.Color);

            // Carregar o classificador de rosto
            CascadeClassifier faceClassifier = new CascadeClassifier("C:\\Users\\Micro\\source\\repos\\Portfolio\\FaceDetector\\FaceDetector\\haarcascade_frontalface_default.xml");

            // Detectar rostos na imagem
            Rect[] faces = faceClassifier.DetectMultiScale(
                image,
                scaleFactor: 1.1,
                minNeighbors: 3,
                flags: HaarDetectionTypes.ScaleImage,
                minSize: new Size(30, 30)
            );

            // Desenhar retângulos ao redor dos rostos detectados
            foreach (Rect face in faces)
            {
                Cv2.Rectangle(image, face, new Scalar(0, 255, 0), 2);
            }

            // Mostrar a imagem com os rostos marcados
            using (new Window("Faces", image))
            {
                Cv2.WaitKey();
            }
        }
    }
}