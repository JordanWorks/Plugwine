using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugwine
{
    public class OtherPricer : IPricer
    {
        public int Price(int area)
        {
            return area * 4;
        }
    }
}
