using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ShoppingCart.Domain;

namespace ShoppingCart.DAL
{
    public class CartDAL
    {
        private SqlConnection con;
        private SqlDataAdapter da;
        private DataSet ds;
        private DataTable dt;

        public CartDAL()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cart"].ConnectionString);
            ds = new DataSet();
            dt = new DataTable();
        }

        public List<UsersDetails> GetUserList()
        {
            List<UsersDetails> UserList = new List<UsersDetails>();
            try
            {
                ds.Clear();
                da = new SqlDataAdapter("select * from Users", con);
                da.Fill(ds, "users");
                foreach (DataRow dr in ds.Tables["users"].Rows)
                {
                    UsersDetails user = new UsersDetails()
                    {
                        UserID = Convert.ToInt32(dr["userid"]),
                        Name = dr["name"].ToString(),
                        UserName = dr["username"].ToString(),
                        Password = dr["password"].ToString(),
                        PhoneNumber = dr["Mobilenumber"].ToString(),
                    };
                    UserList.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return UserList;
        }

        public void InsertNewUser(string name, string username, string password, string phonenumber)
        {
            try
            {
                DataRow ur = dt.NewRow();
                da = new SqlDataAdapter("select * from users", con);
                da.Fill(dt);
                ur["name"] = name;
                ur["username"] = username;
                ur["password"] = password;
                ur["mobilenumber"] = phonenumber;
                dt.Rows.Add(ur);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public List<ProductDetails> GetProductList()
        {
            List<ProductDetails> products = new List<ProductDetails>();
            try
            {
                da = new SqlDataAdapter("select * from products", con);
                da.Fill(ds, "productslist");
                foreach (DataRow dr in ds.Tables["productslist"].Rows)
                {
                    ProductDetails product = new ProductDetails()
                    {
                        ProductID = Convert.ToInt32(dr["productid"]),
                        ProductName = dr["productname"].ToString(),
                        Price = Convert.ToDouble(dr["price"]),
                        Quantity = Convert.ToInt32(dr["quantity"])
                    };
                    products.Add(product);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return products;
        }

        public void UpdateQuantity(int productid, int quantity)
        {
            try
            {
                da = new SqlDataAdapter($"select * from products where productid = {productid}", con);
                dt.Clear();
                da.Fill(dt);
                DataRow dr = dt.Rows[0];
                dr["quantity"] = quantity;
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
