namespace CalculatorTests;
using CalculatorNS;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;
using System.Xml.Linq;

public class Tests
{
    [Test]
    public void TestMultiplication_when5x5_shouldReturn25 ()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        int result = calclator.Multiplication(5, 5);
        Assert.AreEqual(25, result);
    }

    [Test]
    public void TestMultiplication_when0x5_shouldReturn0 ()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        int result = calclator.Multiplication(0, 5);
        Assert.AreEqual(0, result);
    }

    [Test]
    public void TestMultiplication_when_1x5_shouldReturn_5()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        int result = calclator.Multiplication(-1, 5);
        Assert.AreEqual(-5, result);
    }

    [Test]
    public void TestMultiplication_when7x_9_shouldReturn72()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        int result = calclator.Multiplication(7, -9);
        Assert.AreEqual(-63, result);
    }

    [Test]
    public void TestMultiplication_when_10x_19_shouldReturn190()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        int result = calclator.Multiplication(-10, -19);
        Assert.AreEqual(190, result);
    }

    [Test]
    public void TestDivision_when14d7_shouldReturn2()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        Decimal result = calclator.Division(14, 7);
        Assert.AreEqual(2, result);
    }

    [Test]
    public void TestDivision_when22d4_shouldReturn5_5()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        Decimal result = calclator.Division(22, 4);
        Assert.AreEqual((Decimal)5.5, result);
    }

    [Test]
    public void TestDivision_when1d20_shouldReturn0_05()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        Decimal result = calclator.Division(1, 20);
        Assert.AreEqual((Decimal)0.05, result);
    }

    [Test]
    public void TestDivision_when1d0_shouldReturnError()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        try
        {
            Decimal result = calclator.Division(1, 0);
        }
        catch (Exception e)
        {
            Assert.IsTrue(e is System.DivideByZeroException);
        }
    }

    [Test]
    public void TestDivision_when9999d_9999_shouldReturn_1()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        Decimal result = calclator.Division(9999, -9999);
        Assert.AreEqual(-(Decimal)1, result);
    }

    [Test]
    public void TestWriteFile_whenPathIsValid_shouldReturnTrue()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        bool isSuccess = calclator.WriteToFile("test.txt");
        Assert.IsTrue(isSuccess);

        File.Delete("test.txt");

    }
    
    [Test]
    public void TestWriteFile_whenFileExist_shouldReturnTrue()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        bool isSuccess1 = calclator.WriteToFile("test.txt");
        bool isSuccess2 = calclator.WriteToFile("test.txt");
        Assert.IsTrue(isSuccess1);
        Assert.IsTrue(isSuccess2);
        File.Delete("test.txt");
    }

    
    [Test]
    public void TestWriteFile_whenPathIsValid_shouldSuccess()
    {
        Mock<ICalculator> calclatorMock = new Mock<ICalculator>();
        calclatorMock.Setup(x => x.GetResult()).Returns(2);
        calclatorMock.Setup(x => x.SetResult(It.IsAny<Decimal>()));
        Calculator calclator = new Calculator(calclatorMock.Object);
        calclatorMock.CallBase = true;
        calclatorMock.Setup(x => x.GetResult()).Returns(2);

        bool isSuccess = calclator.MultiplyThenWriteToFile(1, 2, "test.txt");
        Assert.AreEqual(true, isSuccess);
        File.Delete("test.txt");
    }
}