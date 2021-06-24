using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using static Prysm.Pym;
//using System.Globalization;

namespace ImageFilters
{
  class Program
  {
    static void Main(string[] args)
    {
      Initialize();
      try
      {
        Bitmap bmp = null;
        Bitmap newBmp = null;
        string filename = "bmp.bmp";
        bmp = (Bitmap)Image.FromFile(filename);
        newBmp = InvertColor(bmp);
        newBmp.Save("bmp2.bmp");
        newBmp = Greyscale(bmp);
        newBmp.Save("bmp3.bmp");
      }
      catch (System.Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
    public static Bitmap InvertColor(Bitmap scrBitmap)
    {
      Color actualColor;
      Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
      for (int i = 0; i < scrBitmap.Width; i++)
      {
        for (int j = 0; j < scrBitmap.Height; j++)
        {
          actualColor = scrBitmap.GetPixel(i, j);
          Color invertedColor = Color.FromArgb(255 - actualColor.R, 255 - actualColor.G, 255 - actualColor.B);
          newBitmap.SetPixel(i, j, invertedColor);
        }
      }
      return newBitmap;
    }
    public static Bitmap Greyscale(Bitmap scrBitmap)
    {
      Color actualColor;
      Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
      for (int i = 0; i < scrBitmap.Width; i++)
      {
        for (int j = 0; j < scrBitmap.Height; j++)
        {
          actualColor = scrBitmap.GetPixel(i, j);
          int num = (actualColor.R + actualColor.G + actualColor.B) / 3;
          Color invertedColor = Color.FromArgb(num, num, num);
          newBitmap.SetPixel(i, j, invertedColor);
        }
      }
      return newBitmap;
    }
  }
}