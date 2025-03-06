using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    { 
        public List<UserModel> nameList {  get; set; }
        public string HelloWorldPrint();

        public string UserAttributeMsg(UserModel userModel);
        
    }
}
