using System;

class Program
{
    static void Main()
    {
        Console.Write("请输入一个正整数：");
        if (int.TryParse(Console.ReadLine(), out int userInput) && userInput > 0)
        {
            Console.Write($"数字 {userInput} 的素数因子为:");
            PrintPrimeFactors(userInput);
        }
        else
        {
            Console.WriteLine("无效输入，请输入一个正整数。");
        }
    }

    static void PrintPrimeFactors(int number)
    {
        for (int i = 2; i <= number; i++)
        {
            if (IsPrime(i)) Console.Write(i + " ");
            while (number % i == 0 && IsPrime(i)) number /= i;
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
1