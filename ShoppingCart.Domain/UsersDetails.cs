using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain
{
    public class UsersDetails
    {
        public int UserID {  get; set; }
        public string Name {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string HNo { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public int PinCode { get; set; }
    }

    public class ProductDetails
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public class CartItemDetails
    {
        public int ProductID { get; set; }
        public string UserName { get; set; }
        public double TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
    }
}


