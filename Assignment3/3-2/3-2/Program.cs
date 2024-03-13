using System;
using System.Collections.Generic;

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

// 正方形类
public class Square : IShape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public double CalculateArea()
    {
        return Side * Side;
    }

    public bool IsValid()
    {
        return Side > 0;
    }
}

// 三角形类
public class Triangle : IShape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }

    public double CalculateArea()
    {
        return 0.5 * Base * Height;
    }

    public bool IsValid()
    {
        return Base > 0 && Height > 0;
    }
}

// 简单工厂类
public class ShapeFactory
{
    public IShape CreateShape(string shapeType, params double[] parameters)
    {
        switch (shapeType.ToLower())
        {
            case "rectangle":
                return new Rectangle(parameters[0], parameters[1]);
            case "square":
                return new Square(parameters[0]);
            case "triangle":
                return new Triangle(parameters[0], parameters[1]);
            default:
                throw new ArgumentException("Invalid shape type");
        }
    }
}

class Program
{
    static void Main()
    {
        ShapeFactory shapeFactory = new ShapeFactory();
        List<IShape> shapes = new List<IShape>();

        // 随机创建10个形状对象
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            int shapeIndex = random.Next(1, 4); // 随机选择形状类型
            double[] parameters = new double[2];

            for (int j = 0; j < parameters.Length; j++)
            {
                parameters[j] = random.NextDouble() * 10; // 随机生成参数
            }

            IShape shape = shapeFactory.CreateShape(GetShapeType(shapeIndex), parameters);
            shapes.Add(shape);
        }

        // 计算面积之和
        double totalArea = 0;
        foreach (var shape in shapes)
        {
            if (shape.IsValid())
            {
                totalArea += shape.CalculateArea();
            }
        }

        Console.WriteLine($"Total Area: {totalArea}");
    }

    static string GetShapeType(int index)
    {
        switch (index)
        {
            case 1:
                return "rectangle";
            case 2:
                return "square";
            case 3:
                return "triangle";
            default:
                throw new ArgumentException("Invalid shape index");
        }
    }
}
