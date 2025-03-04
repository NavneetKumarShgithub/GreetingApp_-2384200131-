using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
