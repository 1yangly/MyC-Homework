using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderManagementApp
{
    // 模拟的 Order 类
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        // 其他订单属性...

        public Order(int orderId, string customerName)
        {
            OrderId = orderId;
            CustomerName = customerName;
        }
    }

    // 模拟的 OrderService 类
    public class OrderService
    {
        private List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public void DeleteOrder(int orderId)
        {
            Order orderToRemove = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (orderToRemove != null)
                orders.Remove(orderToRemove);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        // 其他订单操作方法...
    }

    // 主窗口
    public class MainForm : Form
    {
        private DataGridView dataGridViewOrders;
        private Button btnCreateOrder;
        private Button btnDeleteOrder;
        private Button btnEditOrder;
        private OrderService orderService;

        public MainForm()
        {
            InitializeUI();
            orderService = new OrderService();
            LoadOrders();
        }

        private void InitializeUI()
        {
            // 初始化窗口控件
            dataGridViewOrders = new DataGridView();
            btnCreateOrder = new Button { Text = "Create Order", Dock = DockStyle.Top };
            btnDeleteOrder = new Button { Text = "Delete Order", Dock = DockStyle.Top };
            btnEditOrder = new Button { Text = "Edit Order", Dock = DockStyle.Top };

            btnCreateOrder.Click += BtnCreateOrder_Click;
            btnDeleteOrder.Click += BtnDeleteOrder_Click;
            btnEditOrder.Click += BtnEditOrder_Click;

            Controls.AddRange(new Control[] { dataGridViewOrders, btnCreateOrder, btnDeleteOrder, btnEditOrder });

            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.AutoGenerateColumns = true;

            Text = "Order Management";
            Width = 600;
            Height = 400;
        }

        private void LoadOrders()
        {
            dataGridViewOrders.DataSource = orderService.GetAllOrders();
        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            Order newOrder = new Order(orderService.GetAllOrders().Count + 1, "New Customer"); // 生成一个新订单
            orderService.AddOrder(newOrder);
            LoadOrders();
        }

        private void BtnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                int orderId = (int)dataGridViewOrders.SelectedRows[0].Cells["OrderId"].Value;
                orderService.DeleteOrder(orderId);
                LoadOrders();
            }
        }

        private void BtnEditOrder_Click(object sender, EventArgs e)
        {
            // 编辑订单，这里可以打开一个新窗口进行编辑
        }
    }

    // 入口点
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
