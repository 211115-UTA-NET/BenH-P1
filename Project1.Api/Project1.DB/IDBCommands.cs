namespace Project1.DB{

    using Project1.Logic;
    
    public interface IDBCommands{

        void AddNewCustomer(string firstName, string lastName);
        void AddNewLocation(string storeName);

        void placeOrder(string customerID, string locationID, DateTime date, string productID, int quantity);
        Task<IEnumerable<Customer>> findCustomerAsync(string firstName, string lastName);
        Task<IEnumerable<Order>> listOrderDetailsOfCustomerAsync(int customerID);


    }
}