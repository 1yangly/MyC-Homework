using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OrderManagementSystem
{
    // 订单模型类
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        // 其他订单属性...
    }

    // 数据库上下文类
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }

    // 订单仓库类
    public class OrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository()
        {
            _context = new OrderContext();
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public void UpdateOrder(Order updatedOrder)
        {
            var existingOrder = _context.Orders.Find(updatedOrder.OrderId);
            if (existingOrder != null)
            {
                existingOrder.CustomerName = updatedOrder.CustomerName;
                // 更新其他属性...
                _context.SaveChanges();
            }
        }

        public Order GetOrder(int orderId)
        {
            return _context.Orders.Find(orderId);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var repository = new OrderRepository();

            // 添加订单
            var newOrder = new Order
            {
                CustomerName = "John Doe",
                OrderDate = DateTime.Now
                // 设置其他属性...
            };
            repository.AddOrder(newOrder);

            // 查询订单
            var orderId = 1; // 假设订单号为1
            var retrievedOrder = repository.GetOrder(orderId);
            if (retrievedOrder != null)
            {
                Console.WriteLine($"Order ID: {retrievedOrder.OrderId}, Customer: {retrievedOrder.CustomerName}");
            }
            else
            {
                Console.WriteLine("Order not found.");
            }

            // 更新订单
            retrievedOrder.CustomerName = "Jane Smith";
            repository.UpdateOrder(retrievedOrder);

            // 删除订单
            repository.DeleteOrder(orderId);
        }
    }
}
