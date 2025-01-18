using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShoppingCart.BLL;
using ShoppingCart.Domain;

namespace ShoppingCart.UI
{
    class Users
    {

        private UsersDetails user;
        private CartBLL cartbll;
        private List<UsersDetails> UserList;
        private ShoppingInterface ShoppingInterface;
        public Users()
        {
            user = new UsersDetails();
            cartbll = new CartBLL();
            UserList = cartbll.GetUserList();
            ShoppingInterface = new ShoppingInterface();
        }



        public void UserRegistration()
        {

            Console.WriteLine("Enter Name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter UserName");
            ReEnterUserName:
            user.UserName = Console.ReadLine();
            if(user.UserName.Any(char.IsUpper) || !user.UserName.All(c => char.IsLetterOrDigit(c)))
            {
                Console.WriteLine("Username doesn't contains Uppercase letters (Or) Special characters. Please Re-Enter");
                goto ReEnterUserName;
            }
            List<string> UsernamesList = UserList.Select(u => u.UserName).ToList();
            while (UsernamesList.Contains(user.UserName))
            {
                Console.WriteLine("Username Already Exists. Try another Username.");
                goto ReEnterUserName;
            }
            Console.WriteLine("Enter Password");
            EnterCorrectPassword:
            user.Password = Console.ReadLine();
            if(!user.Password.Any(char.IsUpper) || !user.Password.Any(c => !char.IsLetterOrDigit(c)) || !user.Password.Any(char.IsDigit)) 
            {
                Console.WriteLine("Password must include at least one special character and one uppercase letter.");
                goto EnterCorrectPassword;
            }
            Console.WriteLine("Enter Confrim Password");
            ReEnterPassword:
            string ConfrimPassword = Console.ReadLine();
            if (ConfrimPassword != user.Password)
            {
                Console.WriteLine("Password Didn't Match. Please Re-Enter.");
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
            cartbll.NewUser(user.Name, user.UserName, user.Password, user.PhoneNumber);
            Console.WriteLine("User Registered Successfully. Redirecting to Login page...");
            UserLogin();
        }



        public void UserLogin()
        {
            EnterValidCredentails:
            Console.WriteLine("Enter UserName");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Enter password");
            user.Password = Console.ReadLine();
            List<(string UserName , string Password)> UserCredentailsList = UserList.Select(x => (x.UserName, x.Password)).ToList();
            if (UserCredentailsList.Any(cred => cred.UserName == user.UserName && cred.Password == user.Password))
            {
                Console.WriteLine("Login Successful.");
                ShoppingInterface.ShoppingOptions();

            }
            else
            {
                Console.WriteLine("Invalid Credentails. Please Re-Enter");
                goto EnterValidCredentails;
            }
        }



        public void UserVerification()
        {
            Console.WriteLine("Do You Want to 1.Register (or) 2.Login?");
            RorL:
            string input = Console.ReadLine().ToLower();
            if (input == "1")
            {
                UserRegistration();
            }
            else if (input == "2")
            {
                UserLogin();
            }
            else
            {
                Console.WriteLine("Enter Correct Input..!");
                goto RorL;
            }
            //if (input == "register")
            //{
            //    UserRegistration();
            //}
            //else if (input == "login")
            //{
            //    UserLogin();
            //}
            //else
            //{
            //    Console.WriteLine("Enter Correct Input..!");
            //    goto RorL;
            //}
        }
    }
}
