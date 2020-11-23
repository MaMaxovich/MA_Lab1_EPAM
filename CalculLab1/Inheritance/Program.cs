using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Iphone iphone = new Iphone
            {
                Name = "Мой IPhone 12PRO",
                Lenght = 12,
                Width = 6,
                OS = "IOS 14"
            };
            iphone.ShowScreen();
            Console.WriteLine(iphone.ToString());
            Console.ReadLine();

            Tamagychi pet = new Tamagychi
            {
                Name = "Тузик",
                Lenght = 4,
                Width = 4,
                OS = "TamagOS"
            };
            pet.ShowScreen();
            pet.Feed();
            pet.Feed();
            pet.Feed();
            Console.ReadLine();

            Tamagychi petClone = new Tamagychi
            {
                Name = "Тузик",
                Lenght = 5,
                Width = 4,
                OS = "TamagOS"
            };
            Console.WriteLine("{0} и его клон {1}", pet.Name, pet.Equals(petClone) ? "равны": "не равны") ;

            petClone.Lenght = 4;
            petClone.Feed();
            petClone.Feed();
            petClone.Feed();


            Console.WriteLine("{0} и его клон {1}", pet.Name, pet.Equals(petClone) ? "равны" : "не равны");

        }
    }
}
