﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugwine
{
    public class Square : Shape
    {
        public Square(string name, int area) : base(name, area)
        {
        }

        public Square(string name, int area, IPricer pricer) : base(name, area, pricer)
        {
        }

    }
}
