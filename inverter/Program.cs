using System;
using System.IO;
using System.Drawing;

namespace inverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to your file (must be png file): ");
            string path;
            do
            {
                path = GetPath();
            } while (path == null);
            Image temp = Image.FromFile(path);
            Bitmap bmp = new Bitmap(temp);
            temp.Dispose();
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    bmp.SetPixel(x, y, Color.FromArgb(255-bmp.GetPixel(x,y).R, 255 - bmp.GetPixel(x, y).G, 255 - bmp.GetPixel(x, y).B));
                }
            }
            bmp.Save(path);
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
        static string GetPath()
        {
            string path = Console.ReadLine();
            if (File.Exists(path)) { return path; } else { Console.WriteLine("Search for file in dir: {0} was unsuccessful. Try again."); return null; }
        }
    }
}
