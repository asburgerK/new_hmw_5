using System;
using System.Collections.Generic;

struct Program
{
    static void Print(LinkedList<LinkedList<int>> matrix)
    {
        foreach (var row in matrix)
        {
            foreach (var item in row)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

    static LinkedList<LinkedList<int>> Multiply(
        LinkedList<LinkedList<int>> a,
        LinkedList<LinkedList<int>> b)
    {
        int rowsA = a.Count;
        int colsA = a.First.Value.Count;
        int rowsB = b.Count;
        int colsB = b.First.Value.Count;

        if (colsA != rowsB)
        {
            throw new ArgumentException("Несовместимые размеры матриц.");
        }

        // Преобразуем b в массив столбцов для быстрого доступа
        // (в LinkedList нет индексатора, поэтому удобнее подготовить данные)
        int[][] bRows = new int[rowsB][];
        int r = 0;
        foreach (var row in b)
        {
            bRows[r] = new int[colsB];
            int c = 0;
            foreach (var val in row)
            {
                bRows[r][c++] = val;
            }
            r++;
        }

        var result = new LinkedList<LinkedList<int>>();

        foreach (var rowA in a)
        {
            var newRow = new LinkedList<int>();
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                int k = 0;
                foreach (var valA in rowA)
                {
                    sum += valA * bRows[k][j];
                    k++;
                }
                newRow.AddLast(sum);
            }
            result.AddLast(newRow);
        }

        return result;
    }

    static LinkedList<int> MakeRow(params int[] values)
    {
        var row = new LinkedList<int>();
        foreach (var v in values) row.AddLast(v);
        return row;
    }

    static void Main()
    {
        var a = new LinkedList<LinkedList<int>>();
        a.AddLast(MakeRow(1, 2));
        a.AddLast(MakeRow(3, 4));

        var b = new LinkedList<LinkedList<int>>();
        b.AddLast(MakeRow(5, 6));
        b.AddLast(MakeRow(7, 8));

        var c = Multiply(a, b);
        Print(c);
    }
}