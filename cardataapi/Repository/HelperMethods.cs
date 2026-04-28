using Microsoft.Data.SqlClient;
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
    public static SqlConnection NewConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }
    public static SqlCommand NewCommand(string sql, SqlConnection connection)
    {
        return new SqlCommand(sql, connection);
    }
}

