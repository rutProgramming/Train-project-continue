using Microsoft.AspNetCore.Mvc;
using Train_project.Core.Entities;
using Train_project.Core.IServices;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Train_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
         readonly IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }
        // GET: api/<StationController>
        [HttpGet]
        public ActionResult<IEnumerable<StationEntity>> Get()
        {
            return _stationService.GetAllStations().ToList();
        }

        // GET api/<StationController>/5
        [HttpGet("{id}")]
        public ActionResult<StationEntity> Get(int id)
        {
            if (id <= 0) return BadRequest();
            StationEntity? station = _stationService.GetStationById(id);
            if (station == null)
            {
                return NotFound();
            }
            return station;
        }

        // POST api/<StationController>
        [HttpPost]
        public ActionResult<StationEntity> Post([FromBody] StationEntity station)
        {
            if (station == null) return BadRequest();
            station=_stationService.AddStation(station);
            if (station==null) {return BadRequest();}
            return station;
            
        }

        // PUT api/<StationController>/5
        [HttpPut("{id}")]
        public ActionResult<StationEntity> Put(int id, [FromBody] StationEntity station)
        {
            station = _stationService.UpdateStation(id, station);
            if (station!=null)
            {
                return station;
            }
            return NotFound();
        }

        // DELETE api/<StationController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            bool success = _stationService.DeleteStation(id);
            if (success)
            {
                return id;
            }
            return NotFound();
        }
    }
}
