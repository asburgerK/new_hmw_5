using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1-Картинки 2-Студенты 3-Бабули 4-Граф 0-Выход");
            string c = Console.ReadLine();
            if (c == "1") Task1();
            else if (c == "2") Task2();
            else if (c == "3") Task3();
            else if (c == "4") Task4();
            else if (c == "0") break;
        }
    }

   
    static void Task1()
    {
        List<string> list = new List<string>();
        for (int i = 1; i <= 32; i++)
        {
            list.Add("pic" + i);
            list.Add("pic" + i);
        }

        Console.WriteLine("Исходный:");
        for (int i = 0; i < list.Count; i++)
            Console.Write(i + ":" + list[i] + " ");
        Console.WriteLine();

        Random r = new Random();
        for (int i = 0; i < list.Count; i++)
        {
            int j = r.Next(list.Count);
            string t = list[i]; list[i] = list[j]; list[j] = t;
        }

        Console.WriteLine("Перемешанный:");
        for (int i = 0; i < list.Count; i++)
            Console.Write(i + ":" + list[i] + " ");
        Console.WriteLine();
    }

    class Student
    {
        public string Sur, Name, Exam;
        public int Year, Score;
        public override string ToString() => Sur + " " + Name + " " + Year + " " + Exam + " " + Score;
    }

    static void Task2()
    {
        Console.Write("Введите путь к файлу (например C:\\students.txt): ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("Файл не найден: " + file);
            return;
        }

        List<Student> list = new List<Student>();

        foreach (string line in File.ReadAllLines(file))
        {
            if (line.Trim() == "") continue;
            string[] p = line.Split(' ');
            Student s = new Student();
            s.Sur = p[0]; s.Name = p[1];
            s.Year = int.Parse(p[2]);
            s.Exam = p[3]; s.Score = int.Parse(p[4]);
            list.Add(s);
        }

        Dictionary<string, Student> dict = new Dictionary<string, Student>();
        foreach (var s in list) dict[s.Sur + " " + s.Name] = s;

        while (true)
        {
            Console.WriteLine("\nНовый студент / Удалить / Сортировать / Показать / Выход");
            string cmd = Console.ReadLine().ToLower();

            if (cmd == "новый студент")
            {
                Student s = new Student();
                Console.Write("Фамилия: "); s.Sur = Console.ReadLine();
                Console.Write("Имя: "); s.Name = Console.ReadLine();
                Console.Write("Год: "); s.Year = int.Parse(Console.ReadLine());
                Console.Write("Экзамен: "); s.Exam = Console.ReadLine();
                Console.Write("Баллы: "); s.Score = int.Parse(Console.ReadLine());
                list.Add(s);
                dict[s.Sur + " " + s.Name] = s;
                File.AppendAllText(file, "\n" + s);
            }
            else if (cmd == "удалить")
            {
                Console.Write("Фамилия: "); string a = Console.ReadLine();
                Console.Write("Имя: "); string b = Console.ReadLine();
                string key = a + " " + b;
                if (dict.ContainsKey(key))
                {
                    list.Remove(dict[key]);
                    dict.Remove(key);
                    List<string> lines = new List<string>();
                    foreach (var s in list) lines.Add(s.ToString());
                    File.WriteAllLines(file, lines);
                    Console.WriteLine("Удалён");
                }
                else Console.WriteLine("Не найден");
            }
            else if (cmd == "сортировать")
            {
                list = list.OrderBy(s => s.Score).ToList();
                foreach (var s in list) Console.WriteLine(s);
            }
            else if (cmd == "показать")
            {
                foreach (var s in list) Console.WriteLine(s);
            }
            else if (cmd == "выход") break;
        }
    }

    class Grandma
    {
        public string Name;
        public int Age;
        public List<string> Sick = new List<string>();
        public override string ToString() => Name + " (" + Age + ") болезни: " + string.Join(",", Sick);
    }

    class Hospital
    {
        public string Name;
        public List<string> Cures = new List<string>();
        public int Cap;
        public Stack<Grandma> Patients = new Stack<Grandma>();
        public bool Full() => Patients.Count >= Cap;
        public double Percent() => 100.0 * Patients.Count / Cap;
        public override string ToString() =>
            Name + " лечит:[" + string.Join(",", Cures) + "] " +
            Patients.Count + "/" + Cap + " (" + Percent().ToString("F0") + "%)";
    }

    static void Task3()
    {
        List<Hospital> hosps = new List<Hospital>();
        hosps.Add(new Hospital { Name = "Городская", Cap = 2, Cures = new List<string> { "Простуда", "Грипп", "Ангина" } });
        hosps.Add(new Hospital { Name = "Кардио", Cap = 3, Cures = new List<string> { "Аритмия", "Давление" } });
        hosps.Add(new Hospital { Name = "Невро", Cap = 2, Cures = new List<string> { "Мигрень", "Инсульт" } });

        Queue<Grandma> queue = new Queue<Grandma>();
        List<Grandma> street = new List<Grandma>();

        while (true)
        {
            Console.WriteLine("\n1-добавить 2-больницы 3-очередь 4-распределить 0-выход");
            string c = Console.ReadLine();
            if (c == "0") break;

            if (c == "1")
            {
                Grandma g = new Grandma();
                Console.Write("Имя: "); g.Name = Console.ReadLine();
                Console.Write("Возраст: "); g.Age = int.Parse(Console.ReadLine());
                Console.Write("Сколько болезней: "); int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Болезнь: ");
                    g.Sick.Add(Console.ReadLine());
                }
                queue.Enqueue(g);
            }
            else if (c == "2")
            {
                foreach (var h in hosps) Console.WriteLine(h);
            }
            else if (c == "3")
            {
                Console.WriteLine("В очереди:");
                foreach (var g in queue) Console.WriteLine(g);
                Console.WriteLine("На улице:");
                foreach (var g in street) Console.WriteLine(g);
            }
            else if (c == "4")
            {
                while (queue.Count > 0)
                {
                    Grandma g = queue.Dequeue();
                    Hospital target = null;

                    if (g.Sick.Count == 0)
                    {
                        foreach (var h in hosps)
                            if (!h.Full()) { target = h; break; }
                    }
                    else
                    {
                        foreach (var h in hosps)
                        {
                            if (h.Full()) continue;
                            int count = 0;
                            foreach (var s in g.Sick)
                                if (h.Cures.Contains(s)) count++;
                            if (count > g.Sick.Count / 2.0) { target = h; break; }
                        }
                    }

                    if (target != null)
                    {
                        target.Patients.Push(g);
                        Console.WriteLine(g.Name + " -> " + target.Name);
                    }
                    else
                    {
                        street.Add(g);
                        Console.WriteLine(g.Name + " плачет на улице");
                    }
                }
            }
        }
    }

    static void Task4()
    {
        Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
        g[1] = new List<int> { 2, 3 };
        g[2] = new List<int> { 1, 4, 5 };
        g[3] = new List<int> { 1, 6 };
        g[4] = new List<int> { 2, 7 };
        g[5] = new List<int> { 2, 6, 7 };
        g[6] = new List<int> { 3, 5, 8 };
        g[7] = new List<int> { 4, 5, 8 };
        g[8] = new List<int> { 6, 7 };

        Console.Write("Откуда: "); int start = int.Parse(Console.ReadLine());
        Console.Write("Куда: "); int end = int.Parse(Console.ReadLine());

        Dictionary<int, int> parent = new Dictionary<int, int>();
        Queue<int> q = new Queue<int>();
        q.Enqueue(start);
        parent[start] = -1;

        while (q.Count > 0)
        {
            int v = q.Dequeue();
            if (v == end) break;
            foreach (int n in g[v])
            {
                if (!parent.ContainsKey(n))
                {
                    parent[n] = v;
                    q.Enqueue(n);
                }
            }
        }

        if (!parent.ContainsKey(end))
        {
            Console.WriteLine("Пути нет");
            return;
        }

        List<int> path = new List<int>();
        int cur = end;
        while (cur != -1)
        {
            path.Add(cur);
            cur = parent[cur];
        }
        path.Reverse();
        Console.WriteLine("Путь: " + string.Join(" -> ", path));
    }
}