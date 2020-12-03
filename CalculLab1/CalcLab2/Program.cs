using System;

namespace CalcLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i, j, temp = 0;
            int[] arr;

            Console.Write("Введите число элементов массива: ");
            n = int.Parse(Console.ReadLine());
            if (n == 100)
            {
                arr = new int[5];
                arr[0] = 23;
                arr[1] = 55;
                arr[2] = 62;
                arr[3] = 84;
                arr[4] = 73;
                for (i = 0; i < arr.Length - 1; i++)
                {
                    for (j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        };
                    };
                }
                for (i = 0; i < arr.Length; i++)
                {
                    Console.Write("arr[{0}] \n", arr[i]);
                }
            }
            else
            {
                arr = new int[n];
                for (i = 0; i < arr.Length; i++)
                {
                    Console.Write("Введите arr[{0}] ", i);
                    arr[i] = int.Parse(Console.ReadLine());
                 }
                for (i = 0; i < arr.Length - 1; i++)
                {
                    for (j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
                for (i = 0; i < arr.Length; i++)
                {
                    Console.Write("arr[{0}] \n", arr[i]);
                }
            }
         }
    }
}
