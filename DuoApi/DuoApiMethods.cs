using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo
{
    public partial class DuoApi
    {
        public IList GetUsers()
        {
            var parameters = new Dictionary<string, string>();
            var users = this.JSONApiCall<System.Collections.ArrayList>(
                "GET", "/admin/v1/users", parameters);

            return users;
        }
    }

    public class User
    {
        public int Created { get; set; }
        public string Email { get; set; }
    }
}
