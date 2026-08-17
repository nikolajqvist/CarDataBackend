using CARDataLib;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cardataapi.Controllers
{
    [Route("api/cardata/backup")]
    [ApiController]
    public class CarDataMssqlController : ControllerBase
    {
        private CarDataMssqlRepository carDataRepository;
        // private CarDataChunkRepository chunkRepository;
        private MssqlByteHandlerService mssqlByteHandlerService;
        public CarDataMssqlController(CarDataMssqlRepository carDataRepository/*, CarDataChunkRepository chunkRepository*/, MssqlByteHandlerService mssqlByteHandlerService)
        {
            this.carDataRepository = carDataRepository;
            // this.chunkRepository = chunkRepository;
            this.mssqlByteHandlerService = mssqlByteHandlerService;
        }
        // GET: api/<PostController>
        [HttpGet]
        [Route("id/{userId}")]
        public IActionResult GetUser(int userId)
        {
            User user = carDataRepository.GetUser(userId);
            if(user != null)
                return Ok(user);
            else
                return BadRequest();
        }
        // [HttpGet]
        // [Route("id/getfull/{userId}")]
        // public IActionResult GetFullTestPerson(int userId){
        //     User fUser = carDataRepository.(userId);
        //     if(fUser == null)
        //         return BadRequest();
        //     return Ok(fUser);
        // }
        [HttpPost]
        [Route("logbikedata")]
        public async Task<IActionResult> BackupBD(){
            using var ms = new MemoryStream();
            await Request.Body.CopyToAsync(ms);

            byte[] incomingBytes = ms.ToArray();

            if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
            await mssqlByteHandlerService.ByteBikeData(incomingBytes);
            return Ok("Bike data indsat. /Backup");
        }
        [HttpPost]
        [Route("logscenario")]
        public async Task<IActionResult> BackupScenario(){
            using var ms = new MemoryStream();
            await Request.Body.CopyToAsync(ms);

            byte[] incomingBytes = ms.ToArray();

            if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
            await mssqlByteHandlerService.ByteScenarios(incomingBytes);
            return Ok("Scenario data indsat. /Backup");
        }
        [HttpPost]
        [Route("loghtf")]
        public async Task<IActionResult> BackupHtf(){
            using var ms = new MemoryStream();
            await Request.Body.CopyToAsync(ms);

            byte[] incomingBytes = ms.ToArray();

            if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
            await mssqlByteHandlerService.ByteHeadTransform(incomingBytes);
            return Ok("Headtransform data indsat. /Backup");
        }
        [HttpPost]
        [Route("logarduino")]
        public async Task<IActionResult> BackupArduino(){
            using var ms = new MemoryStream();
            await Request.Body.CopyToAsync(ms);

            byte[] incomingBytes = ms.ToArray();

            if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
            await mssqlByteHandlerService.ByteArduino(incomingBytes);
            return Ok("Arduino data indsat. /Backup");
        }
        [HttpPost]
        [Route("logpulse")]
        public async Task<IActionResult> BackupPulseData(){
            using var ms = new MemoryStream();
            await Request.Body.CopyToAsync(ms);

            byte[] incomingBytes = ms.ToArray();

            if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();

            await mssqlByteHandlerService.BytePulseData(incomingBytes);

            return Ok("Pulse data indsat. /Backup");
        }

    }
}
