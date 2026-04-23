using CARDataLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cardataapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDataController : ControllerBase
    {
        private CarDataRepository carDataRepository;
        public CarDataController(CarDataRepository carDataRepository)
        {
            this.carDataRepository = carDataRepository;
        }
        // GET: api/<PostController>
        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = carDataRepository.GetUsers();
            if(users != null)
                return Ok(users);
            else
                return BadRequest();
        }
        [HttpPost]
        [Route("userp")]
        public IActionResult Post([FromBody] User user)
        {
            if (user != null)
            {
                User testuser = carDataRepository.AddFirstInstanceOfUser(user);
                return Ok(testuser);
            }
            else
            {
                return BadRequest();
            }
        }
        //POST api/<PostController>
        [HttpPost]
        [Route("postsession")]
        public IActionResult Post([FromBody] int userId)
        {
            carDataRepository.AddSession(userId);
            if(userId != 0)
            {
                return Ok("Session startet");
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<PostController>/5
        [HttpPost]
        [Route("postscenario")]
        public IActionResult Post([FromBody] Scenario scenario, int sessionid)
        {
            Scenario newscenario = carDataRepository.AddScenario(scenario, sessionid);
            if(newscenario != null)
            {
                return Ok(newscenario);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("postpulsedata")]
        public IActionResult Post([FromBody] PulseData pulseData, int userId)
        {
            PulseData newpulseData = carDataRepository.AddPulseData(pulseData, userId);
            if (newpulseData != null)
            {
                return Ok(newpulseData);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("posttimecheck")]
        public IActionResult Post([FromBody] TimeCheck timeCheck)
        {
            TimeCheck newtimecheck = carDataRepository.AddTimeCheck(timeCheck);
            if (newtimecheck != null)
            {
                return Ok(newtimecheck);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("postbikedata")]
        public IActionResult Post([FromBody] BikeData bikeData, int userId)
        {
            BikeData newbikeDate = carDataRepository.AddBikeData(bikeData, userId);
            if (newbikeDate != null)
            {
                return Ok(newbikeDate);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("postheadtransform")]
        public IActionResult Post([FromBody] HeadTransform headTransform, int userId)
        {
            HeadTransform newheadTransform = carDataRepository.AddHeadTransform(headTransform, userId);
            if (headTransform != null)
            {
                return Ok(headTransform);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

