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
        public UserService(ISlackRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var request = new GetAllUsersRequest();

            var response = await _restClient.RequestAsync<GetAllUsersResponse>(request);

            // TODO: should be checking response.Ok to make sure it succeeded, and handle the error if it didn't

            return response.Members;
        }

        public async Task<User> GetUserAsync(IUserId id)
        {
            var request = new GetUserRequest(id);
            var response = await _restClient.RequestAsync<GetUserResponse>(request);
            
            // TODO: Should be checking response.OK to make sure it succeeded, and handle the error if it didn't

            return response.User;
        }
    }
}
