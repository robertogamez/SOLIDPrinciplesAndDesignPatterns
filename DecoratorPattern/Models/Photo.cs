using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorPattern.Models
{
    public class Photo : IPhoto
    {
        private string fileName;

        public Photo(string filename)
        {
            this.fileName = filename;
        }

        public Bitmap GetPhoto()
        {
            Bitmap bmp = (Bitmap)Image.FromFile(fileName);
            return bmp;
        }
    }
}
