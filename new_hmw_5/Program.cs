using System;
using System.Net.NetworkInformation;
using System.Numerics;

struct Program
{

    static void print(int[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int[,] Multiply(int[,] a, int[,] b)
    {

        int[,] c = new int[a.GetLength(0), b.GetLength(1)];
        if(a.GetLength(1) != b.GetLength(0) )
        {
            throw new ArgumentException("Несовместимые размеры матриц.");
        }
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                c[i, j] = 0;
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    c[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return c;




        static void Main()
        {
            int[,] a = { { 1, 2 }, { 3, 4 } };
            int[,] b = { { 5, 6 }, { 7, 8 } };

            int[,] c = Multiply(a, b);
            print(c);
        }
    }
}