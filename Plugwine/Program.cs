using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugwine
{
    class Program
    {
        static void Main(string[] args)
        {

            //We initialize one pricer and three shapes
            IPricer pricer = new Pricer();
            Shape circle1 = new Circle("Nom1", 12, pricer);
            Shape circle2 = new Circle("Nom2", 15, pricer);
            Shape triangle = new Triangle("Nom3", 16, pricer);

            //We add the shapes into a list
            List<Shape> shapes = new List<Shape>();
            shapes.Add(circle1);
            shapes.Add(circle2);
            shapes.Add(triangle);

            //We use a service for save our shapes in collections.json
            Service service = new Service();
            service.saveInJsonFile(shapes);
            //For information you can see it at PlugwineSolution\PlugwineConsoleApplication\bin\Debug folder

            //We have to write this code to display the '€' character in the console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //We want to verify if the code (question 4) is working
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.displayCostOfShape());
            }

            //This code is written to prevent the console from closing
            Console.ReadKey();

        }
    }
}
