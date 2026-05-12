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
       [HttpGet("{userId}")]
       public IActionResult GetUser(int userId){
           User u = carDataSqliteRepository.GetUser(userId);
           if(userId == 0){
               return BadRequest();
            }
           return Ok(u);
       }
       [HttpPost]
       [Route("logbikedata")]
       public async Task<IActionResult> PostBD(string incomingText){
           // if(file.Length == 0 || file == null) return BadRequest();
           // IncomingFile incomingFile = new();
           // incomingFile.newTestFile = file;
           // await fileHandlerService.HandleBikeData(incomingFile);
           if(string.IsNullOrEmpty(incomingText)) return BadRequest();
           await stringHandlerService.AddBikeData(incomingText);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logsqlitescenario")]
       public async Task<IActionResult> PostScenarios([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           await fileHandlerService.HandleScenarios(incomingFile);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logsqlitehtf")]
       public async Task<IActionResult> PostPD([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           await fileHandlerService.HandleHeadTrans(incomingFile);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logsqlitearduino")]
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
