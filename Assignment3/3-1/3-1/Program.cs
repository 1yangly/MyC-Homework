using System;

// 定义形状接口
public interface IShape
{
    double CalculateArea();
    bool IsValid();
}

// 长方形类
public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }

    public bool IsValid()
    {
        return Width > 0 && Height > 0;
    }
}

// 正方形类，继承自长方形类
public class Square : Rectangle
{
    public Square(double side) : base(side, side)
    {
        // 正方形的宽和高相等
    }
}

class Program
{
    static void Main()
    {
        // 示例用法
        Rectangle rectangle = new Rectangle(4, 5);
        Square square = new Square(3);

        PrintShapeInfo(rectangle);
        PrintShapeInfo(square);
    }

    static void PrintShapeInfo(IShape shape)
    {
        if (shape.IsValid())
        {
            Console.WriteLine($"{shape.GetType().Name} Area: {shape.CalculateArea()}");
        }
        else
        {
            Console.WriteLine($"{shape.GetType().Name} is not valid.");
        }
    }
}
