using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DAL;
using ShoppingCart.Domain;

namespace ShoppingCart.BLL
{
    public class CartBLL
    {
        private CartDAL cartdal;

        public CartBLL()
        {
            cartdal = new CartDAL(); 

        }
        public  List<UsersDetails> GetUserList()
        {
            return cartdal.GetUserList();
        }
        public void InsertNewUser(string name,string username , string password , string phonenumber)
        {
            cartdal.InsertNewUser(name, username, password, phonenumber);
        }
        public List<ProductDetails> GetProductList()
        {
            return cartdal.GetProductList();
        }
        public void UpdateQuantity(int productid, int Quantity)
        {
            cartdal.UpdateQuantity(productid,Quantity);
        }
    }
}
