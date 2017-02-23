using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plugwine;
using System.Collections.Generic;
using System.IO;

namespace PlugwineTests
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        //We test the instantiation of a square
        public void TestSquareConstructor()
        {
            Shape square = new Square("Square", 72);
            Assert.AreEqual("Square", square.Name);
            Assert.AreEqual(72, square.Area);
        }

        [TestMethod]
        //We test the instantiation of a triangle
        public void TestTriangleConstructor()
        {
            Shape triangle = new Triangle("Triangle", 111);
            Assert.AreEqual("Triangle", triangle.Name);
            Assert.AreEqual(111, triangle.Area);
        }

        [TestMethod]
        //We test the instantiation of a circle
        public void TestCircleConstructor()
        {
            Shape circle = new Circle("Circle", 97);
            Assert.AreEqual("Circle", circle.Name);
            Assert.AreEqual(97, circle.Area);
        }


        [TestMethod]
        //We test that the display of a square is correct according to the question 1
        public void TestIfTheDisplayOfASquareIsOk()
        {
            Shape square = new Square("Square1", 12);
            Assert.AreEqual("Square - Square1 - 12 cm²", square.displayShape());
        }

        [TestMethod]
        //We test that the display of a triangle is correct according to the question 1
        public void TestIfTheDisplayOfATriangleIsOk()
        {
            Shape triangle = new Triangle("Triangle1", 24);
            Assert.AreEqual("Triangle - Triangle1 - 24 cm²", triangle.displayShape());
        }

        [TestMethod]
        //We test that the display of a circle is correct according to the question 1
        public void TestIfTheDisplayOfACircleIsOk()
        {
            Shape circle = new Circle("Circle1", 6);
            Assert.AreEqual("Circle - Circle1 - 6 cm²", circle.displayShape());
        }

        [TestMethod]
        //We test that the parseUserInput method of the Service is working by creating
        //a new shape. This is the answer to the question 2.
        public void TestInputUserConcerningCircleCreation()
        {
            Service service = new Service();
            String input = "Circle MonNom 10";
            Shape shape = service.parseUserInput(input);
            Assert.AreEqual("Circle - MonNom - 10 cm²", shape.displayShape());
        }

        [TestMethod]
        //We test that the parseUserInput method of the Service is working by creating
        //a new shape. This is the answer to the question 2.
        public void TestInputUserConcerningSquareCreation()
        {
            Service service = new Service();
            String input = "Square Square1 20";
            Shape shape = service.parseUserInput(input);
            Assert.AreEqual("Square - Square1 - 20 cm²", shape.displayShape());
        }

        [TestMethod]
        //We test that the parseUserInput method of the Service is working by creating
        //a new shape. This is the answer to the question 2.
        public void TestInputUserConcerningTriangleCreation()
        {
            Service service = new Service();
            String input = "Triangle Triangle1 15";
            Shape shape = service.parseUserInput(input);
            Assert.AreEqual("Triangle - Triangle1 - 15 cm²", shape.displayShape());
        }

        [TestMethod]
        //We test that the saveInJsonFile method of the service is working
        public void TestTheSaveInJsonFile()
        {
            List<Shape> listOfShapes = new List<Shape>();
            Service service = new Service();
            String input = "Circle MonNom 10";
            listOfShapes.Add(service.parseUserInput(input));
            service.saveInJsonFile(listOfShapes);
            //The path where the collections.json is supposed to be created
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "collections.json");
            //We check that the file exists in the path we define previously
            Assert.IsTrue(File.Exists(path));
            //For information you can see it at PlugwineSolution\PlugwineTests\bin\Debug folder
        }

        [TestMethod]
        //We test that the price method of the Pricer Class we have to implement
        //is working well. It is the answer to the question 4.
        public void TestThePriceMethodOfPricerClass()
        {
            IPricer pricer = new Pricer();
            Shape square = new Square("Square1", 12);
            Assert.AreEqual(24, pricer.Price(square.Area));
        }

        [TestMethod]
        //We test that the display of the cost of a shape is working well. 
        //It is the answer to the question 4.
        public void TestTheDisplayCostOfShapeMethodUsingPriceClass()
        {
            IPricer pricer = new Pricer();
            Shape square = new Square("Square1", 12, pricer);
            Assert.AreEqual("Square - Square1 - 12 cm² - Estimation coût : 24€", square.displayCostOfShape());
        }

        //We test that the price method of the OtherPricer Class we have to implement
        //is working well. It is the answer to the question 5.
        [TestMethod]
        public void TestThePriceMethodOfOtherPricerClass()
        {
            IPricer pricer = new OtherPricer();
            Shape square = new Square("Square1", 12);
            Assert.AreEqual(48, pricer.Price(square.Area));
        }

        //We test that the display of the cost of a shape is working well with another
        //type of Pricer. It is the answer to the question 5.
        [TestMethod]
        public void TestTheDisplayCostOfShapeMethodUsingOtherPricerClass()
        {
            IPricer pricer = new OtherPricer();
            Shape square = new Square("Square1", 12, pricer);
            Assert.AreEqual("Square - Square1 - 12 cm² - Estimation coût : 48€", square.displayCostOfShape());
        }

    }
}
