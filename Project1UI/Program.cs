// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;
using System.Text.Json;

namespace Project1UI
{
    public class Program
    {
        public static readonly HttpClient HttpClient = new();

        public async static Task Main(string[] args)
        {

            Uri server = new Uri("https://localhost:7235");
            OrderService orderService = new OrderService(server);

            

           
        }
        public static void MenuOptions()
        {
            Console.WriteLine("1: Menu Options");
            Console.WriteLine("2: Add customer");
            Console.WriteLine("3: Add Location");
            Console.WriteLine("4: Place Order");
            Console.WriteLine("5: Location Order List");
            Console.WriteLine("6: Customer Order List");
            Console.WriteLine("7: Search Customer");
            Console.WriteLine("8: Product Catalogue");
            Console.WriteLine("9: Quit Application");
        }

        public static void AddCustomerConsole(DBInteraction cmd)
        {
            string? firstName;
            string? lastName;
            Console.WriteLine("Enter customer first name");

            firstName = Console.ReadLine();

            Console.WriteLine("Enter customer last name");

            lastName = Console.ReadLine();


            cmd.AddNewCustomer(firstName ?? "INVALID ENTRY", lastName ?? "INVALID ENTRY");

            Console.WriteLine($"{firstName} {lastName} added to database");


        }

        public static void AddLocationConsole(DBInteraction cmd)
        {
            string? storeName;

            Console.WriteLine("Enter Location Name");

            storeName = Console.ReadLine();


            cmd.AddNewLocation(storeName ?? "Invalid entry");

            Console.WriteLine($"{storeName} added to database");


        }

        public static void PlaceOrderConsole(DBInteraction cmd)
        {

            Console.WriteLine("Enter Customer ID: ");
            string? customerID = Console.ReadLine() ?? "1";
            Console.WriteLine("Enter location ID: ");
            string? locationID = Console.ReadLine() ?? "1";
            Console.WriteLine("Enter Product ID: ");
            string? productID = Console.ReadLine() ?? "1";
            Console.WriteLine("Enter Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());

            DateTime date = DateTime.Now;

            cmd.placeOrder(customerID, locationID, date, productID, quantity);


            while (true)
            {
                Console.WriteLine("Add more items to order? (Y/N)");
                string prompt = Console.ReadLine() ?? "N";

                if (prompt == "Y")
                {
                    Console.WriteLine("Enter Product ID: ");
                    productID = Console.ReadLine() ?? "1";
                    Console.WriteLine("Enter Quantity");
                    quantity = Convert.ToInt32(Console.ReadLine());

                    cmd.addItemsToOrder(cmd.getOrderIDFromDate(date).ToString(), locationID, productID, quantity);
                }
                else if (prompt == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid response");
                }


            }
            cmd.getOrderDetails(cmd.getOrderIDFromDate(date));
        }

        public async static Task ListLocationOrderConsole(OrderService orderService)
        {

            Console.WriteLine("Enter the ID of the Location you would like to view the order history of");
            string locID = Console.ReadLine();

            List<Order> orders;



            orders = await orderService.ListOrderDetailsOfLocationAsync(locID);

            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.customerID} placed {order.})
            }

        }

        public static void ListCustomerOrderConsole(DBInteraction cmd)
        {

            Console.WriteLine("Enter the ID of the Customer you would like to view the order history of");
            int custID = Convert.ToInt32(Console.ReadLine());

            cmd.listOrderDetailsOfCustomer(custID);
        }

        public static void ListOrderDetailsConsole(DBInteraction cmd)
        {
            Console.WriteLine("Enter the OrderID of the order");
            int orderId = Convert.ToInt32(Console.ReadLine());

            cmd.getOrderDetails(orderId);
        }

        public static void FindCustomerConsole(DBInteraction cmd)
        {
            Console.WriteLine("Enter the first name followed by the last name");

            string? firstName = Console.ReadLine() ?? "Null";
            string? lastName = Console.ReadLine() ?? "Null";



            cmd.findCustomer(firstName, lastName);
        }
    }

}
