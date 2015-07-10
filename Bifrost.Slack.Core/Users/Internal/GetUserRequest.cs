using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users.Internal
{
    internal class GetUserRequest : RestRequest
    {
        public GetUserRequest(IUserId id)
            : base("users.info")
        {
            AddQueryString("user", id.GetUserId());
        }
    }
}
