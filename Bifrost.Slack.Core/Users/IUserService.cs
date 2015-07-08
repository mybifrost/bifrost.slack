using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
