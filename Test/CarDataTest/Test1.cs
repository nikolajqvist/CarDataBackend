using CARDataLib;
using cardataapi;
using System.Threading.Tasks;
namespace CarDataTest;

[TestClass]
public sealed class Test1
{
    
    [TestMethod]
    public async Task InsertPulseData(){
        CarDataSqliteChunkRepository repo = new CarDataSqliteChunkRepository("Data Source=./cardb;");
        int userId = 1;
        PulseData d = new PulseData();
        d.Pulse = 33;
        d.PulseTime = DateTime.Now;
        PulseData f = new PulseData();
        f.Pulse = 33;
        f.PulseTime = DateTime.Now;
        PulseData g = new PulseData();
        g.Pulse = 33;
        g.PulseTime = DateTime.Now;
        PulseData h = new PulseData();
        h.Pulse = 33;
        h.PulseTime = DateTime.Now;
        PulseData j = new PulseData();
        j.Pulse = 33;
        j.PulseTime = DateTime.Now;
        PulseData k = new PulseData();
        k.Pulse = 33;
        k.PulseTime = DateTime.Now;
        List<PulseData> pulseDatas = new List<PulseData>();
        pulseDatas.Add(d);
        pulseDatas.Add(f);
        pulseDatas.Add(g);
        pulseDatas.Add(h);
        pulseDatas.Add(j);
        pulseDatas.Add(k);
        int actual = repo.GetAll();
        int expected = 6; 
        Assert.AreEqual(actual, expected);
    }
}
