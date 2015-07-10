using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Images
{
    public interface IImageCache
    {
        /// <summary>
        /// Gets the filepath to a locally cached copy of an online image.
        /// </summary>
        /// <param name="imageUrl">Http/https URL of the required image resource.</param>
        /// <returns>Local filepath for the cached image, or null if the online resource was not found.</returns>
        Task<string> GetCachedIamgePathAsync(string imageUrl);
    }
}
