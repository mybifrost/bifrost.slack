using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Gets a list of all Slack users in the current team.
        /// </summary>
        /// <param name="forceRefresh">True if the user data must be pulled from the server, false if local cache can be used.</param>
        /// <returns>A list of all Slack users in the current team.</returns>
        Task<IEnumerable<User>> GetAllUsersAsync(bool forceRefresh = false);

        /// <summary>
        /// Gets a Slack user in the current team based on the user's ID.
        /// </summary>
        /// <param name="id">User ID to be found.</param>
        /// <returns>User data if the ID was found, null otherwise.</returns>
        /// <remarks>This will always pull from local cache if available.</remarks>
        Task<User> GetUserAsync(IUserId id);

        /// <summary>
        /// Clears the local cache of Users.
        /// </summary>
        void ClearCache();
    }
}
