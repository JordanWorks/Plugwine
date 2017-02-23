using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugwine
{
    public class Service
    {
        public Shape parseUserInput(string input)
        {
            //We split the input using space as delimiter
            String[] substrings = input.Split(' ');

            //We do a switch on the type of Shape (Triangle | Square | Circle)
            switch (substrings[0])
            {
                //If it's a circle
                case "Circle":
                    //We return a new circle based on parameters passed through the user input
                    return new Circle(substrings[1], int.Parse(substrings[2]));
                //If it's a triangle
                case "Triangle":
                    //We return a new circle based on parameters passed through the user input
                    return new Triangle(substrings[1], int.Parse(substrings[2]));
                //if it's a square
                case "Square":
                    //We return a new circle based on parameters passed through the user input
                    return new Square(substrings[1], int.Parse(substrings[2]));
                default:
                    return null;
            }
        }

        public void saveInJsonFile(List<Shape> listOfShapes)
        {
            //We serialize our shapes into Json format
            string output = JsonConvert.SerializeObject(listOfShapes);
            //We define our path. The file is stored in the bin/debug of the plugwine solution folder
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "collections.json");
            //We write the json file,  
            File.WriteAllText(path, output);
        }
    }
}
