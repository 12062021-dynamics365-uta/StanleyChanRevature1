using System;
using System.Collections.Generic;
using Storage;
using Domain;
using System.Data.SqlClient;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Displays d = new Displays();
            int storeID = 0;
            int custID = 0;
            string custFirstName, custLastName;
            int menuNav = 0;
            //int validChoice = 0 ;
            Console.WriteLine("Mock Store App Init" );
            
            //prompt Customer login
            Console.WriteLine("First Name: ");
            custFirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            custLastName = Console.ReadLine();
            //search for Customer in Storage
            custID = d.FindCustomerID(custFirstName, custLastName);
            //else create new and add to Storage
            if (custID == 0)
            {
                d.AddNewCustomer(custFirstName, custLastName);
            }
          
            while(menuNav != 1)
            {
                storeID = MainMenu(d, custID);
                Console.WriteLine("_______________________________");
                Console.WriteLine("1. Start Shopping\n2. View past purchases of this store\n3. Back");
                do
                {
                    menuNav = d.ValidateIntInput(Console.ReadLine(), 3);
                } while (menuNav == 0);
                switch(menuNav)
                {
                    case 1:
                        Console.WriteLine(""); //formatting line space only
                        d.ShowProducts(storeID);
                        ShopLoop(d, custFirstName, custLastName, storeID, custID);
                        //
                        break;
                    case 2:
                        d.ShowPastOfStore(storeID);
                        break;
                    case 3:
                        //do nothing
                        break;
                }
            }
            
       
            
            


        }

        public static int MainMenu(Displays d, int custID)
        {
            int mainNav = 0;
            int storeID = 0;
            do //infinite loops unless you exit or choose a store
            {
                Console.WriteLine("_______________________________");
                Console.WriteLine("1. Choose Store\n2. View all past purchases\n3. Exit");
                do
                {
                    mainNav = d.ValidateIntInput(Console.ReadLine(), 3);                   
                } while (mainNav == 0);
                Console.WriteLine(); //just for formatting
                switch (mainNav)
                {
                    case 1:
                        storeID = d.StoreNavigation();
                        break;
                    case 2:
                        d.ShowPastOfCust(custID);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        //it made me put this in, I already made sure of this thru ValidateIntInput
                        Console.Write("If you see this, my validate function is broken.");
                        Environment.Exit(0);
                        break;
                }
            } while (mainNav == 0 || storeID == 0);
            return storeID;
        }

        public static void ShopLoop(Displays d, string firstName, string lastName, int shopID, int custID)
        {
            /*switch case menu? 
                1. Buy Products
                    1a. Add to Cart - check if cart items > 50 || totalCoast >500
                    2b. Back
                2. Remove from Cart
                    2a. remove one order, quantity of(stretch)
                    2b. clear all
                    2c. Back
                3. View Cart
                4. Checkout
                    4a. confirm checkout
                    4b. cancel all
                    4c. Back
                5. Back to Stores
            */
            Customer shopper = new Customer(firstName, lastName);
            int shopNav = 0, prodID = 0, quant = -1, addCartLoop = 1, removeCartLoop = 3, removeChoice = 0, clearChoice = 0, confirmCheckout = 0;
            bool cartCheck = true;
            do
            {
                Console.WriteLine("_______________________________");
                Console.WriteLine("1. Add to Cart\n2. Remove from Cart\n3. View Cart \n4. Checkout\n5. Back");
                shopNav = d.ValidateIntInput(Console.ReadLine(), 5);

                switch(shopNav)
                {
                    case 1:
                        do
                        {
                            do
                            {
                                Console.WriteLine("Select a product by its number.");
                                prodID = d.ValidateProdInput(Console.ReadLine(), shopID);

                            } while (prodID == 0);
                            do
                            {
                                Console.WriteLine("How many of this item do you want to buy?");
                                quant = d.ValidateQuantInput(Console.ReadLine(), shopID, prodID);
                                if (quant == 0)
                                    Console.WriteLine("You chose to not buy any of this product.");
                            } while (quant == -1);
                            cartCheck = d.checkCartLimit();
                            
                            if(!cartCheck)//check if cart cost > 500 or items > 50
                            {
                                Console.WriteLine("Cart is over limit.");
                            }

                            if (quant != 0 && cartCheck)
                            {
                                d.AddToCart(shopID, prodID, quant);
                            }

                            Console.WriteLine("1. Buy more items \n2. I'm done buying");
                            addCartLoop = d.ValidateIntInput(Console.ReadLine(), 2);
                        } while (addCartLoop == 1);
                        break;
                    case 2:
                        //make removefromCart method
                        Console.WriteLine("1. Remove from cart\n2. Clear cart\n3. Cancel");
                        removeCartLoop = d.ValidateIntInput(Console.ReadLine(), 3);
                        switch(removeCartLoop)
                        {
                            case 1:
                                d.viewCart();
                                Console.WriteLine("Which items do you want to remove? (Select by line number)");
                                removeChoice = d.ValidateIntInput(Console.ReadLine(), d.currentOrder.Items.Count);
                                d.removeFromCart(removeChoice);
                                break;
                            case 2:
                                Console.WriteLine("Are you sure? \n1. Yes\n2. No");
                                clearChoice = d.ValidateIntInput(Console.ReadLine(), 2);
                                if (clearChoice == 1)
                                    d.clearCart();
                                break;
                            case 3:
                                break;
                        }
                        break;
                    case 3:
                        d.viewCart();
                        break;
                    case 4:
                        Console.WriteLine("Are you sure? \n1. Yes\n2. No");
                        confirmCheckout = d.ValidateIntInput(Console.ReadLine(), 2);
                        if (confirmCheckout == 1)
                            d.purchaseCart(custID);
                        break;
                    default:
                        break;
                }    

            } while (shopNav != 5);
        }
    }
}
