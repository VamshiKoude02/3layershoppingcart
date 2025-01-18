using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Domain;
using ShoppingCart.UI;

namespace ShoppingCart.UI
{
    class CartUI
    {
        static void Main(string[] args)
        {
            Users users = new Users();
            users.UserVerification();
            Console.Read();
        }
    }
}
