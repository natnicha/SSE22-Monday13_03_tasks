namespace CalculatorTests;
using CalculatorNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class Tests
{
    [Test]
    public void TestMultiplication_when5x5_shouldReturn25 ()
    {
        Calculator calclator = new Calculator();
        int result = calclator.Multiplication(5, 5);
        Assert.AreEqual(25, result);
    }

    [Test]
    public void TestMultiplication_when0x5_shouldReturn0 ()
    {
        Calculator calclator = new Calculator();
        int result = calclator.Multiplication(0, 5);
        Assert.AreEqual(0, result);
    }

    [Test]
    public void TestMultiplication_when_1x5_shouldReturn_5()
    {
        Calculator calclator = new Calculator();
        int result = calclator.Multiplication(-1, 5);
        Assert.AreEqual(-5, result);
    }

    [Test]
    public void TestMultiplication_when7x_9_shouldReturn72()
    {
        Calculator calclator = new Calculator();
        int result = calclator.Multiplication(7, -9);
        Assert.AreEqual(-63, result);
    }

    [Test]
    public void TestMultiplication_when_10x_19_shouldReturn190()
    {
        Calculator calclator = new Calculator();
        int result = calclator.Multiplication(-10, -19);
        Assert.AreEqual(190, result);
    }

    [Test]
    public void TestDivision_when14d7_shouldReturn2() {
        Calculator calclator = new Calculator();
        Decimal result = calclator.Division(14, 7);
        Assert.AreEqual(2, result);
    }

    [Test]
    public void TestDivision_when22d4_shouldReturn5_5()
    {
        Calculator calclator = new Calculator();
        Decimal result = calclator.Division(22, 4);
        Assert.AreEqual((Decimal)5.5, result);
    }

    [Test]
    public void TestDivision_when1d20_shouldReturn0_05()
    {
        Calculator calclator = new Calculator();
        Decimal result = calclator.Division(1, 20);
        Assert.AreEqual((Decimal)0.05, result);
    }

    [Test]
    [ExpectedException(typeof(DivideByZeroException))]
    public void TestDivision_when1d0_shouldReturnError()
    {
        Calculator calclator = new Calculator();
        Decimal result = calclator.Division(1, 20);
    }

    [Test]
    public void TestDivision_when9999d_9999_shouldReturn()
    {
        Calculator calclator = new Calculator();
        Decimal result = calclator.Division(9999, -9999);
        Assert.AreEqual(-(Decimal)1, result);
    }
}