using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tutorial_01;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MultiplicationTest()
        {
            // Create an instance to test:
            Calculator calculator = new Calculator();

            // Define a test input and output value:
            double expectedResult = 2;
            double input1 = 1;
            double input2 = 2;


            // Run the method under test:
            double actualResult = calculator.multiplication(input1, input2);

            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DivisionTest()
        {
            // Create an instance to test:
            Calculator calculator = new Calculator();

            // Define a test input and output value:
            double expectedResult = 2;
            double input1 = 2;
            double input2 = 1;


            // Run the method under test:
            double actualResult = calculator.division(input1, input2);

            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DivisionZeroTest()
        {
            // Create an instance to test:
            Calculator calculator = new Calculator();

            // Define a test input value:
            double input1 = 2;
            double input2 = 0;

            // Verify the result:
            Assert.ThrowsException<DivideByZeroException>(() => calculator.division(input1, input2));
        }

        [TestMethod]
        public void DivisionNegativeTest()
        {
            // Create an instance to test:
            Calculator calculator = new Calculator();

            // Define a test input value:
            double input1 = 2;
            double input2 = -9999;

            // Verify the result:
            Assert.ThrowsException<NotSupportedException>(() => calculator.division(input1, input2));
        }

        [TestMethod]
        public void TestProxy()
        {
            Proxy calculator = new Proxy();
            Console.WriteLine(calculator.GetQueue().Count);
            var result = calculator.multiplication(3, 2);
            // Verify the result:
            Assert.AreEqual(6, result);
            Console.WriteLine(calculator.GetQueue().Count);

            //_queue.Enqueue(new Calculation(OperationType.Multiplication, 3, 2, 6));

            //var result = new Calculator().multiplication(3, 2);
            //var head = _queue.First();
            //Assert.Equals(OperationType.Multiplication, head.Type);
            //Assert.Equals(3, head.Input1);
            //Assert.Equals(2, head.Input2);
            //Assert.Equals(6, head.Result);

            //head.Result = 42;
            //_queue.Clear();
            //_queue.Enqueue(head);
            //result = new Calculator().multiplication(3, 2);
            //Assert.Equals(42, result);
        }
    }
}
