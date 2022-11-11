using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_01
{
    public class Calculator:ICalculator
    {
        private Calculator @object;

        static void Main(string[] args)
        {
        }

        public Calculator()
        {
        }

        public Calculator(Calculator @object)
        {
            this.@object = @object;
        }

        /* Step 2*/
        public double multiplication(double input1, double input2)
        {
            return input1*input2;
        }

        /* Task 3*/
        public virtual double division(double input1, double input2)
        {
            if (input2 == 0)
            {
                throw new DivideByZeroException();
            }
            else if (input2 == -9999)
            {
                throw new NotSupportedException();
            }
            else
            {
                return input1 / input2;
            }
        }

    }
}
