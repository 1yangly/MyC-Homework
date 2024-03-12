using System;

class Program
{
    static void Main()
    {
        int n = 100;

        Console.WriteLine($"2 到 {n} 之间的素数：");
        PrintPrimes(n);
    }

    static void PrintPrimes(int n)
    {
        bool[] isPrime = new bool[n + 1];

        // 初始化为 true，表示所有数都是素数
        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        // 使用埃氏筛法去除非素数的倍数
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        // 输出素数
        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i])
            {
                Console.Write($"{i} ");
            }
        }

        Console.WriteLine();
    }
}
