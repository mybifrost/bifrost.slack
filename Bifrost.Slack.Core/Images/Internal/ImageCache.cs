using Cirrious.MvvmCross.Plugins.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.Core.Images.Internal
{
    internal class ImageCache : IImageCache
    {
        private IMvxFileStore _fileStore;
        public ImageCache(IMvxFileStore fileStore)
        {
            _fileStore = fileStore;
        }

        /// <summary>
        /// Gets the filepath to a locally cached copy of an online image.
        /// </summary>
        /// <param name="imageUrl">Http/https URL of the required image resource.</param>
        /// <returns>Local filepath for the cached image, or null if the online resource was not found.</returns>
        public async Task<string> GetCachedIamgePathAsync(string imageUrl)
        {
            var localPath = imageUrl.Replace("https://", "");
            localPath = localPath.Replace("http://", "");
            localPath = localPath.Replace('/', '_');

            try
            {
                if (_fileStore.Exists(localPath))
                    return _fileStore.NativePath(localPath);
            }
            catch(Exception)
            {
                // this is OK, an exception may be thrown here if the file wasn't found.
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(imageUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var bytes = await response.Content.ReadAsByteArrayAsync();
                        _fileStore.WriteFile(localPath, bytes);
                    }
                }
            }
            catch(Exception ex)
            {
                // TODO: handle http exceptions
            }

            return _fileStore.NativePath(localPath);
        }
    }
}
