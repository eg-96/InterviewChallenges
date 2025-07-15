using System;
using System.Collections.Generic;
using System.Linq;

class PositivePrefixes
{
    static void Main(string[] args)
    {
        int[] arr = { -1, 2, -3, 4, -5, 6 };
        int k = 3;
        int[] result = GetPositivePrefixes(arr, k);

        Console.WriteLine(string.Join(", ", result));
    }

    static int[] GetPositivePrefixes(int[] arr, int k)
    {
        List<int> result = new List<int>();
        int sum = 0;
        int count = 0;

        foreach (int num in arr)
        {
            sum += num;
            result.Add(num);
            if (sum > 0)
            {
                count++;
            }
            if (count == k)
            {
                break;
            }
        }

        return result.ToArray();
    }

        static int[] GetPositivePrefixesWithLinq(int[] arr, int k)
    {
        var result = arr.Select((num, index) => new { num, index })
                        .TakeWhile((x, i) => arr.Take(i + 1).Sum() > 0 || i < k - 1)
                        .Select(x => x.num)
                        .ToArray();

        return result;
    }
}