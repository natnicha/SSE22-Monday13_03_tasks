namespace CalculatorNS
{
    public class Calculator
    {
        public Calculator() {}

        public int Multiplication(int val1, int val2)
        {
            return val1*val2;
        }

        public Decimal Division(int val1, int val2) { 
            return (Decimal)val1/val2;
        }
        public static void Main()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

