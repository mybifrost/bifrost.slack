using Bifrost.Slack.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core
{
    public interface ISlackClient
    {
        /// <summary>
        /// Token required for all API calls.
        /// </summary>
        string AuthenticationToken { get; set; }

        IUserService Users { get; }
    }
}
