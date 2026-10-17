using System;

class Program
{
    static void Main(string[] args)
    {
        

        string text = args[0].ToLower();
        const string vowels = "euioay";
        int vowelSum = 0, consonantSum = 0;

        foreach (char c in text)
        {
            if (c < 'a' || c > 'z') continue;   
            if (vowels.Contains(c)) vowelSum++;
            else consonantSum++;
        }

        Console.WriteLine("Гласных: " + vowelSum);
        Console.WriteLine("Согласных: " + consonantSum);
    }
}