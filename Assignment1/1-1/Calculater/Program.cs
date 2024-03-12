using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("简单计算器");
        Console.WriteLine("------------------");

        Console.Write("请输入第一个数字: ");
        if (double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.Write("请输入运算符 (+, -, *, /): ");
            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine(); // 换行

            Console.Write("请输入第二个数字: ");
            if (double.TryParse(Console.ReadLine(), out double num2))
            {
                double result = 0;

                switch (operation)
                {
                    case '+':
                        result = Add(num1, num2);
                        break;
                    case '-':
                        result = Subtract(num1, num2);
                        break;
                    case '*':
                        result = Multiply(num1, num2);
                        break;
                    case '/':
                        result = Divide(num1, num2);
                        break;
                    default:
                        Console.WriteLine("错误：无效的运算符");
                        return;
                }

                Console.WriteLine($"结果: {result}");
            }
            else
            {
                Console.WriteLine("错误：无效的第二个数字");
            }
        }
        else
        {
            Console.WriteLine("错误：无效的第一个数字");
        }
    }

    static double Add(double x, double y)
    {
        return x + y;
    }

    static double Subtract(double x, double y)
    {
        return x - y;
    }

    static double Multiply(double x, double y)
    {
        return x * y;
    }

    static double Divide(double x, double y)
    {
        if (y != 0)
        {
            return x / y;
        }
        else
        {
            Console.WriteLine("错误：除数不能为零");
            return 0;
        }
    }
}
