using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users.Internal
{
    internal class UserService : IUserService
    {
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return new List<User>();
        }
    }
}
