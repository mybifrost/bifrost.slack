using Bifrost.Slack.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users.Internal
{
    internal class GetUserResponse : SlackResponse
    {
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
