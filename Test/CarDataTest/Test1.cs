using CARDataLib;
using cardataapi;
namespace CarDataTest;

[TestClass]
public sealed class Test1
{
    private CarDataMssqlRepository? carDataRepository;     
    [TestInitialize]
    public void TestInitialize(){
        carDataRepository = new CarDataMssqlRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
