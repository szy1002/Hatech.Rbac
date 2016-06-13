using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hatech.Rbac.WebApi
{
    public class AccountController : ApiController
    {
        private static List<User> users;

        static AccountController()
        {
            users = new List<WebApi.User>();
        }

        public string Get()
        {
            return "Hello World";
        }

        public bool Login([FromBody] User user)
        {
            return users.Find(x => x.Name == user.Name && x.Pwd == user.Pwd) != null;
        }

        public bool Register([FromBody] User user)
        {
            if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Pwd))
            {
                if (users.Any(x=>x.Name == user.Name))
                {
                    return false;
                }
                users.Add(new User { Name = user.Name, Pwd = user.Pwd });
                return true;
            }
            return false;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Pwd { get; set; }
    }
}
