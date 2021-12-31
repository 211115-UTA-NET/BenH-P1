namespace Project1.App {



    using Project1.DB;

    public class Program {

       private static string connectionString = File.ReadAllText("../../ben-db-connection-string.txt");

       public static void Main(string[] args)
        {
            DBInteraction cmd = new DBInteraction(connectionString);

            Console.WriteLine("------------ORDER MANAGEMENT SYSTEM-----------");

            
            

            while (true)
            {


                Console.WriteLine("Enter 1 For Menu Options, otherwise enter your instruction");

                int switchController = Convert.ToInt32(Console.ReadLine());


                switch (switchController)
                {
                    case 1:
                        MenuOptions();
                        break;
                    case 2:
                        AddCustomerConsole(cmd);
                        break;
                    case 3:
                        AddLocationConsole(cmd);
                        break;
                    case 4:
                        PlaceOrderConsole(cmd);
                        break;
                    case 5:
                        ListLocationOrderConsole(cmd);
                        break;
                    case 6:
                        ListCustomerOrderConsole(cmd);
                        break;
                    case 7:
                        FindCustomerConsole(cmd);
                        break;
                    case 8:
                        cmd.productCatalogue();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;

                }
            }
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

            Console.WriteLine("Enter Customer ID: ") ;
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
                }else if (prompt == "N")
                {
                    break;
                }else
                {
                    Console.WriteLine("Invalid response");
                }

                
            }
            cmd.getOrderDetails(cmd.getOrderIDFromDate(date));
        }

        public static void ListLocationOrderConsole(DBInteraction cmd)
        {

            Console.WriteLine("Enter the ID of the Location you would like to view the order history of");
            int locID = Convert.ToInt32(Console.ReadLine());

            cmd.listOrderDetailsOfLocation(locID);
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
