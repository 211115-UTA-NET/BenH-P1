namespace Project1.Logic{

    public class Order{

        public string storeID { get; set; }
        public int customerID { get; set; }
        public DateTime date { get; set; }


        public Order(string storeID, int customerID, DateTime date)
        {
            this.storeID = storeID;
            this.customerID = customerID;
            this.date = date;
        }

        
        




    }
}