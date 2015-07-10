namespace Bifrost.Slack.Core
{
    public interface ISQLite
    {
        SQLite.Net.SQLiteConnection GetConnection();
    }
}
