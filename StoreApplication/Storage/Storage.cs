using System;
using System.Collections.Generic;

namespace Storage
{
    public class Customer
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public List<Order> purchased { get; set; }
        public Order cart { get; set; }

        public Customer(string firstName, string lastName)
        {
            fName = firstName;
            lName = lastName;
        }

        public void checkout()
        {
            purchased.Add(cart);
        }
        public static void cancel()
        {

        }
        /*must be able to view past purchases
        must be able to view available store locations
        must be able to purchase 1 or more products
        must be able to view current cart
        must be able to checkout
        must be able to cancel a purchase*/
    }

    public class Product
    {
        public int prodID { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string desc { get; set; }
        //must have a name, price, and description

        private int productID { get; set; }


        public Product(string name, double price, string desc)
        {
            this.name = name;
            this.price = price;
            this.desc = desc;
        }

        private Store belongsTo { get; set; }
        //to view purchases of a store
    }

    public class OrderItem
    {
        public Product BuyProduct { get; set; }
        public int quantity { get; set; }

        public int storeID { get; set; }

        public OrderItem(Product BuyProduct, int quantity)
        {
            this.BuyProduct = BuyProduct;
            this.quantity = quantity;
        }
    }

    public class Order
    {   //use dictionary<keyvalue, product> productDict over list?

        public int orderID { get; set; }
        public double totalCost
        {
            get { return totalCost; }
            set
            {
                for (int index = 0; index < Items.Count; index++)
                {
                    totalCost += (Items[index].BuyProduct.price * Items[index].quantity); //price * quantity
                }
                if (totalCost > 500)
                {
                    //limit it somehow, probably within logic/Domain class rather than here
                }
            }
        }
        public Customer Buyer { get; set; }
        public List<OrderItem> Items
        {
            get { return Items; }
            set
            {

                if (Items.Count > 50)
                {
                    //do nothing & print error message
                }
            }


        }//Order consists of list of OrderItems that are certain quantities of product

        /*must be able to compute its total cost
        must be able to contain at least 1 product
        must be able to limit its content to no more than 50 items
        must be able to limit its total cost to no more than $500*/
    }

    public class Store
    {
        public string storeName { get; set; }

        public string location { get; set; }

        public Dictionary<Product, int> inventory { get; set; }

        List<Order> PastSales { get; set; }

        public Store(string storeName, string location)
        {
            this.storeName = storeName;
            this.location = location;
        }

        /*must be able to view past sales
        must be able to view sales by store location
        [stretch goal] must be able to manage product inventory(add, edit, delete any product)*/
    }
}
