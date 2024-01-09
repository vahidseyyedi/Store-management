using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LG.Class
{
    internal class Calculator
    {
        public static int calc_discount(int number, int price, int discount)
        {
            int a = 0;
            a = number * price * (100 - discount) / 100;
            return a;
        }

        public static int calc_tax(int sum, int tax)
        {
            int a = 0;
            a = sum + (int)(tax * sum / 100.0);
            return a;
        }
    }
}
