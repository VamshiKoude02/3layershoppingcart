using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private List<UsersDetails> UserList;
        private List<CartItemDetails> CartList;
        public string username1;
        public ShoppingInterface()
        {
            user = new UsersDetails();
            cartbll = new CartBLL();
            products = cartbll.GetProductList();
            UserList = cartbll.GetUserList();
            CartList = new List<CartItemDetails>();
            product = new ProductDetails();

        }
        public string UserName(string username)
        {
            username1 = username;
            return username1;
        }
        public void ProductList()
        {
            Console.WriteLine($"{"ProductID",-12}{"ProductName",-18}{"Price",-8}{"Quantity",-10}");
            foreach (ProductDetails product in products)
            {
                Console.WriteLine($"{product.ProductID,-12}  {product.ProductName,-15} {product.Price,-8} {product.Quantity,-10}");
            }
        }
        public void AddItemsToCart()
        {
            ProductList();
            Console.WriteLine("Enter ProductID which you want to add to cart");
            int productid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Quantity of the Product");
            int providedquantity = Convert.ToInt32(Console.ReadLine());
            ProductDetails selectedProduct = products.FirstOrDefault(product => product.ProductID == productid);

            if (providedquantity > selectedProduct.Quantity)
            {
                Console.WriteLine($"Provided quantity is not available. Only {selectedProduct.Quantity} units are in stock. Please enter a correct quantity.");
            }
            else if (selectedProduct.Quantity == 0)
            {
                Console.WriteLine("Product Out of stock");
            }
            else if (providedquantity <= selectedProduct.Quantity)
            {
                CartList.Add(new CartItemDetails
                {
                    ProductID = productid,
                    UserName = username1,
                    TotalPrice = selectedProduct.Price,
                    TotalQuantity = providedquantity
                });
                selectedProduct.Quantity -= providedquantity;
                cartbll.UpdateQuantity(productid,selectedProduct.Quantity);
                Console.WriteLine($"Successfully added {providedquantity} unit(s) of {selectedProduct.ProductName} to the cart.");
            }

        }
        public void ViewCartItems()
        {
            Console.WriteLine($"{"UserName",-12}{"ProductID",-15}{"Item Price",-15}{"Quantity selected",-10}");
            foreach (CartItemDetails cartitem in CartList)
            {
                Console.WriteLine($"{cartitem.UserName,-12}  {cartitem.ProductID,-15} {cartitem.TotalPrice,-18} {cartitem.TotalQuantity,-10}");
            }
        }

        public void UpdatedPriceOfViewCartItems()
        {
            Console.WriteLine($"{"UserName",-12}{"ProductID",-15}{"Total Price",-15}{"Total Quantity",-10}");
            foreach (CartItemDetails cartitem in CartList)
            {
                cartitem.TotalPrice = cartitem.TotalPrice * cartitem.TotalQuantity;
                Console.WriteLine($"{cartitem.UserName,-12}  {cartitem.ProductID,-15} {cartitem.TotalPrice,-18} {cartitem.TotalQuantity,-10}");
            }
        }
        public void PlaceAnOrder()
        {
        IsCartOk:
            UpdatedPriceOfViewCartItems();
            Console.WriteLine("Are you Okay with CartItems(yes/no).?");
            string cart = Console.ReadLine().ToLower();
            if (cart == "yes")
            {
                var ordersummary = CartList.GroupBy(x => x.UserName).Select(x => new { UserName = x.Key, TotalQuantity = x.Sum(item => item.TotalQuantity), TotalFinalPrice = x.Sum(item => item.TotalPrice) }).ToList();
                int items = 0;
                foreach (var item in ordersummary)
                {
                    items = item.TotalQuantity;
                    Console.WriteLine($"{item.UserName} of Item(s) {item.TotalQuantity} of cost {item.TotalFinalPrice}Rs");
                }
                Console.WriteLine("Is it Okay for Payment.(yes/no)");
                string payment = Console.ReadLine().ToLower();
                if (payment == "yes")
                {
                    Console.WriteLine("Re-directing to Payment App");
                    Console.WriteLine("Payment Module under Development");
                    Console.WriteLine($"{items} items Order Placed Sucessfully.. ");
                    Console.WriteLine("Thanks For Shopping");
                }
                else if (payment == "no")
                {
                    goto IsCartOk;
                }

            }
            else if (cart == "no")
            {
                CartNotOk:
                Console.WriteLine("Do you want to remove any item.(yes/no)?");
                string input = Console.ReadLine().ToLower();
                if (input == "yes")
                {
                    ViewCartItems();
                    Console.WriteLine("Enter ProductID which you want to remove.");
                    int productid = Convert.ToInt32(Console.ReadLine());
                    CartList.RemoveAll(item => item.ProductID == productid);
                }
                else if(input == "no")
                {
                    goto IsCartOk;
                }
                else
                {
                    Console.WriteLine("Enter correct Input");
                    goto CartNotOk;
                }
            }
            else
            {
                Console.WriteLine("Enter correct Input");
                goto IsCartOk;
            }
        }
        public void AccountDetails()
        {
            var userDetails = UserList.Where(x => x.UserName == username1).Select(x => (x.UserID, x.Name, x.PhoneNumber)).First();
            Console.WriteLine($"UserID: {userDetails.UserID}, Name: {userDetails.Name}, UserName: {username1}, MobileNumber: {userDetails.PhoneNumber}");
        }
        public int Options()
        {
            Console.WriteLine("What you want to do now?");
            Console.WriteLine("1. Product List");
            Console.WriteLine("2. Add Item(s) to Cart");
            Console.WriteLine("3. View Cart Items");
            Console.WriteLine("4. Place an Order");
            Console.WriteLine("5. Account Details");
            Console.WriteLine("6. Exit");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
        public void ShoppingOptions()
        {
            ShoppingOptions:
            int input = Options();
            if (input == 1)
            {
                ProductList();
                goto ShoppingOptions;
            }

            else if(input == 2)
            {
                AddItemsToCart();
                goto ShoppingOptions;
            }

            else if (input == 3)
            {
                ViewCartItems();
                goto ShoppingOptions;
            }

            else if( input == 4)
            {
                PlaceAnOrder();
                goto ShoppingOptions;
            }
            else if(input == 5)
            {
                AccountDetails();
                goto ShoppingOptions;
            }
            else if(input == 6)
            {
                Console.WriteLine("Double Press AnyKey to Exit.");
            }
            else
            {
                Console.WriteLine("Enter correct Input..!");
                goto ShoppingOptions;
            }
        }
    }
}
