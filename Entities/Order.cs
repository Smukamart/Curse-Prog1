using System;
using Course.Entities.Enum;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Course.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; } = new Client();
        public List<OrderIten> Items { get; set; } = new List<OrderIten>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void addItem(OrderIten item)
        {
            Items.Add(item);
        }

        public void removeItem(OrderIten item)
        {
            Items.Add(item);
        }

        public double total()
        {
            double sum = 0;
            foreach(OrderIten iten in Items)
            {
                sum += iten.Price * iten.Quantity;
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("ORDER SUMMARY:");
            stringBuilder.AppendLine("Order Moment: " + DateTime.Now);
            stringBuilder.AppendLine("Order Status: " + OrderStatus.Processing);
            stringBuilder.AppendLine("Client: " + Client.Name+" ("+Client.BirthDate.ToString("dd/MM/yyyy")+") "+Client.Email);
            stringBuilder.AppendLine("Order Items:");
            foreach(OrderIten orderIten in Items)
            {
                stringBuilder.AppendLine(orderIten.Product.Name + ", " + orderIten.Price + ", " + orderIten.Quantity + ", Subtotal: " + orderIten.subTotal());
            }
            stringBuilder.AppendLine("Total Price: " + total().ToString("F2",CultureInfo.InvariantCulture));
            return stringBuilder.ToString();
        }
    }
}
