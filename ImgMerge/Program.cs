using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImgMerge
{

    class ImageMerge
    {
        public static void Merge(string imageFN, string backgroundFN, string outputFN)
        {
            var image = new Bitmap(imageFN);
            var background = new Bitmap(backgroundFN);

            using (Graphics graphics = Graphics.FromImage(background))
            {
                var x = (background.Width / 2) - (image.Width / 2);
                var y = (background.Height / 2) - (image.Height / 2);

                graphics.DrawImage(image, x, y, image.Width, image.Height);

            }
            background.Save(outputFN + ".png", ImageFormat.Png);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                System.Console.WriteLine("Useage: image backgroundimage result");
            }
            else
            {
                ImageMerge.Merge(args[0], args[1], args[2]);
            }
        }
    }
}
