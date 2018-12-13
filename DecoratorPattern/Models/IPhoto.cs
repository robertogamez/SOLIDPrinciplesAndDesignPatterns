﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorPattern.Models
{
    public interface IPhoto
    {
        Bitmap GetPhoto();
    }
}
