using CARDataLib;
using Microsoft.Data.Sqlite;
namespace cardataapi;

public class CarDataSqliteRepository{
    private string connectionString;

    public CarDataSqliteRepository(string connectionString){
        this.connectionString = connectionString;
    }
    public void AddBikeData(BikeData bikeData, int userId){
        SqliteConnection connection = new SqliteConnection(connectionString);
        using(connection){

            connection.Open();
            string sql = $"insert into bikedata values(null, {userId}, {bikeData.HandleRotationY}, {bikeData.DistanceCurbSide}, {bikeData.Speed}";
            SqliteCommand comd = new SqliteCommand(sql, connection);
            comd.ExecuteNonQuery();
        }
    }
}
