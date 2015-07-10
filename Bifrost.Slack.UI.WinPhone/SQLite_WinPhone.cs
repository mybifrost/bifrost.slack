using Bifrost.Slack.Core;
using System.IO;
using Windows.Storage;

namespace Bifrost.Slack.UI.WinPhone
{
    public class SQLite_WinPhone : ISQLite
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "CoinJar.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            // Create the connection
            var conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            // Return the database connection
            return conn;
        }
    }
}
