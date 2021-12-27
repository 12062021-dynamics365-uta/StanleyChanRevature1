using System;
using System.Collections.Generic;
using Storage;
using System.Data.SqlClient;

namespace Domain
{


    public class Displays
    {
        private readonly SqlConnection con = new SqlConnection("Data source = DESKTOP-MGG67M3\\SQLEXPRESS; initial Catalog = p0_StoreApp; integrated security = true");
        string queryString;
        string userInput;
        //public Store currentStore;

        public int StoreNavigation()
        {
            int storeChoice = 0;
            queryString = "Select * from Stores;";
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0].ToString() + ".  Store Name: " + dr[1].ToString() + " \t Store Location: " + dr[2].ToString());
            }
            con.Close();
            do
            {
                Console.WriteLine("\nChoose a store number: ");
                userInput = Console.ReadLine();
                storeChoice = ValidateIntInput(userInput, 3);
            } while (storeChoice == 0);
            return storeChoice;
        }

        public void ShowProducts(int storeID) //stretch: show store name at the top before displaying product list
        {
            queryString = @"SELECT p.ProductID, ProductName, ProductPrice, Quantity, ProductDesc 
                            FROM Inventory i LEFT JOIN Products p
                            ON i.ProductID = p.ProductID
                            WHERE StoreID = " + storeID.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Console.WriteLine(dr[0].ToString() + ". Product Name: " + dr[1].ToString() + 
                                  "\t Product Price: " + dr[2].ToString() +
                                  "\n   Quantity: " + dr[3].ToString() + 
                                  "\n   Description: " + dr[4].ToString() + "\n");
            }
            con.Close();
        }

        public void ShowPastOfCust(int custID)
        {
            queryString = @"SELECT ProductName, ProductPrice, Quantity, totalAmount, OrderDate, StoreName, StoreLoc
                            FROM PastSales ps 
                            LEFT JOIN Products p ON ps.ProductID = p.ProductID
							LEFT JOIN Stores st ON ps.StoreID = st.StoreID
							WHERE CustomerID = " + custID.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(@"Product Name: " + dr[0].ToString() + " \t Product Price: " + dr[1].ToString() + "\tQuantity: " + dr[2].ToString() +
                    "\tTotal: " + dr[3].ToString() + "\tOrderDate" + dr[4].ToString() + 
                    "\nStore Name: " + dr[5].ToString() + "\tStore Location: " + dr[6].ToString());
            }
          
            if (!dr.Read())
            {
                Console.WriteLine("Customer has not made any past purchases.");
            }
            con.Close();
        }

        public void ShowPastOfStore(int storeID)
        {
            queryString = @"SELECT ProductName, ProductPrice, Quantity, totalAmount, OrderDate
                            FROM PastSales s LEFT JOIN Products p
                            ON s.ProductID = p.ProductID
                            WHERE StoreID = " + storeID.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(@"Product Name: " + dr[0].ToString() + " \t Product Price: " + dr[1].ToString() + "\tQuantity: " + dr[2].ToString() +
                    "\tTotal: " + dr[3].ToString() + "\tOrderDate" + dr[4].ToString());
            }
            if(!dr.Read())
            {
                Console.WriteLine("Store is brand new. No purchases.");
            }
            con.Close();
        }

        //was made before we went over ADO.NET
        /*public List<Store> storeList;
        public List<Product> productBikes;
        public List<Product> productThreads;
        public List<Product> productShoes;
        public List<string> storeLocations;
        */

        public Customer currentCustomer;
        public Order currentOrder = new Order();
        public OrderItem currentOrderItem;
        private int countingOrders;
        public Product currentProduct;


        //was made before we went over ADO.NET
        /*public void InitializeStoreAndProducts()
        {
            
            storeList = new List<Store>
            {
            new Store("We♡Bikes", "Northern Ward"),
            new Store("Golden Threads", "Southern Ward"),
            new Store("sh0EZsh0p", "Eastern Ward")
            };

            storeLocations = new List<string>
            {
                storeList[0].location,
                storeList[1].location,
                storeList[2].location
            };


            productBikes = new List<Product>
            {
            new Product("Old Bike", 39.99, "A trusty refurbished bike which is in dire need of a paint job."),
            new Product("Miracle Cycle", 499.99, "A bike so overpriced, you'd think it was meant to deter 10 year olds from speeding through routes."),
            new Product("Miracle Cycle V", 00.01, "An upgraded model that is meant to be exchanged for a Voucher."),
            new Product("Rydel's Cycle", 19.99, "A grossly underpriced bike that serves as advertisement."),
            new Product("Mach Bike", 125.00, "Warp Speed!"),
            new Product("Acro Bike", 125.00, "It jumps ledges so you don't have to!"),
            new Product("Radical Rickshaw", 160.88, "If you ignore the fact it's a rickshaw, this bike will serve you very well."),
            new Product("Harlequin's Bike", 269.99, "Was this bike stolen?")
            };

            productThreads = new List<Product>
            {
            new Product("THE Jacket", 499.99, "More drip than the River Thames."),
            new Product("THE T-shirt", 169.99, "There's not even a logo?"),
            new Product("THE Hoodie", 219.99, "The power of BRANDING."),
            new Product("THE Sweatpants", 97.79, "They're like socks for your legs."),
            new Product("Golden Wind", 199.99, "Why do I hear music, where are the speakers? 10/10"),
            new Product("Silver Moon Headband", 17.49, "As seen on the Chris Rock Impersonators Show"),
            new Product("Just a Suit", 74.99, "Not a custom-fit but worth every penny"),
            new Product("Sewing Kit", 69.99, "Who sews nowadays anyways")
            };

            productShoes = new List<Product>
            { 
            new Product("Boots of Mobility", 8.50, "The classic. Lets you run straight into the enemy."),
            new Product("Swifties", 9.00, "Not even your teammates can slow you down now!"),
            new Product("Merc Treads", 11.00, "Go where you please(s)."),
            new Product("Ninja Tabi's", 11.00, "Ninja's don't wear steel capped shoes."),
            new Product("Boots of Lucidity", 9.50, "Am I dreaming or did you just do that again?"),
            new Product("Sorceror's Shoes", 10.99, "True magic lies in the heart."),
            new Product("Berserker's Greaves", 11.49, "Why do they cost more? Why not.")
            };

            //put products in respective stores with arbitrary starting inventories
            foreach(Product storeBike in productBikes)
            {
                storeList[0].inventory.Add(storeBike, 10);
            }

            foreach (Product storeThreads in productThreads)
            {
                storeList[1].inventory.Add(storeThreads, 10);
            }

            foreach (Product storeShoes in productShoes)
            {
                storeList[2].inventory.Add(storeShoes, 100);
            }

        }
        */

        public int FindCustomerID(string firstName, string lastName)
        {
            int foundID = 0;
            queryString = "SELECT CustomerID FROM Customers WHERE FirstName LIKE '" + firstName + "' AND LastName LIKE '" + lastName + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                foundID = Int32.Parse(dr[0].ToString());
            }
            catch (InvalidOperationException) //have to do this if the select gives nothing
            {
                foundID = 0;
            }
            con.Close();
            return foundID;
        }

        public void AddNewCustomer(string firstName, string lastName)
        {
            queryString = "INSERT INTO Customers (FirstName, LastName) " +
                          "VALUES (@FN, @LN)";
            SqlCommand cmd = new SqlCommand(queryString, con);
            cmd.Parameters.Add("@FN", System.Data.SqlDbType.NVarChar, 50).Value = firstName;
            cmd.Parameters.Add("@LN", System.Data.SqlDbType.NVarChar, 15).Value = lastName;

            // open connection, execute command and close connection
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        

        public void AddToCart(int storeID, int prodID, int quantity) //new param, productID and quantity, put those into currentOrderItem obj
        {
            //take product from sql table and put it into currentOrderItem object to store in cart

            queryString = "SELECT ProductName, ProductPrice, ProductDesc " +
                          "FROM Inventory i LEFT JOIN Products p " +
                          "ON i.ProductID = p.ProductID " +
                          "WHERE StoreID = " + storeID.ToString() + " AND p.ProductID = " + prodID.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            currentProduct = new Product(prodID, dr[0].ToString(), Double.Parse(dr[1].ToString()), dr[2].ToString());
            con.Close();
            currentOrderItem = new OrderItem(currentProduct, quantity, storeID);
            //all currrentOrderItem fields populated

            //Add currentOrderItem(product and quantity of product) to cart of current Customer
            currentOrder.Items.Add(currentOrderItem);
            currentOrder.totalCost += currentOrderItem.BuyProduct.price * quantity;
            countingOrders++;   //increment every time so order IDs are unique
            currentOrder.orderID = countingOrders;
        }

        public void removeFromCart(int index)
        {
            currentOrder.Items.RemoveAt(index - 1);
        }

        public void clearCart()
        {
            currentOrder.Items.Clear();
        }

        public void viewCart()
        {

            Console.WriteLine("\n#. Name \tPrice \tQuantity");
            try
            {
                for(int count = 1; count < currentOrder.Items.Count; count++)
                {
                    Console.WriteLine(count + ". " + currentOrder.Items[count].BuyProduct.name + "\t" + currentOrder.Items[count].BuyProduct.price + "\t" + currentOrder.Items[count].quantity);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Cart is empty.");
            }
        }

        public bool checkCartLimit()
        {
            if (currentOrder.totalCost > 500 || currentOrder.Items.Count > 50)
                return false;
            else
                return true;
        }

        public void purchaseCart(int custID)//purchase what's in the cart and push it into pastsales
        {
            queryString = "INSERT INTO PastSales (ProductID, Quantity, OrderDate, totalAmount, CustomerID, StoreID) " +
                          "VALUES (@PI, @Q, CAST('@OD') AS DATE, @tA, @CI, @SI)";
            foreach (OrderItem o in currentOrder.Items)
            {
                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.Add("@PI", System.Data.SqlDbType.Int).Value = o.BuyProduct.prodID;
                cmd.Parameters.Add("@Q", System.Data.SqlDbType.Int).Value = o.quantity;
                cmd.Parameters.Add("@OD", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@tA", System.Data.SqlDbType.Money).Value = o.BuyProduct.price * o.quantity;
                cmd.Parameters.Add("@CI", System.Data.SqlDbType.Int).Value = custID;
                cmd.Parameters.Add("@SI", System.Data.SqlDbType.Int).Value = o.storeID;
                
                // open connection, execute command and close connection
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public int ValidateIntInput(string choice, int maxInput)
        {
            bool conversionBool = false;
            conversionBool = Int32.TryParse(choice, out int convertedNumber);
            if (!conversionBool || convertedNumber < 1 || convertedNumber > maxInput)
            {
                Console.WriteLine("Invalid Input.");
                return 0;
            }
            return convertedNumber;
        }

        public int ValidateProdInput(string choice, int storeID)
        {
            bool conversionBool = false;
            int minInput = 0, maxInput = 0;
            queryString = @"SELECT MIN(p.ProductID), MAX(p.ProductID)
                            FROM Inventory i LEFT JOIN Products p
                            ON i.ProductID = p.ProductID
                            WHERE StoreID = " + storeID.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            minInput = Int32.Parse(dr[0].ToString());
            maxInput = Int32.Parse(dr[1].ToString());
            con.Close();

            conversionBool = Int32.TryParse(choice, out int convertedNumber);
            if (!conversionBool || convertedNumber < 1 || convertedNumber > maxInput || convertedNumber < minInput)
            {
                Console.WriteLine("Invalid Product Input.");
                return 0;
            }
            return convertedNumber;
        }

        public int ValidateQuantInput(string choice, int storeID, int prodID)
        {
            bool conversionBool = false;
            int maxInput = 0;
            queryString = @"SELECT Quantity
                            FROM Inventory i LEFT JOIN Products p
                            ON i.ProductID = p.ProductID
                            WHERE StoreID = " + storeID.ToString() + " AND p.ProductID =" + prodID.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            maxInput = Int32.Parse(dr[0].ToString());
            con.Close();

            conversionBool = Int32.TryParse(choice, out int convertedNumber);
            if (!conversionBool || convertedNumber < 0 || convertedNumber > maxInput)
            {
                Console.WriteLine("Store does not contain that much product.");
                return -1;
            }
            return convertedNumber;
        }
    }

}
