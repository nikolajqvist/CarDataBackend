using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
namespace cardataapi;
public static class HelperMethods
{
    public static void BindValueInt(SqlCommand command, string sqlparameter, int parameter)
    {
        command.Parameters.AddWithValue(sqlparameter, parameter);
    } 
    public static void BindValueString(SqlCommand command, string sqlparameter, string parameter)
    {
        command.Parameters.AddWithValue(sqlparameter, parameter);
    } 
    public static void BindValueDateTime(SqlCommand command, string sqlparameter, DateTime parameter)
    {
        command.Parameters.AddWithValue(sqlparameter, parameter);
    }
    public static void BindValueDouble(SqlCommand command, string sqlparameter, double parameter)
    {
        command.Parameters.AddWithValue(sqlparameter, parameter);
    }
    public static SqlConnection NewMssqlConnection(string connectionString) {
        return new SqlConnection(connectionString);
    }
    public static SqlCommand NewMssqlCommand(string sql, SqlConnection connection) {
        return new SqlCommand(sql, connection);
    }
    public static SqliteConnection NewSqliteConnection(string connectionString){
        return new SqliteConnection(connectionString);
    }
}

