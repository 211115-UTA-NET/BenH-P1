namespace Project1.Logic{

    using System.Data.SqlClient;
    using Project0.App;
    public class Customer{

        internal string firstName{get; set;}
        internal string lastName {get; set;}

        public Customer(string firstName, string lastName){

            this.firstName = firstName;
            this.lastName = lastName;
           

        }

        

        }
}
