using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Logic
{
    public class Data {
        public static string chosenImageBinary;
    }

    internal class Manipulation
    {
        public static string ImageToBinary(string imagePath)
        {
            // Membaca gambar
            Bitmap img = new Bitmap(imagePath);
            img = CropImageContiguous(img);

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

        // public static string ImageToBinaryBitmap(Bitmap img)
        // {
        //     img = CropImageContiguous(img);
            
        //     // Konversi gambar ke grayscale
        //     Bitmap grayscaleImg = ConvertToGrayscale(img);

        //     // Mengubah gambar menjadi string biner
        //     string binaryString = "";

        //     for (int y = 0; y < grayscaleImg.Height; y++)
        //     {
        //         for (int x = 0; x < grayscaleImg.Width; x++)
        //         {
        //             Color pixelColor = grayscaleImg.GetPixel(x, y);
        //             int grayscaleValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11); // Nilai grayscale

        //             // Mengubah nilai piksel menjadi 0 atau 1 (binary) berdasarkan threshold
        //             int threshold = 128;
        //             binaryString += grayscaleValue > threshold ? "1" : "0";
        //         }
        //     }

        //     return binaryString;
        // }

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
                MessageBox.Show("test");
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

        // Memotong 30 pixel kontigu di tengah
        public static Bitmap CropImageContiguous(Bitmap bitmap) {
            int centerX = bitmap.Width / 2;
            int centerY = bitmap.Height / 2;

            int cropWidth = 30;
            int cropHeight = 1;
            Rectangle cropRect = new Rectangle(centerX, centerY, cropWidth, cropHeight);

            Bitmap croppedBitmap = bitmap.Clone(cropRect, bitmap.PixelFormat);

            return croppedBitmap;
        }

        //INI FUNGSI BUAT LOAD IMAGE DARI PATH DARI HASIL DATABASE
        public static Bitmap loadImage(string path)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            DirectoryInfo parentDirectory = directoryInfo.Parent.Parent.Parent.Parent.Parent;
            string desiredDirectory = parentDirectory.FullName;
            string finalPath = Path.Combine(desiredDirectory, path);

            if (File.Exists(finalPath))
            {
                return new Bitmap(finalPath);
            }
            else
            {
                throw new FileNotFoundException("Image not found at path: " + finalPath);
            }
        }

        public static void testShowMessageBox() {
            MessageBox.Show("test");
        }
    }

    public class BoyerMoore
    {
        // Fungsi untuk membangun array last yang menyimpan posisi terakhir kemunculan setiap karakter dalam pattern
        private static int[] BuildLast(string pattern)
        {
            int[] last = new int[256]; // Menggunakan 256 untuk semua karakter ASCII
            for (int k = 0; k < 256; k++)
                last[k] = -1; // Inisialisasi semua karakter ke -1
            for (int k = 0; k < pattern.Length; k++)
                last[pattern[k]] = k; // Set posisi terakhir kemunculan karakter
            return last;
        }

        public static int BmMatch(string text, string pattern)
        {
            int[] last = BuildLast(pattern);
            int n = text.Length;
            int m = pattern.Length;
            int i = m - 1;

            if (i > n - 1)
                return -1; // tidak ada kecocokan jika pola lebih panjang dari teks

            int j = m - 1;

            do
            {
                if (pattern[j] == text[i])
                {
                    if (j == 0)
                        return i; // kecocokan ditemukan
                    else
                    {
                        // teknik looking-glass
                        i--;
                        j--;
                    }
                }
                else
                {
                    // teknik character jump
                    int lo = last[text[i]]; // posisi terakhir kemunculan karakter pada pattern
                    i = i + m - Math.Min(j, 1 + lo);
                    j = m - 1;
                }
            } while (i <= n - 1);

            return -1; // tidak ada kecocokan
        }
    }


    public class KMP
    {
        public static int KmpMatch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;
            int[] b = ComputeBorder(pattern);
            int i = 0; // indeks pada text
            int j = 0; // indeks pada pattern

            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    if (j == m - 1)
                        return i - m + 1; // match ditemukan
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = b[j - 1];
                }
                else
                {
                    i++;
                }
            }

            return -1; // tidak ada kecocokan
        }

        public static int[] ComputeBorder(string pattern)
        {
            int m = pattern.Length;
            int[] b = new int[m];
            b[0] = 0;
            int j = 0;
            int i = 1;

            while (i < m)
            {
                if (pattern[i] == pattern[j])
                {
                    j++;
                    b[i] = j;
                    i++;
                }
                else
                {
                    if (j > 0)
                    {
                        j = b[j - 1];
                    }
                    else
                    {
                        b[i] = 0;
                        i++;
                    }
                }
            }

            return b;
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


    //public static void Main(string[] args)
    //{
      //  string text = "Halo Dunia";
        //string pattern = "Dunia";

       // int result = BmMatch(text, pattern);
       // int result = KmpMatch(text,pattern);
       // if (result != -1)
        //    Console.WriteLine("Pattern ditemukan pada indeks: " + result);
        // else
          //  Console.WriteLine("Pattern tidak ditemukan.");
    }

