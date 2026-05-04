namespace cardataapi;
using System.Data;
using CARDataLib;
using Microsoft.Data.Sqlite;

public class CarDataSqliteChunkRepository{

    private string connectionString; 
    public CarDataSqliteChunkRepository(string connectionString){
        this.connectionString = connectionString;
    }
    public async void AddScenarios(List<Scenario> scenarios)
    {
        try
        {
            //Skal laves op!.
            SqliteConnection connection = new SqliteConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string sql = "insert into scenario values (null, @sessionId, @scenarioname, @cycletocardis, @scenariostart, @scenarioend)";
                SqliteCommand command = new SqliteCommand(sql, connection);
                // command.CommandText = "insert into scenario values (null, @user, @scenarioname, @cycletocardis, @scenariostart, @scenarioend)";
                foreach(Scenario scenario in scenarios){
                    HelperMethods.BindSqliteValueInt(command, "@sessionId", scenario.SessionId);
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
            SqliteConnection connection = new SqliteConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string sql = "insert into pulseData values (null, @pulse)";
                SqliteCommand command = new SqliteCommand(sql, connection);
                SqliteParameter pulseParam = HelperMethods.CreateParam(command, "@pulse");
                foreach(PulseData pulse in pulseData){
                    pulseParam.Value = pulse.Pulse;
                    ExecuteQuery(command);
                }
            }
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
                    SqliteCommand command = connection.CreateCommand(); 
                    command.CommandText = sql;
                    // SqliteCommand command = new SqliteCommand(sql, connection);
                    // command.CommandText = "insert into scenario values (null, @user, @scenarioname, @cycletocardis, @scenariostart, @scenarioend)";
                    SqliteParameter userIdParam = HelperMethods.CreateParam(command, "@userId");
                    SqliteParameter handleyParam = HelperMethods.CreateParam(command, "@handley");
                    SqliteParameter cubsideParam = HelperMethods.CreateParam(command, "@discurb");
                    SqliteParameter speedParam = HelperMethods.CreateParam(command, "@speed");
                    // HelperMethods.BindSqliteValueInt(command, "@userid", userId);
                    // HelperMethods.BindSqliteValueDouble(command, "@handley", bikdD.HandleRotationY);
                    // HelperMethods.BindSqliteValueDouble(command, "@discurb", bikdD.DistanceCurbSide);
                    // HelperMethods.BindSqliteValueDouble(command, "@speed", bikdD.Speed);
                    foreach(BikeData bikdD in bikeData){
                        userIdParam.Value = userId;
                        handleyParam.Value = bikdD.HandleRotationY;
                        cubsideParam.Value = bikdD.DistanceCurbSide;
                        speedParam.Value = bikdD.Speed;
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
            }
            catch (SqliteException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async void AddTimeCheck(List<TimeCheck> timeChecks)
        {
            try
            {
            }
            catch (SqliteException e)
            {
                throw new Exception(e.Message);
            }
        }
        private void ExecuteQuery(SqliteCommand command){ 
            command.ExecuteNonQuery(); 
        } 
    }
