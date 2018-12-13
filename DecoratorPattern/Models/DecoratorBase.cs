using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorPattern.Models
{
    public class DecoratorBase : IPhoto
    {
        private IPhoto photo;

        public DecoratorBase(IPhoto photo)
        {
            this.photo = photo;
        }

        public virtual Bitmap GetPhoto()
        {
            return photo.GetPhoto();
        }
    }
}
