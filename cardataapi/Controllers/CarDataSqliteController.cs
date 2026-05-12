using Microsoft.AspNetCore.Mvc;
using CARDataLib;
namespace cardataapi.Controllers{

    [Route("api/cardata")]
    [ApiController]
    public class CarDataSqliteController : ControllerBase
    {
       private FileHandlerService fileHandlerService;
       private CarDataSqliteRepository carDataSqliteRepository;
       private StringHandlerService stringHandlerService;
       public CarDataSqliteController(StringHandlerService stringHandlerService, FileHandlerService fileHandlerService, CarDataSqliteRepository carDataSqliteRepository){
           this.fileHandlerService = fileHandlerService;
           this.stringHandlerService = stringHandlerService;
           this.carDataSqliteRepository = carDataSqliteRepository;
       }
       [HttpGet]
       [Route("id/{userId}")]
       public IActionResult GetUser(int userId){
           User u = carDataSqliteRepository.GetUser(userId);
           if(userId == 0){
               return BadRequest();
           }
           return Ok(u);
       }
       [HttpPost]
       [Route("logbikedata")]
       public async Task<IActionResult> PostBD([FromBody] byte[] incoming){
           // if(file.Length == 0 || file == null) return BadRequest();
           // IncomingFile incomingFile = new();
           // incomingFile.newTestFile = file;
           // await fileHandlerService.HandleBikeData(incomingFile);
           // if(string.IsNullOrEmpty(incomingText)) return BadRequest();
           // await stringHandlerService.AddBikeData(incomingText);
           if(incoming.Length == 0 || incoming == null) return BadRequest();
           using var ms = new MemoryStream();
           await Request.Body.CopyToAsync(ms);

           byte[] incomingBytes = ms.ToArray();

           if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
           await stringHandlerService.AddByteArray(incomingBytes);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logscenario")]
       public async Task<IActionResult> PostScenarios([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           await fileHandlerService.HandleScenarios(incomingFile);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("loghtf")]
       public async Task<IActionResult> PostPD([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           await fileHandlerService.HandleHeadTrans(incomingFile);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logarduino")]
       public async Task<IActionResult> PostArduino([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           await fileHandlerService.HandleBraking(incomingFile);
           return Ok("Very nice yub");
       }
       // [HttpPost]
       // [Route("logsqlitetime")]
       // public async Task<IActionResult> PostTime([FromForm] IFormFile file){
       //     if(file.Length == 0 || file == null) return BadRequest();
       //     IncomingFile incomingFile = new();
       //     incomingFile.newTestFile = file;
       //     await fileHandlerService.HandleTimeCheck(incomingFile);
       //     return Ok("Very nice yub");
       // }
    }
}
