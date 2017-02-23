using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugwine
{
    public class Shape
    {
        public string Name { get; private set; }
        public int Area { get; private set; }
        public int Price { get; private set; }
        public IPricer Pricer;

        public Shape(string name, int area)
        {
            this.Name = name;
            this.Area = area;
        }

        public Shape(string name, int area, IPricer pricer)
        {
            this.Name = name;
            this.Area = area;
            this.Pricer = pricer;
        }

        public string displayShape()
        {
            //We use this.GetType().Name for get the name of the shape (ie : Triangle or Square or Circle)
            return this.GetType().Name + " - " + this.Name + " - " + this.Area + " cm²";
        }

        public string displayCostOfShape()
        {
            return this.GetType().Name + " - " + this.Name + " - " + this.Area + " cm² - Estimation coût : " + this.Pricer.Price(this.Area) + "€";
        }
    }
}
