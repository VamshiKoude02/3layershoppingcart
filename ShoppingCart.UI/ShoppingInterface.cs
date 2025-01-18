using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.BLL;
using ShoppingCart.Domain;

namespace ShoppingCart.UI
{
    class ShoppingInterface
    {
        private UsersDetails user;
        private CartBLL cartbll;
        private List<ProductDetails> products;
        private ProductDetails product;
        public ShoppingInterface()
        {
            user = new UsersDetails();
            cartbll = new CartBLL();
            products = cartbll.GetProductList();
            product = new ProductDetails();

        }

        public void ShoppingOptions()
        {
            Console.WriteLine("What you want to do now?");
            SelectCorrectOption:
            Console.WriteLine("1. Product List");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. View Cart Items");
            Console.WriteLine("4. Place an Order");
            Console.WriteLine("5. Account Details");
            Console.WriteLine("6.Exit");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine("ProductID   -   ProductName   -   Price   -  Quantity");
                foreach(ProductDetails product in products)
                {
                    Console.WriteLine($"{product.ProductID} - {product.ProductName} - {product.Price} - {product.Quantity}");
                }
            }
            else if(input == 2)
            {

            }
            else if (input == 3)
            {

            }
            else if( input == 4)
            {

            }
            else if(input == 5)
            {

            }
            else if(input == 6)
            {

            }
            else
            {
                Console.WriteLine("Enter correct Input..!");
                goto SelectCorrectOption;
            }
        }
    }
}
