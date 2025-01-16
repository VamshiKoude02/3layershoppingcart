using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Domain;

namespace ShoppingCart.UI
{
    class CartUI
    {
        static void Main(string[] args)
        {
            Users.UserVerification();
            Console.Read();
        }
    }
}
