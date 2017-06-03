using SQLite;

namespace App3
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

