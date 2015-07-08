using Bifrost.Slack.Core.Users;
using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core
{
    public class Client
    {
        public static void RegisterIoC()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISlackRestClient, Internal.SlackRestClient>();
            Mvx.LazyConstructAndRegisterSingleton<ISlackClient, Internal.SlackClient>();
            Mvx.LazyConstructAndRegisterSingleton<IUserService, Users.Internal.UserService>();
        }
    }
}
