using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingCart.UI
{
    class Users
    {
        static Domain.UsersDetails user;
        static Users()
        {
            user = new Domain.UsersDetails();
        }
        public static void UserRegistration()
        {

            Console.WriteLine("Enter Name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter UserName");
            user.UserName = Console.ReadLine();
            //var username = from user in userregistration where user.Username == user.UserName select user.Username;
            Console.WriteLine("Enter Password");
            user.Password = Console.ReadLine();
            Console.WriteLine("Enter Confrim Password");
        ReEnterPassword:
            string ConfrimPassword = Console.ReadLine();
            if (ConfrimPassword != user.Password)
            {
                Console.WriteLine("Password Didn't Match.Please Re-Enter.");
                goto ReEnterPassword;
            }
            Console.WriteLine("Enter mobile Number");
        ReEnterPhoneNumber:
            user.PhoneNumber = Console.ReadLine();
            if (user.PhoneNumber.Length != 10)
            {
                Console.WriteLine("Phone Number must be 10 Digits. Please Re-Enter");
                goto ReEnterPhoneNumber;
            }
        }
        public static void UserLogin()
        {
            Console.WriteLine("Enter UserName");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Enter password");
            user.Password = Console.ReadLine();
        }


        public static void UserVerification()
        {
            Console.WriteLine("Do You Want to Register or Login?");
            RorL:
            string input = Console.ReadLine().ToLower();
            if (input == "register")
            {
                UserRegistration();
            }
            else if (input == "login")
            {
                UserLogin();
            }
            else
            {
                Console.WriteLine("Enter Correct Input..!");
                goto RorL;
            }

        }
    }
}
