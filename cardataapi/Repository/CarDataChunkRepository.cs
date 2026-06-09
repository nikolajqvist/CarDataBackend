namespace cardataapi;
using System.Data;
using System.Data.SqlTypes;
using CARDataLib;
using Microsoft.Data.SqlClient;

public class CarDataChunkRepository{

    private string connectionString; 
    public CarDataChunkRepository(string connectionString){
        this.connectionString = connectionString;
    }
    public async Task AddScenarios(List<Scenario> scenarios, int userId)
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
                    DestinationTableName = "dbo.Scenario",
                    BatchSize = 1000,
                    //Antal sekunder før timeout
                    BulkCopyTimeout = 60,
                    //Skal testes og evt fjernes hvis det ligefyldigt.
                    //Det sørger for at streaming til db kan forsætte uden problemer.
                    EnableStreaming = true
                };
                //ColumnMappings er mapningen af rækkernes navne i Db
                //De skal passe med navnet i db.
                //De bytter table navne ud hvis de evt ikke skulle passe.
                bulk.ColumnMappings.Add("UserId", "UserId");
                bulk.ColumnMappings.Add("ScenarioName", "ScenarioName");
                bulk.ColumnMappings.Add("CycleToCarDistance", "CycleToCarDistance");
                bulk.ColumnMappings.Add("ScenarioStart", "ScenarioStart");
                bulk.ColumnMappings.Add("ScenarioEnd", "ScenarioEnd");
                //Column her er tilføjelsen af kolonner til table. 
                //Med datatype
                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("ScenarioName", typeof(string));
                table.Columns.Add("CycleToCarDistance", typeof(double));
                table.Columns.Add("ScenarioStart", typeof(DateTime));
                table.Columns.Add("ScenarioEnd", typeof(DateTime));
                foreach (Scenario scenario in scenarios)
                {
                    //Tilføjelse af rækker i db.
                    table.Rows.Add(userId, scenario.ScenarioName, scenario.CycleToCarDistance, scenario.ScenarioStart, scenario.ScenarioEnd);
                }
                //Skrivning af hele bulken til det (table) vi har mappet til.
                await bulk.WriteToServerAsync(table);
            } }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
    }
        public async Task AddRightBrake(List<RightBrake> rightBrakes, int userId){
        try{
            SqlConnection connection = new SqlConnection(connectionString);
            using(connection){
                connection.Open();
                DataTable table = new DataTable();
            SqlBulkCopy bulk = new SqlBulkCopy(connection)
                {
                    DestinationTableName = "dbo.RightBrake",
                    BatchSize = 1000,
                    BulkCopyTimeout = 60,
                    EnableStreaming = true
                };
                bulk.ColumnMappings.Add("UserId", "UserId");
                bulk.ColumnMappings.Add("Brake", "Brake");
                bulk.ColumnMappings.Add("BrakeTime", "BrakeTime");

                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("Brake", typeof(bool));
                table.Columns.Add("BrakeTime", typeof(DateTime));
                foreach (RightBrake rightBrake in rightBrakes)
                {
                    table.Rows.Add(userId, rightBrake.RightBraking, rightBrake.BrakeTime);
                }
                await bulk.WriteToServerAsync(table);
            } 
        } 
            catch(Exception e){
                throw new Exception(e.Message);
        }
    }

    public async Task AddLeftBrake(List<LeftBrake> leftbrakes, int userId){
        try{
            SqlConnection connection = new SqlConnection(connectionString);
            using(connection){
                connection.Open();
                DataTable table = new DataTable();
            SqlBulkCopy bulk = new SqlBulkCopy(connection)
                {
                    DestinationTableName = "dbo.LeftBrake",
                    BatchSize = 1000,
                    BulkCopyTimeout = 60,
                    EnableStreaming = true
                };
                bulk.ColumnMappings.Add("UserId", "UserId");
                bulk.ColumnMappings.Add("Brake", "Brake");
                bulk.ColumnMappings.Add("BrakeTime", "BrakeTime");

                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("Brake", typeof(bool));
                table.Columns.Add("BrakeTime", typeof(DateTime));
                foreach (LeftBrake leftBrake in leftbrakes)
                {
                    table.Rows.Add(userId, leftBrake.LeftBraking, leftBrake.BrakeTime);
                }
                await bulk.WriteToServerAsync(table);
            } 
        } 
            catch(Exception e){
                throw new Exception(e.Message);
        }
    }
    public async Task AddPulseData(List<PulseData> pulseData, int userId)
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
                    DestinationTableName = "dbo.PulseData",
                    BatchSize = 1000,
                    BulkCopyTimeout = 60,
                    EnableStreaming = true
                };
                bulk.ColumnMappings.Add("UserId", "UserId");
                bulk.ColumnMappings.Add("Pulse", "Pulse");

                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("Pulse", typeof(double));
                table.Columns.Add("PulseTime", typeof(DateTime));
                foreach (PulseData pulse in pulseData)
                {
                    table.Rows.Add(userId, pulse.Pulse, pulse.PulseTime);
                }
                await bulk.WriteToServerAsync(table);
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
    }
    public async Task AddBikeData(List<BikeData> bikeData, int userId)
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
                    DestinationTableName = "dbo.BikeData",
                    BatchSize = 1000,
                    BulkCopyTimeout = 60,
                    EnableStreaming = true
                };
                bulk.ColumnMappings.Add("UserId", "UserId");
                bulk.ColumnMappings.Add("HandleRotationY", "HandleRotationY");
                bulk.ColumnMappings.Add("DistanceCurbSide", "DistanceCurbSide");
                bulk.ColumnMappings.Add("Speed", "Speed");
                table.Columns.Add("UserId", typeof(int));
                table.Columns.Add("HandleRotationY", typeof(double));
                table.Columns.Add("DistanceCurbSide", typeof(double));
                table.Columns.Add("Speed", typeof(double));
                foreach (BikeData bikeD in bikeData)
                {
                    table.Rows.Add(userId, bikeD.HandleRotationY, bikeD.DistanceCurbSide, bikeD.Speed);
                }
                await bulk.WriteToServerAsync(table);
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
    }
    public async Task AddHeadTransform(List<HeadTransform> headTransforms, int userId)
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
}
