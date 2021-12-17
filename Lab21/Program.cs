using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину сада.");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ширину сада.");
            int length = Convert.ToInt32(Console.ReadLine());
            int[,] field = new int[length, width];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    field[i, j] = 0;
                    Console.Write("{0,3}", field[i, j]);
                }
            }
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(Gardener2);
            Thread thread = new Thread(threadStart);
            thread.Start(field);
            Gardener1(field);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("{0,3}", field[i, j]);
                }
            }
            Console.ReadKey();
        }
        static void Gardener1(object myFieldAsObject)
        {
            int[,] myField = (int[,])myFieldAsObject;
            for (int i = 0; i < myField.GetLength(0); i++)
            {
                for (int j = 0; j < myField.GetLength(1); j++)
                {
                    if (myField[i, j] == 0)
                    {
                        myField[i, j] = 1;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void Gardener2(object myFieldAsObject)
        {
            int[,] myField = (int[,])myFieldAsObject;
            for (int i = myField.GetLength(1) - 1; i >= 0; i--)
            {
                for (int j = myField.GetLength(0) - 1; j >= 0; j--)
                {
                    if (myField[j, i] == 0)
                    {
                        myField[j, i] = 2;
                    }
                    Thread.Sleep(1);
                }
            }
        }
    }
}
