using Duo.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Duo
{
    public partial class DuoApi
    {
        /// <summary>
        /// Get paged users
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public User[] GetUsers(
            [Range(1,300)] 
            ushort limit, 
            out PagingInfo? pagingInfo,
            ushort offset = 0)
        {
            var parameters = new Dictionary<string, string>();
            var users = this.JSONPagingApiCall<User[]>(
                "GET", "/admin/v1/users", parameters,offset, limit, out pagingInfo);

            return users;
        }

        /// <summary>
        /// Get a single user by username
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public User GetUser(string userName)
        {
            var parameters = new Dictionary<string, string> { { "username" , userName } };
            var users = this.JSONApiCall<User[]>(
                "GET", "/admin/v1/users", parameters);

            return users.SingleOrDefault();
        }
    }
}
