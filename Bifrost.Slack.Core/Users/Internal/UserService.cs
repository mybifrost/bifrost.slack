using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users.Internal
{
    internal class UserService : IUserService
    {
        private ISlackRestClient _restClient;
        private SQLiteConnection _database;
        public UserService(ISlackRestClient restClient, ISQLite sqlite)
        {
            _restClient = restClient;
            _database = sqlite.GetConnection();

            _database.CreateTable<User>();
            _database.CreateTable<UserProfile>();
        }

        /// <summary>
        /// Gets a list of all Slack users in the current team.
        /// </summary>
        /// <param name="forceRefresh">True if the user data must be pulled from the server, false if local cache can be used.</param>
        /// <returns>User data if the user ID was found in the current team.  Null if the user was not found.</returns>
        public async Task<IEnumerable<User>> GetAllUsersAsync(bool forceRefresh = false)
        {
            // default behavior, try to pull from the local cache
            if (!forceRefresh)
            {
                return _database.GetAllWithChildren<User>();
            }
            else
            {
                // pull a list of users from the server
                var request = new GetAllUsersRequest();
                var response = await _restClient.RequestAsync<GetAllUsersResponse>(request);

                // TODO: should be checking response.Ok to make sure it succeeded, and handle the error if it didn't

                // cache the list of users locally
                CacheAllUsers(response.Members);

                return response.Members;
            }
        }

        /// <summary>
        /// Gets a Slack user in the current team based on the user's ID.
        /// </summary>
        /// <param name="id">User ID to be found.</param>
        /// <returns>User data if the ID was found, null otherwise.</returns>
        /// <remarks>This will always pull from local cache if available.</remarks>
        public async Task<User> GetUserAsync(IUserId id)
        {
            // try to find the user in local cache first
            var user = _database.FindWithChildren<User>(id.GetUserId());

            // if the user wasn't found, pull it from the server and cache it.
            if (user == null)
            {
                var request = new GetUserRequest(id);
                var response = await _restClient.RequestAsync<GetUserResponse>(request);

                // TODO: Should be checking response.OK to make sure it succeeded, and handle the error if it didn't

                user = response.User;
            }

            return user;
        }

        /// <summary>
        /// Clears the local cache of Users.
        /// </summary>
        public void ClearCache()
        {
            _database.DeleteAll<User>();
        }

        /// <summary>
        /// Adds or updates a list of users to the local cache.
        /// </summary>
        /// <param name="users">Users to be cached.</param>
        /// <remarks>This will throw away the old cached data to ensure that we do not hold on to users
        /// that have been removed from the team.</remarks>
        private void CacheAllUsers(IEnumerable<User> users)
        {
            // clear out the old cache before adding the new list.  This is necessary
            // to avoid locally caching users that have since been removed from the team.
            ClearCache();

            foreach (var user in users)
            {
                CacheUser(user);
            }
        }

        /// <summary>
        /// Adds or updates a user to the local cache.
        /// </summary>
        /// <param name="user">User to be cached.</param>
        private void CacheUser(User user)
        {
            user.Profile.User = user;
            user.Profile.UserId = user.Id;

            _database.InsertOrReplaceWithChildren(user, true);
        }
    }
}
