using EnumComp.Entites;
using EnumComp.Entites.Enum;
using System;
using System.Globalization;
using System.Transactions;

namespace EnumComp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = EntradaUsu();
            Console.Write("Email: ");
            string email = EntradaUsu();
            Console.Write("Brith date (DD/MM/YYYY): ");
            DateTime birthdate = DateTime.Parse(EntradaUsu());
            Client client = new Client(name, email, birthdate);
            Console.WriteLine();
            Console.WriteLine("Enter order date: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(EntradaUsu());
            Order order = new Order(DateTime.Now, status, client);
            Console.Write("How many items to this order? ");
            int n = int.Parse(EntradaUsu());
            Console.WriteLine();
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data");
                Console.Write("Product name: ");
                string productname = EntradaUsu();
                Console.Write("Product price: ");
                double price = double.Parse(EntradaUsu(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(EntradaUsu());
                Product product = new Product(productname, price);
                OrderItem item = new OrderItem(quantity, price, product);
                order.addItem(item);
                Console.WriteLine();
            }
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);


        }

        static string EntradaUsu()
        {
            string? texto = Console.ReadLine();
            return texto == "" || texto == null ? "0" : texto;
        }
    }
}