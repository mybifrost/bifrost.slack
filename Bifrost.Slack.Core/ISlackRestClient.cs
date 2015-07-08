using Bifrost.Slack.Core.Internal;
using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core
{
    public interface ISlackRestClient
    {
        Task<T> RequestAsync<T>(RestRequest request) where T : class;
    }
}
