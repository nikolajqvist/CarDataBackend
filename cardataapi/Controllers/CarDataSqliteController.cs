using CARDataLib;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Reflection.Metadata;
namespace cardataapi.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class CarDataSqliteController : ControllerBase
    {
       public CarDataSqliteChunkRepository? carDataSqliteChunkRepository;
       public CarDataSqliteController(CarDataSqliteChunkRepository carDataSqliteChunkRepository){
           this.carDataSqliteChunkRepository = carDataSqliteChunkRepository;
       }
        [HttpPost]
        [Route("logsqlitepulsedata")]
        public async Task<IActionResult> PostPulseData([FromForm] IncomingFile incomingFile, int userId){
            if(incomingFile.newTestFile == null || incomingFile.newTestFile.Length == 0){
                return BadRequest("File fail");
            }
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "Pulsedata");
            var filepath = Path.Combine("Pulsedata", incomingFile.newTestFile.FileName);

            Directory.CreateDirectory(folderpath);
            FileStream stream = new FileStream(filepath, FileMode.Create);
            using(stream){
                await incomingFile.newTestFile.CopyToAsync(stream);
            }
            string fileContent = await System.IO.File.ReadAllTextAsync(filepath);
            if(fileContent.Length == 0 && fileContent == null)
                return NoContent();
            string[] stringSplit = fileContent.Split("\n");

            List<PulseData> pulseDatas = new List<PulseData>();

            foreach (string line in stringSplit){
                    int pulse = int.Parse(line);
                    PulseData pulsed = new PulseData();
                    pulsed.Pulse = pulse;
                    carDataSqliteChunkRepository.AddPulseData(pulseDatas, userId);
            }
            return Ok("Did good!");
        }
        [HttpPost]
        [Route("logsqlitebikedata")]
        public async Task<IActionResult> PostBikeData([FromForm] IncomingFile incomingFile, int userId){
            if(incomingFile.newTestFile == null || incomingFile.newTestFile.Length == 0){
                return BadRequest("File fail");
            }
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "TestUsers");
            var filepath = Path.Combine("TestUsers", incomingFile.newTestFile.FileName);

            Directory.CreateDirectory(folderpath);
            FileStream stream = new FileStream(filepath, FileMode.Create);
            using(stream){
                await incomingFile.newTestFile.CopyToAsync(stream);
            }
            string fileContent = await System.IO.File.ReadAllTextAsync(filepath);
            if(fileContent.Length == 0 && fileContent == null)
                return NoContent();
            string[] stringSplit = fileContent.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);

            var chunks = stringSplit.Chunk(3);

            List<BikeData> bikeDatas = new List<BikeData>();

            foreach (string[] chunk in chunks){
                if(chunk.Length < 3) {
                    return BadRequest();
                };
                    var yRot = double.Parse(chunk[0]);
                    double curbSide = double.Parse(chunk[1]);
                    double spee = double.Parse(chunk[2]);
                    BikeData p = new BikeData();
                    p.HandleRotationY = yRot;
                    p.DistanceCurbSide = curbSide;
                    p.Speed = spee;
                    bikeDatas.Add(p);
                    carDataSqliteRepository.AddBikeData(bikeDatas, userId);
            }
            return Ok("Did good!");
        }
    }    
}
