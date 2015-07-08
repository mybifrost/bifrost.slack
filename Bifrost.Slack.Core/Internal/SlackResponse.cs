using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Internal
{
    /// <summary>
    /// Base class for Slack API calls.
    /// </summary>
    [DataContract]
    internal abstract class SlackResponse
    {
        /// <summary>
        /// True if the request succeeded, false otherwise. 
        /// </summary>
        /// <remarks>
        /// Callers should always check this to ensure that the request succeeded.
        /// If this failed, check the Error string for details.
        /// </remarks>
        [DataMember(Name = "ok")]
        public bool Success { get; set; }

        /// <summary>
        /// (Optional) Error code from the Slack API.
        /// </summary>
        /// <remarks>
        /// Make sure to check for null here, this is only set if the request failed.
        /// </remarks>
        [DataMember(Name = "error")]
        public string Error { get; set; }
    }
}
