using System;
using System.Collections.Generic;

struct Program
{
    static void Main()
    {
        Random rnd = new Random();

        string[] monthNames =
        {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };

        Dictionary<string, int[]> temperature = new Dictionary<string, int[]>();

        foreach (string month in monthNames)
        {
            int[] monthTemps = new int[30];
            for (int j = 0; j < monthTemps.Length; j++)
            {
                monthTemps[j] = rnd.Next(-20, 30);
            }
            temperature[month] = monthTemps; // добавление по ключу
        }

        Dictionary<string, double> mediumTemperature = new Dictionary<string, double>();

        foreach (KeyValuePair<string, int[]> pair in temperature)
        {
            double sum = 0;
            int[] monthTemps = pair.Value;
            for (int j = 0; j < monthTemps.Length; j++)
            {
                sum += monthTemps[j];
            }
            mediumTemperature[pair.Key] = sum / monthTemps.Length;
        }

        
        List<KeyValuePair<string, double>> sortedList =
            new List<KeyValuePair<string, double>>(mediumTemperature);

        sortedList.Sort((a, b) => a.Value.CompareTo(b.Value));

        
;
        foreach (KeyValuePair<string, double> pair in sortedList)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }
    }
}