using System;
using System.Collections.Generic;
using System.Text;

namespace CalculLab3
{
    class SimpleCalc
    {
        public double leftNumber = 0;
        public double rightNumber = 0;
        public string calcOperator = "+";
        public double calcResult = 0;
        public bool LeftNumber()
        {
            bool result = true;
            while (1 > 0)
            {
                Console.WriteLine("Ввести первое число");
                try
                {
                    leftNumber = double.Parse(Console.ReadLine());
                    break;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message + ": Ввести первое число цифрами");
                    result = false;
                }
            }
            return result;
        }
        public bool RightNumber()
        {
            bool result = true;
            while (1 > 0)
            {
                Console.WriteLine("Ввести второе число");
                try
                {
                    rightNumber = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + ": Ввести второе число цифрами");
                    result = false;
                }
            }
            return result;
        }
        public bool CalcOperator()
        {
            bool result = false;
            while (1 > 0)
            {
                Console.WriteLine("Выбрать действие:  + - / *");

                calcOperator = Console.ReadLine();
                switch (calcOperator)
                {
                    case "+":
                        result = true;
                        break;
                    case "-":
                        result = true;
                        break;
                    case "/":
                        result = true;
                        break;
                    case "*":
                        result = true;
                        break;
                }
                if (result == true) break;
            }
            return result;
        }
        public bool CalcResult()
        {
            bool result = true;

            try
            {
                switch (calcOperator)
                {
                    case "+":
                        calcResult = leftNumber + rightNumber;
                        Console.WriteLine("Результат сложения: {0}", calcResult.ToString());
                        break;
                    case "-":
                        calcResult = leftNumber - rightNumber;
                        Console.WriteLine("Результат вычитания: {0}", calcResult.ToString());
                        break;
                    case "/":
                        calcResult = leftNumber / rightNumber;
                        Console.WriteLine("Результат деления: {0}", calcResult.ToString());
                        break;
                    case "*":
                        calcResult = leftNumber * rightNumber;
                        Console.WriteLine("Результат умножения: {0}", calcResult.ToString());
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }

            return result;
        }
    }
}