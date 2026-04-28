using CARDataLib;
using cardataapi;
namespace CarDataTest;

[TestClass]
public sealed class Test1
{
    private CarDataRepository? carDataRepository;     
    // private User? user;
    // private Session? session;
    // private Random? random;
    // private Session? newsession;
    [TestInitialize]
    public void TestInitialize(){
        carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
        // random = new Random();
        // user = new User(random.Next(10000,99999), random.Next(10,99), "Mand");
        // newsession = carDataRepository.AddSession(user.TestPersonNumber);
    }
    // [TestMethod]
    // public void TestGetUser()
    // {
    //     // CarDataRepository carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    //     User newusers = carDataRepository.GetOneUser(16128);
    //     int expectedId = 16128;
    //     int actualId = newusers.TestPersonNumber;
    //     Assert.AreEqual(expectedId, actualId);
    // }
    // [TestMethod]
    // public void TestNewUser(){
    //     CarDataRepository carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    //     Random random = new Random();
    //     User user = new User(random.Next(10000,99999), random.Next(10,99), "Mand");
    //     User newU = carDataRepository.AddFirstInstanceOfUser(user);
    //     Assert.AreEqual(user.TestPersonNumber, newU.TestPersonNumber); 
    // }
    // [TestMethod]
    // public void TestMethod3(){
    //     CarDataRepository carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    //
    //     Session session = carDataRepository.AddSession(16128);
    //     int expectedId = 21;
    //     int actualId = session.Id;
    //     Assert.AreEqual(expectedId, actualId);
    // }
    // [TestMethod]
    // [DataRow(87)]
    // [DataRow(88)]
    // [DataRow(88)]
    // [DataRow(89)]
    // [DataRow(99)]
    // public void TestInsertPulseData(int pulse){
    //     CarDataRepository carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    //     User userForPulse = carDataRepository.GetOneUser(16128);
    //     PulseData p = new PulseData(){
    //         Pulse = pulse
    //     };
    //     PulseData newData = carDataRepository.AddPulseData(p, userForPulse.TestPersonNumber); 
    //     Assert.IsNotNull(newData);
   // }
    // [TestMethod]
    // [DataRow("First", 0.0495)]
    // public void TestInsertScenario(string scename, double curbside){
    //      CarDataRepository carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    //      Session oneSession = carDataRepository.GetOneSession(21);
    //      Scenario scenario = new Scenario(){
    //          ScenarioName = scename,
    //          CycleToCarDistance = curbside,
    //          ScenarioStart = new DateTime(2026, 04, 23, 13, 00, 00),
    //          ScenarioEnd = new DateTime(2026, 04, 23, 14, 00, 00),
    //      };
    //      Scenario newScenario = carDataRepository.AddScenario(scenario, oneSession.Id);
    //      Assert.IsNotNull(newScenario);
    // }
    // [TestMethod]
    //  public void TestInsertTimeCheck(){
    //     CarDataRepository carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    //     int timeCheck = 1;
    //     TimeCheck timeC = new TimeCheck(){
    //         Time = timeCheck
    //     };
    //     TimeCheck tC = carDataRepository.AddTimeCheck(timeC);
    //     Assert.IsNotNull(tC);
    // }
    // [TestMethod]
    // public void TestInsertBikeData(){
    //       CarDataRepository carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    //       BikeData bikeData = new BikeData(){
    //           HandleRotationY = 0.48458,
    //           DistanceCurbSide = 2.583853,
    //           Speed = 20.43
    //       };
    //       BikeData toCheck = carDataRepository.AddBikeData(bikeData ,16128);
    //       Assert.IsNotNull(toCheck);
    // }
    // [TestMethod]
    // public void TestInsertHeadTransform(){
    //       CarDataRepository carDataRepository = new CarDataRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    //       HeadTransform hTF = new HeadTransform(){
    //             RotW = 1.54555,
    //             RotZ = 1.54667,
    //             RotX = 1.64955,
    //             RotY = 1.45695,
    //             PosX = 0.54534,
    //             PosY = 0.54532,
    //             PosZ = 0.54531,
    //       };
    //       HeadTransform toCheck = carDataRepository.AddHeadTransform(hTF, 16128);
    //       Assert.IsNotNull(toCheck);
    // }
}
