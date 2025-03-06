using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        public List<UserModel> nameList = new(){        
            new UserModel {FirstName = "Tushar", LastName = "Kumar" },
            new UserModel {FirstName = "Uday", LastName = "Saraswat " },
            new UserModel {FirstName = "Yash", LastName = " Kumar" },
            new UserModel {FirstName = "Rohit", LastName = " Dixit" },
            new UserModel {FirstName = "Roy", LastName = " Sharma" },
        };

        List<UserModel> IGreetingRL.nameList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string HelloWorldPrint()
        {
            return "Hello World!";
        }
        //public string HelloWorldPrint ()
        //{
        //    return "Hello World!";
        //}

        public string UserAttributeMsg(UserModel userModel)
        {
            foreach (var user in nameList)
            {
                if (userModel.FirstName == user.FirstName)
                {
                    return userModel.FirstName;
                }
                else if (userModel.LastName == user.LastName)
                {
                    return userModel.LastName;
                }
                
            }
            return null;
            
        }
    }
}
