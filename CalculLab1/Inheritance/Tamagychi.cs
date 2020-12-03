using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    internal class Tamagychi : Gadjet
    {
        private int weight;
        public int Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }
        public void Feed()
        {
            weight += 2;
            Console.WriteLine("Теперь мой вес {0}, Спасибо!", weight);
        }

        public override void ShowScreen()
        {
            Console.WriteLine("Меня зовут {0}\n Мой размер: {1}x{2}\n Моя операционная система {3}\n Мой вес {4} Покормите меня пожалуйста!", Name, Lenght, Width, OS, Weight);
        }
        public override bool Equals(object obj)
        {
            bool result = true;

            Tamagychi o = obj as Tamagychi;
            if (o.Lenght != Lenght) result = false;
            if (o.Weight != Weight) result = false;
            if (o.Width != Width) result = false;

            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
