using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Service;

namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL greetingRl;

        public GreetingBL(IGreetingRL greetingRl)
        {
            this.greetingRl = greetingRl;
        }

        public string HelloWorldPrint()
        {
            var message = greetingRl.HelloWorldPrint();
            return message;

        }
        public string UserAttributeMsgBL(UserModel userModel)
        {
            var message = greetingRl.UserAttributeMsg(userModel);
            if (message == null)
            {
                return "Hello World!";
            }
            else if (message == userModel.FirstName)
            {
                return userModel.FirstName + "Hello";
            }
            else 
            {
                return "Hello" + userModel.LastName;
            }
        }
        public bool AddGreeting(GreetingModel greetingModel)
        {
            var result = greetingRl.MessageAddRL(greetingModel);
            if(result)
            {
                return true;
            }
            return false;
        }
        public GreetingModel FindMessageBL(RequestMessageId requestMessageId)
        {
            GreetingModel greetingModel = new GreetingModel();
            var result = greetingRl.FindMessageRL(requestMessageId);
            if (result != null)
            {
                greetingModel.GreetingMessage = result.GreetingMessage;
                return greetingModel;
            }
            return greetingModel;
        }
    }
}
