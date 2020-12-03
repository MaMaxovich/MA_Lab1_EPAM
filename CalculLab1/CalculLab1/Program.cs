using System;

namespace CalculLab1
{
    class Program
    {
        static void Main()
        {
            string res;
            int a = 0;
            int b = 0;
            Class1 myclass;

            Console.WriteLine("Скоро ли пятница?");
            link1:
            Console.WriteLine("Введите текущий день недели\n пн или 1\t понедельник\n вт или 2\t вторник\n ср или 3\t среда\n чт или 4\t четверг\n пт или 5\t пятница\n сб или 6\t суббота\n вс или 7\t воскресение\n ");
            myclass = new Class1();
            res = myclass.Maim1();
            if (res == "пн" || res == "1")
            { a = 1; }
            else if (res == "вт" || res == "2")
            { a = 2; }
            else if (res == "ср" || res == "3")
            { a = 3; }
            else if (res == "чт" || res == "4")
            { a = 4; }
            else if (res == "пт" || res == "5")
            { a = 5; }
            else if (res == "сб" || res == "6")
            { a = 6; }
            else if (res == "вс" || res == "7")
            { a = 7; }
            else
            { goto link1; }
            if (5 - a > 0)
            {
                b = 5 - a;
                Console.WriteLine("Пятница скоро через {0} дней", b); }
            else if (a - 5 > 0)
            {
                b = a - 5; Console.WriteLine("Пятница на следующей неделе через {0} дней", 7 - b); }
            else
            { Console.WriteLine("Пятница сегодня!");
            }

            Class1.Maim2();
        }
        
    }
}
