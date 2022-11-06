namespace CalculatorNS
{
    public class Calculator
    {
        private ICalculator memory;
        public Calculator(ICalculator result) {
            this.memory = result;
        }
        public int Multiplication(int val1, int val2) {
            int result = val1 * val2;
            memory.SetResult(result);
            return result;
        }

        public Decimal Division(int val1, int val2) {
            Decimal result = 0;
            try
            {
                result = (Decimal)val1 / val2;
                memory.SetResult(result);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public bool WriteToFile(string path) {
            try
            {
                File.WriteAllText(path, memory.GetResult().ToString());
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool MultiplyThenWriteToFile(int val1, int val2, string path)
        {
            Multiplication(val1, val2);
            return WriteToFile("test.txt");
        }

        public static void Main()
        {
            Console.WriteLine("Hello world");
        }
    }

}

