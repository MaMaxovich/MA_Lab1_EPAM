using System;

namespace CalculLab3
{
    class CalculLab3
    {
        static void Main(string[] args)
        {
            bool result = false;
            SimpleCalc c = new SimpleCalc();

            while (result == false)
            {
                c.LeftNumber();
                c.RightNumber();
                c.CalcOperator();
                result= c.CalcResult();
            }
        }
    }
}
                    