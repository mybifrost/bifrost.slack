using Bifrost.Slack.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users.Internal
{
    internal class GetAllUsersResponse : SlackResponse
    {
        [DataMember(Name = "members")]
        public List<User> Members { get; set; }
    }
}
