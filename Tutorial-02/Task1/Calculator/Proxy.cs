using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_01
{
    public class Proxy : ICalculator
    {
        public enum OperationType
        {
            Multiplication, Division
        }

        public struct Calculation
        {
            public OperationType Type;
            public double Input1;
            public double Input2;
            public double Result;

            public Calculation(OperationType type, double input1, double input2, double result)
            {
                Type = type;
                Input1 = input1;
                Input2 = input2;
                Result = result;
            }
        }

        Queue<Calculation> _queue = new Queue<Calculation>(10);

        public Queue<Calculation> GetQueue()
        {
            return _queue;
        }

        private double? FromCache(OperationType op, double input1, double input2)
        {
            foreach (var q in _queue)
            {
                if (q.Type == op && q.Input1 == input1 && q.Input2 == input2)
                {
                    return q.Result;
                }
            }

            return null;
        }
        
        public double multiplication(double input1, double input2)
        {
            double? result = FromCache(OperationType.Multiplication, input1, input2);
            if (result == null)
            {
                ICalculator calculator = new Calculator();
                result = calculator.multiplication(input1, input2);
                _queue.Enqueue(new Calculation(OperationType.Multiplication, input1, input2, (double)result));
            }
            // return directly if result isn't null 
            return (double)result;
        }

        public double division(double input1, double input2)
        {
            double? result = FromCache(OperationType.Division, input1, input2);
            if (result == null)
            {
                ICalculator calculator = new Calculator();
                result = calculator.division(input1, input2);
                _queue.Enqueue(new Calculation(OperationType.Division, input1, input2, (double)result));
            }
            // return directly if result isn't null 
            return (double)result;
        }
    }
}
