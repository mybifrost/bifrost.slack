using Bifrost.Slack.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Internal
{
    internal class SlackClient : ISlackClient
    {
        public SlackClient(IUserService userService)
        {
            Users = userService;
        }

        /// <summary>
        /// Token required for all API calls.
        /// </summary>
        public string AuthenticationToken { get; set; }

        public IUserService Users { get; private set; }
    }
}
