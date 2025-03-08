using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    { 
        public List<UserModel> nameList {  get; set; }
        public string HelloWorldPrint();

        public bool MessageAddRL(GreetingModel greetingModel);

        public string UserAttributeMsg(UserModel userModel);

        public UserEntity FindMessageRL(RequestMessageId requestMessageId);
    }
}
