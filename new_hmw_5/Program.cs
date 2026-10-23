using System;
using System.Net.NetworkInformation;
using System.Numerics;

struct Program
{

    static void Main()
    {
        Random rnd = new Random();
        int[,] temperature = new int[12, 30];

        for (int i = 0; i < temperature.GetLength(0); i++)
        {
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                temperature[i, j] = rnd.Next(-20, 30);
            }
        }

        double[] mediumTemperature = new double[12];
        for (int i = 0; i < mediumTemperature.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                sum += temperature[i, j];
            }
            mediumTemperature[i] = sum / temperature.GetLength(1);
        }
        Array.Sort(mediumTemperature);
    }

}