using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
namespace cardataapi;
public static class HelperMethods
{
    // public static void BindValueSqlLite(SqliteCommand coomand, string sqlparameter, string parameter, string? condition = null){
    //     if(condition == "i"){
    //         int intparameter = int.Parse(parameter);
    //         coomand.Parameters.AddWithValue(sqlparameter, intparameter);
    //     }
    //     else if(condition == "d"){
    //         double doubparameter = double.Parse(parameter);
    //         coomand.Parameters.AddWithValue(sqlparameter, doubparameter);
    //     }
    //     else if(condition == null){
    //         coomand.Parameters.AddWithValue(sqlparameter, parameter);
    //     }
    // }
    public static void BindSqliteValueInt(SqliteCommand command, string sqlparameter, int parameter){
        command.Parameters.AddWithValue(sqlparameter, parameter);
    }
    public static void BindSqliteValueDouble(SqliteCommand command, string sqlparameter, double parameter){
        command.Parameters.AddWithValue(sqlparameter, parameter);
    }
    public static void BindSqliteValueDateTime(SqliteCommand command, string sqlparameter, DateTime parameter){
        command.Parameters.AddWithValue(sqlparameter, parameter);
    }
    public static void BindSqliteValueString(SqliteCommand command, string sqlparameter, string parameter){
        command.Parameters.AddWithValue(sqlparameter, parameter);
    }
    public static void BindValueInt(SqlCommand command, string sqlparameter, int parameter) {
        command.Parameters.AddWithValue(sqlparameter, parameter);
    } 
    public static void BindValueString(SqlCommand command, string sqlparameter, string parameter)
    { command.Parameters.AddWithValue(sqlparameter, parameter);
    } 
    public static void BindValueDateTime(SqlCommand command, string sqlparameter, DateTime parameter)
    { command.Parameters.AddWithValue(sqlparameter, parameter);
    }
    public static void BindValueDouble(SqlCommand command, string sqlparameter, double parameter)
    { command.Parameters.AddWithValue(sqlparameter, parameter);
    }
    public static SqlConnection NewConnection(string connectionString) {
        return new SqlConnection(connectionString);
    }
    public static SqlCommand NewCommand(string sql, SqlConnection connection) {
        return new SqlCommand(sql, connection);
    }
    public static SqliteConnection NewSqliteConnection(string connectionString){
        return new SqliteConnection(connectionString);
    }
}

