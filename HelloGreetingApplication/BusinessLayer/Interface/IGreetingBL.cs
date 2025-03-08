using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        public string HelloWorldPrint();

        public string UserAttributeMsgBL(UserModel userModel);

        public bool AddGreeting(GreetingModel greetingModel);

        

        //public string GetGreetingById(int id);
    }
}
