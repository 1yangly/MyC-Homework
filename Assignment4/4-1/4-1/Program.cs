using System;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T>
{
    private Node<T> head;

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
            head = newNode;
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void ForEach(Action<T> action)
    {
        Node<T> current = head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(3);
        list.Add(7);
        list.Add(1);
        list.Add(10);

        Console.WriteLine("Printing list elements:");
        list.ForEach(x => Console.WriteLine(x));

        int max = int.MinValue;
        int min = int.MaxValue;
        int sum = 0;

        list.ForEach(x =>
        {
            max = Math.Max(max, x);
            min = Math.Min(min, x);
            sum += x;
        });

        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Sum: {sum}");
    }
}

