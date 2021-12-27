using System;
using Xunit;
using Storage;
using Domain;


namespace Testing
{
    public class UnitTest1
    {
        [Fact]//for a single test
        public void testCartCheckCount()
        {
            //Arrange - set up the environment, mock classes & dependencies
            var di = new Displays();

            //Act - complete the action you will be testing
            di.AddToCart(1, 4, 52);

            //Assert - assert the results are expected
            Assert.Equal((52*19.99), di.currentOrder.totalCost);

            Assert.False(di.checkCartLimit());

        }

        [Fact]
        public void testAddToCart()
        {
            //Arrange
            var di = new Displays();
            int storeID = 1;
            int prodID = 1;
            int quantity = 3;

            //Act
            di.AddToCart(storeID, prodID, quantity);

            //Assert
            Assert.Equal((39.99 * 3), di.currentOrder.totalCost);

        }

        [Fact]
        public void checkValidations()
        {
            //Arrange
            string int1 = "1";
            string prod1 = "1";
            string quant1 = "1";
            string int2 = "101";
            string prod2 = "101";
            string quant2 = "101";
            int testStoreID = 1;
            int testProdID = 3;
            var di = new Displays();

            //Act
            di.ValidateIntInput(int1, 49);
            di.ValidateProdInput(prod1, testStoreID);
            di.ValidateQuantInput(quant1, testStoreID, testProdID);

            di.ValidateIntInput(int2, 49);
            di.ValidateProdInput(prod2, testStoreID);
            di.ValidateQuantInput(quant2, testStoreID, testProdID);

            //Assert
            Assert.Equal(1, di.ValidateIntInput(int1, 49));
            Assert.Equal(1, di.ValidateProdInput(prod1, testStoreID));
            Assert.Equal(1, di.ValidateQuantInput(quant1, testStoreID, testProdID));

            Assert.Equal(0, di.ValidateIntInput(int2, 49));
            Assert.Equal(0, di.ValidateProdInput(prod2, testStoreID));
            Assert.Equal(-1, di.ValidateQuantInput(quant2, testStoreID, testProdID));

        }
    }
}
