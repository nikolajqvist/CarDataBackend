using CARDataLib;
using Microsoft.Data.Sqlite;
namespace cardataapi;

public class CarDataSqliteRepository{
    private string connectionString;

    public CarDataSqliteRepository(string connectionString){
        this.connectionString = connectionString;
    }
    public void FirstInstanceOfUser(User user){
        SqliteConnection connection = new SqliteConnection(connectionString);
        using(connection){
            connection.Open();
            string sql = "insert into Users values(@id, @age, @gender)";

            SqliteCommand comm = new SqliteCommand(sql, connection);
            HelperMethods.BindSqliteValueInt(comm, "@id", user.TestPersonNumber);
            HelperMethods.BindSqliteValueString(comm, "@gender", user.Gender);
            HelperMethods.BindSqliteValueInt(comm, "@age", user.Age);
            comm.ExecuteNonQuery();
        }
    }
    public User GetUser(int id){
        SqliteConnection connection = HelperMethods.NewSqliteConnection(connectionString);
        using(connection){
            connection.Open();
            string sql = "Select * from Users where (TestPersonNumber = @id)";
            SqliteCommand comm = new SqliteCommand(sql, connection);
            HelperMethods.BindSqliteValueInt(comm, "@id", id);
            SqliteDataReader reader = comm.ExecuteReader();
            if(reader.Read()){
                User u = new User(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                return u;
            }
            return null;
        }
    }
}
