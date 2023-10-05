using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumComp.Entites.Enum;

namespace EnumComp.Entites
{
    internal class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Itens { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }
        public Order(DateTime date, OrderStatus status, Client client)
        {
            Date = date;
            Status = status;
            Client = client;
        }

        public void addItem(OrderItem item) 
        {
            Itens.Add(item);
        }
        public void removeItem(OrderItem item)
        {
            Itens.Remove(item);
        }
        public double Total()
        {
            double total = 0.0;
            foreach(OrderItem item in Itens)
            {
                total += item.SubTotal();
            }
            return total;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order Moment: ");
            sb.AppendLine(Date.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.AppendLine(Client.ToString());
            sb.AppendLine("Order items:");
            foreach(OrderItem item in Itens)
            {
                sb.AppendLine(item.ToString());
            }
            sb.Append("Total Price: ");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
