using System;

class PrimeFactors
{
    static void Main()
    {
        Console.Write("请输入一个正整数: ");
        if (int.TryParse(Console.ReadLine(), out int userInput) && userInput > 0)
        {
            Console.WriteLine($"数字 {userInput} 的素数因子为:");

            // 输出素数因子
            PrintPrimeFactors(userInput);
        }
        else
        {
            Console.WriteLine("错误：请输入有效的正整数");
        }
    }

    static void PrintPrimeFactors(int number)
    {
        for (int i = 2; i <= number; i++)
        {
            while (number % i == 0 && IsPrime(i))
            {
                Console.WriteLine(i);
                number /= i;
            }
        }
    }

    static bool IsPrime(int num)
    {
        if (num < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
}
