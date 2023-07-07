using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Business
{
    public class Calculator 
    {
           
        public float Add(float num1, float num2)
        {
            return num1 + num2;
        }

        public float Divide(float num1, float num2)
        {
            if (num2==0)
            {
                throw new Exception("Cant Divide By Zero");
            }
            return num1 / num2;
        }

        public float Multiply(float num1, float num2)
        {
            return num1 * num2;
        }

        public float Subtract(float num1, float num2)
        {
            return num1 - num2;
        }
    }
}
