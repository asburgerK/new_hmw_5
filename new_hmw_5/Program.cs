using System;

class Program
{
    static void Main(string[] args)
    {
        

        string text = args[0].ToLower();
        const string vowels = "euioay";


        LinkedList<char> list = new LinkedList<char>();
        foreach (char c in text)
            list.AddLast(c);

        int vowelSum = 0, consonantSum = 0;

        
        for (LinkedListNode<char> node = list.First; node != null; node = node.Next)
        {
            char c = node.Value;
            if (c < 'a' || c > 'z') continue;
            if (vowels.Contains(c)) vowelSum++;
            else consonantSum++;
        }

        Console.WriteLine("Гласных: " + vowelSum);
        Console.WriteLine("Согласных: " + consonantSum);
    }
}