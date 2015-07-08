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
        IUserService Users { get; set; }
    }
}
