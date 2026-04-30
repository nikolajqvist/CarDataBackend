namespace cardataapi;
using System.Data;
using CARDataLib;
using Microsoft.Data.Sqlite;

public class CarDataSqliteChunkRepository{

    private string connectionString; 
    public CarDataSqliteChunkRepository(string connectionString){
        this.connectionString = connectionString;
    }
    public void ExecuteQuery(SqliteCommand command){
                    command.ExecuteNonQuery();
    }
    public async void AddScenarios(List<Scenario> scenarios, int userId)
    {
        try
        {
            SqliteConnection connection = new SqliteConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string sql = "insert into scenario values (null, @userid, @scenarioname, @cycletocardis, @scenariostart, @scenarioend)";
                SqliteCommand command = new SqliteCommand(sql, connection);
                // command.CommandText = "insert into scenario values (null, @user, @scenarioname, @cycletocardis, @scenariostart, @scenarioend)";
                foreach(Scenario scenario in scenarios){
                    HelperMethods.BindSqliteValueInt(command, "@userid", userId);
                    HelperMethods.BindSqliteValueString(command, "@scenarioname", scenario.ScenarioName);
                    HelperMethods.BindSqliteValueDouble(command, "@cycletocardis", scenario.CycleToCarDistance);
                    HelperMethods.BindSqliteValueDateTime(command, "@scenariostart", scenario.ScenarioStart);
                    HelperMethods.BindSqliteValueDateTime(command, "@scenarioend", scenario.ScenarioEnd);
                    ExecuteQuery(command);
                }
                
            }
        }
        catch (SqliteException e)
        {
            throw new Exception(e.Message);
        }
    }
    public async void AddPulseData(List<PulseData> pulseData, int userId)
    {
        try
        {
            // SqliteConnection connection = new SqliteConnection(connectionString);
            // using (connection)
            // {
            //     connection.Open();
            //     string sql = "insert into pulseData values (null, @userid, @scenarioname, @cycletocardis, @scenariostart, @scenarioend)";
            //     SqliteCommand command = new SqliteCommand(sql, connection);
            //     // command.CommandText = "insert into scenario values (null, @user, @scenarioname, @cycletocardis, @scenariostart, @scenarioend)";
            //     foreach(PulseData scenario in pulseData){
            //         HelperMethods.BindSqliteValueInt(command, "@userid", userId);
            //         HelperMethods.BindSqliteValueString(command, "@scenarioname", scenario.ScenarioName);
            //         HelperMethods.BindSqliteValueDouble(command, "@cycletocardis", scenario.CycleToCarDistance);
            //         HelperMethods.BindSqliteValueDateTime(command, "@scenariostart", scenario.ScenarioStart);
            //         HelperMethods.BindSqliteValueDateTime(command, "@scenarioend", scenario.ScenarioEnd);
            //         ExecuteQuery(command);
            // }
        }
        catch (SqliteException e)
        {
            throw new Exception(e.Message);
        }
    }
    public async void AddBikeData(List<BikeData> bikeData, int userId)
    {
        try
        {
            SqliteConnection connection = new SqliteConnection(connectionString);
            using(connection){
                connection.Open();
                string sql = "insert into bikeData values (null, @userid, @handley, @discurb, @speed)";
                SqliteCommand command = new SqliteCommand(sql, connection);
                // command.CommandText = "insert into scenario values (null, @user, @scenarioname, @cycletocardis, @scenariostart, @scenarioend)";
                foreach(BikeData bikdD in bikeData){
                    HelperMethods.BindSqliteValueInt(command, "@userid", userId);
                    HelperMethods.BindSqliteValueDouble(command, "@handley", bikdD.HandleRotationY);
                    HelperMethods.BindSqliteValueDouble(command, "@discurb", bikdD.DistanceCurbSide);
                    HelperMethods.BindSqliteValueDouble(command, "@speed", bikdD.Speed);
                    ExecuteQuery(command);
                }
            }
        }

        catch (SqliteException e)
        {
            throw new Exception(e.Message);
        }
    }
    public async void AddHeadTransform(List<HeadTransform> headTransforms, int userId)
    {
        try
        {
            SqlConnection connection = HelperMethods.NewConnection(connectionString);
            using (connection)
            {
                connection.Open();
                DataTable table = new DataTable();
                SqlBulkCopy bulk = new SqlBulkCopy(connection)
                {
                    DestinationTableName = "dbo.HeadTransform",
                    BatchSize = 1000,
                    BulkCopyTimeout = 60,
                    EnableStreaming = true
                };
                bulk.ColumnMappings.Add("UserId", "UserId");
                bulk.ColumnMappings.Add("RotW", "RotW");
                bulk.ColumnMappings.Add("RotZ", "RotZ");
                bulk.ColumnMappings.Add("RotX", "RotX");
                bulk.ColumnMappings.Add("RotY", "RotY");
                bulk.ColumnMappings.Add("PosX", "PosX");
                bulk.ColumnMappings.Add("PosY", "PosY");
                bulk.ColumnMappings.Add("PosZ", "PosZ");
                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("RotW", typeof(double));
                table.Columns.Add("RotZ", typeof(double));
                table.Columns.Add("RotX", typeof(double));
                table.Columns.Add("RotY", typeof(double));
                table.Columns.Add("PosX", typeof(double));
                table.Columns.Add("PosY", typeof(double));
                table.Columns.Add("PosZ", typeof(double));
                foreach (HeadTransform hTF in headTransforms)
                {
                    table.Rows.Add(userId, hTF.RotW, hTF.RotZ, hTF.RotX, hTF.RotY, hTF.PosX, hTF.PosY, hTF.PosZ);
                }
                await bulk.WriteToServerAsync(table);
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
    }
    public async void AddTimeCheck(List<TimeCheck> timeChecks)
    {
        try
        {
            SqlConnection connection = HelperMethods.NewConnection(connectionString);
            using (connection)
            {
                connection.Open();
                DataTable table = new DataTable();
                SqlBulkCopy bulk = new SqlBulkCopy(connection)
                {
                    DestinationTableName = "dbo.TimeCheck",
                    BatchSize = 1000,
                    BulkCopyTimeout = 60,
                    EnableStreaming = true
                };
                bulk.ColumnMappings.Add("Time", "Time");
                table.Columns.Add("Time", typeof(int));
                foreach (TimeCheck time in timeChecks)
                {
                    table.Rows.Add(time.Time);
                }
                await bulk.WriteToServerAsync(table);
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
    }
}
