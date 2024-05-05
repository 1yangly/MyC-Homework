using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OrderManagementWebApi
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        // Other order properties...

        // You can add methods here for order logic, e.g., calculating total amount, validating order info, etc.
    }

    public class OrderController : ApiController
    {
        private static List<Order> orders = new List<Order>();

        // GET api/order
        public IEnumerable<Order> GetOrders()
        {
            return orders;
        }

        // GET api/order/1
        public IHttpActionResult GetOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        // POST api/order
        public IHttpActionResult PostOrder(Order order)
        {
            if (order == null)
                return BadRequest("Invalid order data.");
            order.OrderId = orders.Count + 1;
            orders.Add(order);
            return CreatedAtRoute("DefaultApi", new { id = order.OrderId }, order);
        }

        // PUT api/order/1
        public IHttpActionResult PutOrder(int id, Order updatedOrder)
        {
            var existingOrder = orders.FirstOrDefault(o => o.OrderId == id);
            if (existingOrder == null)
                return NotFound();
            existingOrder.CustomerName = updatedOrder.CustomerName;
            // Update other properties...
            return Ok(existingOrder);
        }

        // DELETE api/order/1
        public IHttpActionResult DeleteOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
                return NotFound();
            orders.Remove(order);
            return Ok(order);
        }
    }
}
