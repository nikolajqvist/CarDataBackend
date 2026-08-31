namespace cardataapi;
using Microsoft.Data.SqlClient;
using CARDataLib;
public class CarDataMssqlRepository{
    private string connectionString;
    public CarDataMssqlRepository(string connectionString)
    {
        this.connectionString = connectionString; 
    }
    public FullUser GetUser(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"
                    SELECT *
                    FROM dbo.vw_TestPersonSummary
                    WHERE TestPersonNumber = @testpersonnumber";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@testpersonnumber", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    FullUser user = new FullUser(
                            reader.GetInt32(0),                    // TestPersonNumber
                            reader.IsDBNull(1) ? null : reader.GetInt32(1),       // Age
                            reader.IsDBNull(2) ? null : reader.GetString(2),     // Gender

                            reader.GetInt32(3),                    // PulseMeasurements
                            reader.IsDBNull(4) ? null : reader.GetDouble(4),    // AveragePulse
                            reader.IsDBNull(5) ? null : reader.GetInt32(5),     // MinPulse
                            reader.IsDBNull(6) ? null : reader.GetInt32(6),     // MaxPulse

                            reader.GetInt32(7),                    // BikeMeasurements
                            reader.IsDBNull(8) ? null : reader.GetDouble(8),    // AverageSpeed
                            reader.IsDBNull(9) ? null : reader.GetDouble(9),    // MaxSpeed
                            reader.IsDBNull(10) ? null : reader.GetDouble(10),  // AverageDistanceCurbSide
                            reader.IsDBNull(11) ? null : reader.GetDouble(11),  // MinDistanceCurbSide
                            reader.IsDBNull(12) ? null : reader.GetDouble(12),  // AverageHandleRotationY

                            reader.GetInt32(13),                   // HeadTransformMeasurements

                            reader.GetInt32(14),                   // LeftBrakeMeasurements
                            reader.GetInt32(15),                   // LeftBrakeEvents

                            reader.GetInt32(16),                   // RightBrakeMeasurements
                            reader.GetInt32(17),                   // RightBrakeEvents

                            reader.GetInt32(18)                    // ScenarioCount
                                );

                    return user;
                }

                return null;
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }  
    // public User GetUser(int id){
    //     try{
    //         // User u = null;
    //         using (SqlConnection connection = new SqlConnection(connectionString)){
    //             connection.Open();
    //
    //             string sql = "select * from dbo.vw_TestPersonSummary where testpersonnumber = @testpersonnumber)";
    //
    //             SqlCommand command = new SqlCommand(sql, connection);
    //             command.Parameters.AddWithValue("@testpersonnumber", id);
    //
    //             SqlDataReader reader = command.ExecuteReader();
    //             if(reader.Read()){
    //                 // int age = reader.GetInt32(2);
    //                 User u = new User(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
    //                 // u.TestPersonNumber = reader.GetInt32(0);
    //                 // u.Age = reader.GetString(1);
    //                 // u.Gender = reader.GetString(2);
    //                 return u;
    //             }
    //             else{
    //                 return null;
    //             }
    //         }
    //     }
    //     catch(Exception e){
    //         throw new Exception(e.Message);
    //     }
    // }
    public User AddFirstInstanceOfUser(User user)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Users (TestPersonNumber, Age, Gender) VALUES (@testpersonnumber, @age, @gender)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    HelperMethods.BindValueInt(command, "@testpersonnumber", user.TestPersonNumber);
                    HelperMethods.BindValueInt(command, "@age", user.Age);
                    HelperMethods.BindValueString(command, "@gender", user.Gender);
                    command.ExecuteNonQuery();
                }
            }
            return user;
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
    }
}

