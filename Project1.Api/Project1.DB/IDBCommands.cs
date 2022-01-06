namespace Project1.DB{

    using Project1.Logic;
    
    public interface IDBCommands{

        Task AddNewCustomerAsync(string firstName, string lastName);
        Task AddNewLocationAsync(string storeName);

        void placeOrder(string customerID, string locationID, DateTime date, string productID, int quantity);
        Task<IEnumerable<Customer>> findCustomerAsync(string firstName, string lastName);
        Task<IEnumerable<Order>> listOrderDetailsOfCustomerAsync(string customerID);
        Task<IEnumerable<Order>> listOrderDetailsOfLocationAsync(string locationID);


    }
}