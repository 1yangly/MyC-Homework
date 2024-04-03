using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    public int OrderId { get; set; }
    public string Customer { get; set; }
    public List<OrderDetails> Details { get; set; }

    public override bool Equals(object obj)
    {
        if (!(obj is Order))
            return false;

        var other = obj as Order;
        return OrderId == other.OrderId;
    }

    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }

    public override string ToString()
    {
        return $"Order ID: {OrderId}, Customer: {Customer}, Total Amount: {GetTotalAmount()}";
    }

    public decimal GetTotalAmount()
    {
        return Details.Sum(d => d.Price * d.Quantity);
    }
}

class OrderDetails
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public override bool Equals(object obj)
    {
        if (!(obj is OrderDetails))
            return false;

        var other = obj as OrderDetails;
        return ProductName == other.ProductName;
    }

    public override int GetHashCode()
    {
        return ProductName.GetHashCode();
    }

    public override string ToString()
    {
        return $"Product: {ProductName}, Price: {Price}, Quantity: {Quantity}";
    }
}

class OrderService
{
    private List<Order> orders;

    public OrderService()
    {
        orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
            throw new ArgumentException("Order already exists.");

        orders.Add(order);
    }

    public void RemoveOrder(int orderId)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
            throw new ArgumentException("Order not found.");

        orders.Remove(order);
    }

    public void ModifyOrder(Order order)
    {
        var existingOrder = orders.FirstOrDefault(o => o.OrderId == order.OrderId);
        if (existingOrder == null)
            throw new ArgumentException("Order not found.");

        orders.Remove(existingOrder);
        orders.Add(order);
    }

    public List<Order> QueryOrders(Func<Order, bool> predicate)
    {
        return orders.Where(predicate).OrderBy(o => o.GetTotalAmount()).ToList();
    }

    public void SortOrders<TKey>(Func<Order, TKey> keySelector)
    {
        orders = orders.OrderBy(keySelector).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var service = new OrderService();

        var order1 = new Order { OrderId = 1, Customer = "Alice" };
        order1.Details = new List<OrderDetails>
        {
            new OrderDetails { ProductName = "Product1", Price = 10, Quantity = 2 },
            new OrderDetails { ProductName = "Product2", Price = 20, Quantity = 1 }
        };

        var order2 = new Order { OrderId = 2, Customer = "Bob" };
        order2.Details = new List<OrderDetails>
        {
            new OrderDetails { ProductName = "Product3", Price = 15, Quantity = 3 },
            new OrderDetails { ProductName = "Product4", Price = 25, Quantity = 2 }
        };

        service.AddOrder(order1);
        service.AddOrder(order2);

        Console.WriteLine("Initial Orders:");
        PrintOrders(service.QueryOrders(o => true));

        // 删除订单测试
        try
        {
            service.RemoveOrder(3); // 不存在的订单
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Error Removing Order: " + e.Message);
        }

        // 修改订单测试
        order2.Customer = "Charlie";
        service.ModifyOrder(order2);

        Console.WriteLine("\nModified Orders:");
        PrintOrders(service.QueryOrders(o => true));

        // 查询订单测试
        Console.WriteLine("\nQuery Orders by Customer 'Charlie':");
        PrintOrders(service.QueryOrders(o => o.Customer == "Charlie"));

        // 排序测试
        Console.WriteLine("\nSorted Orders by Total Amount:");
        service.SortOrders(o => o.GetTotalAmount());
        PrintOrders(service.QueryOrders(o => true));
    }

    static void PrintOrders(List<Order> orders)
    {
        foreach (var order in orders)
        {
            Console.WriteLine(order);
            foreach (var detail in order.Details)
            {
                Console.WriteLine("\t" + detail);
            }
        }
    }
}
