using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Logic
{
    internal class Manipulation
    {


        public static string ImageToBinary(string imagePath)
        {
            // Membaca gambar
            Bitmap img = new Bitmap(imagePath);

            // Konversi gambar ke grayscale
            Bitmap grayscaleImg = ConvertToGrayscale(img);

            // Mengubah gambar menjadi string biner
            string binaryString = "";

            for (int y = 0; y < grayscaleImg.Height; y++)
            {
                for (int x = 0; x < grayscaleImg.Width; x++)
                {
                    Color pixelColor = grayscaleImg.GetPixel(x, y);
                    int grayscaleValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11); // Nilai grayscale

                    // Mengubah nilai piksel menjadi 0 atau 1 (binary) berdasarkan threshold
                    int threshold = 128;
                    binaryString += grayscaleValue > threshold ? "1" : "0";
                }
            }

            return binaryString;
        }

        public static Bitmap ConvertToGrayscale(Bitmap img)
        {
            Bitmap grayscaleImg = new Bitmap(img.Width, img.Height);

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    int grayscaleValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11); // Nilai grayscale
                    Color grayscaleColor = Color.FromArgb(grayscaleValue, grayscaleValue, grayscaleValue);
                    grayscaleImg.SetPixel(x, y, grayscaleColor);
                }
            }

            return grayscaleImg;
        }

        public static string BinaryToAscii(string binaryString)
        {
            StringBuilder asciiChars = new StringBuilder();
            for (int i = 0; i < binaryString.Length; i += 8)
            {
                string byteStr = binaryString.Substring(i, Math.Min(8, binaryString.Length - i));
                if (byteStr.Length == 8)
                {
                    asciiChars.Append((char)Convert.ToInt32(byteStr, 2));
                }
            }

            return asciiChars.ToString();
        }

        //Buat Motong 30 pixel ditengah
        public static Bitmap CropImage(string imagePath)
        {
            // Load the image
            Bitmap bitmap = new Bitmap(imagePath);

          
            int centerX = bitmap.Width / 2;
            int centerY = bitmap.Height / 2;

            int cropWidth = 5;
            int cropHeight = 6;
            Rectangle cropRect = new Rectangle(centerX - cropWidth / 2, centerY - cropHeight / 2, cropWidth, cropHeight);

     
            Bitmap croppedBitmap = bitmap.Clone(cropRect, bitmap.PixelFormat);

            return croppedBitmap;
        }

    }


    //Cara pakai
    //static void Main(string[] args)
    //{
    //string imagePath = @"D:\Testing\Buat Database\1__M_Left_index_finger.BMP";
    //string binaryString = ImageToBinary(imagePath);

    //Console.WriteLine(binaryString);
    //string ascii = BinaryToAscii(binaryString);
    // Console.WriteLine(ascii);
    // }





}
