using Microsoft.AspNetCore.Mvc;
namespace cardataapi.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class CarDataSqliteController : ControllerBase
    {
       private FileHandlerService fileHandlerService;
       public CarDataSqliteController(FileHandlerService fileHandlerService){
           this.fileHandlerService = fileHandlerService;
       }
       [HttpPost]
       [Route("logsqlitebikedata")]
       public IActionResult PostBD([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           fileHandlerService.HandleBikeData(incomingFile);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logsqlitescenario")]
       public IActionResult PostScenarios([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           fileHandlerService.HandleScenarios(incomingFile);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logsqlitehtf")]
       public IActionResult PostPD([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           fileHandlerService.HandleHeadTrans(incomingFile);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logsqlitearduino")]
       public IActionResult PostArduino([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           fileHandlerService.HandleBraking(incomingFile);
           return Ok("Very nice yub");
       }
       [HttpPost]
       [Route("logsqlitetime")]
       public IActionResult PostTime([FromForm] IFormFile file){
           if(file.Length == 0 || file == null) return BadRequest();
           IncomingFile incomingFile = new();
           incomingFile.newTestFile = file;
           fileHandlerService.HandleTimeCheck(incomingFile);
           return Ok("Very nice yub");
       }
    }
}
