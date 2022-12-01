using Duo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Duo
{
    /// <summary>
    /// A DUO Admin Api client
    /// </summary>
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
        /// Gets a single user by <see cref="User.UserName"/>.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <returns></returns>
        /// <remarks>Username appears to be recyclable, but should be unique at a given point in time.
        /// <see cref="User.User_Id"/> is permanently uniquely identifying a <see cref="User"/>.
        /// </remarks>
        public User GetUser(string userName)
        {
            var parameters = new Dictionary<string, string> { { "username" , userName } };
            var users = this.JSONApiCall<User[]>(
                "GET", "/admin/v1/users", parameters);

            return users.SingleOrDefault();
        }
    }
}
