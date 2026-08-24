namespace cardataapi;
using Microsoft.Data.SqlClient;
using CARDataLib;
public class CarDataMssqlRepository{
    private string connectionString;
    public CarDataMssqlRepository(string connectionString)
    {
        this.connectionString = connectionString; 
    }
    public User GetUser(int id){
        try{
            // User u = null;
            using (SqlConnection connection = new SqlConnection(connectionString)){
                connection.Open();

                string sql = "SELECT TestPersonNumber, Gender, Age FROM Users WHERE (TestPersonNumber = @testpersonnumber)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@testpersonnumber", id);

                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read()){
                    // int age = reader.GetInt32(2);
                    User u = new User(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                    // u.TestPersonNumber = reader.GetInt32(0);
                    // u.Age = reader.GetString(1);
                    // u.Gender = reader.GetString(2);
                    return u;
                }
                else{
                    return null;
                }
            }
        }
        catch(Exception e){
            throw new Exception(e.Message);
        }
    }
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

