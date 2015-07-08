using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Users.Internal
{
    internal class GetAllUsersRequest : RestRequest
    {
        public GetAllUsersRequest() :
            base("users.list") { }
    }
}
