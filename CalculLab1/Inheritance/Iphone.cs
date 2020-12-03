using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Iphone : Gadjet
    {
        public override void ShowScreen()
        {
            Console.WriteLine("Я {0}\n Размером: {1}x{2} см\n С последней версией операционки!", Name, Lenght, Width);
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return String.Format("Название: {0}\n Размер: {1}x{2} см\n Установлена операционная система {3}", Name, Lenght, Width, OS);
        }
    }
}
