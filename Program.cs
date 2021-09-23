using System;

namespace Calculator
{
    class Calculator
    {
        public string str;
        public string[] numbers;
        public double num1;
        public double num2;
        public char symbol;
        public Calculator(string str)
        {
            this.str = str;
            try
            {
                ErrorHunt();
                GetResult();
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
        public void ErrorHunt()
        {
            var symbols = new char[] { '*', '+', '/', '-' };
            foreach (var item in symbols)
            {
                int LENGTH = str.Length - 1;
                if (str[0] == item)
                {
                    str = str.Substring(1, LENGTH);
                    LENGTH = str.Length - 1;
                }
                if (str[LENGTH] == item)
                {
                    str = str.Substring(0, LENGTH);
                }
            }
            foreach (var item in symbols)
            {
                if (str.Contains(item))
                {
                    numbers = str.Split(item);
                    symbol = item;
                }
            }
            if (numbers.Length == 0) throw new Exception("there are no symbols");
            if (!double.TryParse(numbers[0], out num1) || !double.TryParse(numbers[1], out num2))
            {
                throw new Exception("incorrect numbers");
            }
        }
        public void GetResult()
        {
            double value=0;
            switch (symbol) {
                case '+': value = num1 + num2;break;
                case '-': value = num1 - num2; break;
                case '*': value = num1 * num2; break;
                case '/': value = num1 / num2; break;
            }
            Console.WriteLine(value);
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("welcome to calculator");
            void RunCalculator()
            {
                new Calculator(Console.ReadLine());
                RunCalculator();
            }
            RunCalculator();
        }
    }
}
