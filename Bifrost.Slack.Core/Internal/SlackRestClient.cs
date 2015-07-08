using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Internal
{
    internal class SlackRestClient : RestClient, ISlackRestClient
    {
        private static readonly string API_TOKEN = "xoxp-4698769766-4698769768-4898023905-7a1afa";

        public SlackRestClient()
        {
            BaseUrl = "https://slack.com/api";
        }

        public async Task<T> RequestAsync<T>(RestRequest request) where T : class
        {
            request.AddQueryString("token", API_TOKEN);

            return await ExecuteAsync<T>(request);
        }
    }
}
