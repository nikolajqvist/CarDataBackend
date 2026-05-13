using Microsoft.AspNetCore.Mvc;
using CARDataLib;
namespace cardataapi.Controllers{

    [Route("api/cardata")]
    [ApiController]
    public class CarDataSqliteController : ControllerBase
    {
       private ByteHandlerService byteHandlerService; 
       // private FileHandlerService fileHandlerService;
       private CarDataSqliteRepository carDataSqliteRepository;
       // private StringHandlerService stringHandlerService;
       public CarDataSqliteController(ByteHandlerService byteHandlerService, /*StringHandlerService stringHandlerService, FileHandlerService fileHandlerService*/ CarDataSqliteRepository carDataSqliteRepository){
           this.byteHandlerService = byteHandlerService;
           this.carDataSqliteRepository = carDataSqliteRepository;
           // this.fileHandlerService = fileHandlerService;
           // this.stringHandlerService = stringHandlerService;
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
       public async Task<IActionResult> PostBD(){
           // if(file.Length == 0 || file == null) return BadRequest();
           // IncomingFile incomingFile = new();
           // incomingFile.newTestFile = file;
           // await fileHandlerService.HandleBikeData(incomingFile);
           // if(string.IsNullOrEmpty(incomingText)) return BadRequest();
           // await stringHandlerService.AddBikeData(incomingText);
           using var ms = new MemoryStream();
           await Request.Body.CopyToAsync(ms);

           byte[] incomingBytes = ms.ToArray();

           if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
           await byteHandlerService.ByteBikeData(incomingBytes);
           return Ok("Bikedata tilføjet i db!");
       }
       [HttpPost]
       [Route("logscenario")]
       public async Task<IActionResult> PostScenarios(){
           using var ms = new MemoryStream();
           await Request.Body.CopyToAsync(ms);

           byte[] incomingBytes = ms.ToArray();

           if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
           await byteHandlerService.ByteScenarios(incomingBytes);
           return Ok("Scenariedata tilføjet i db!");
       }
       [HttpPost]
       [Route("loghtf")]
       public async Task<IActionResult> PostPD(){
           // if(file.Length == 0 || file == null) return BadRequest();
           // IncomingFile incomingFile = new();
           // incomingFile.newTestFile = file;

           using var ms = new MemoryStream();
           await Request.Body.CopyToAsync(ms);

           byte[] incomingBytes = ms.ToArray();

           if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
           await byteHandlerService.ByteHeadTransform(incomingBytes);
           return Ok("HeadTransformData tilføjet i db!");
       }
       [HttpPost]
       [Route("logarduino")]
       public async Task<IActionResult> PostArduino(){

           using var ms = new MemoryStream();
           await Request.Body.CopyToAsync(ms);

           byte[] incomingBytes = ms.ToArray();

           if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
           await byteHandlerService.ByteArduino(incomingBytes);
           return Ok("Arduinodata tilføjet i db!");
       }
       [HttpPost]
       [Route("logpulse")]
       public async Task<IActionResult> PostTime(){
           using var ms = new MemoryStream();
           await Request.Body.CopyToAsync(ms);

           byte[] incomingBytes = ms.ToArray();
           
           if(incomingBytes.Length == 0 || incomingBytes == null) return BadRequest();
           await byteHandlerService.BytePulseData(incomingBytes);
           return Ok("Very nice yub");
       }
    }
}
