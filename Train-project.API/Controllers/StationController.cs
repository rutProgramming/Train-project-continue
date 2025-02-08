using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Train_project.API.Models;
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
        private readonly IMapper _mapper;

        public StationController(IStationService stationService,IMapper mapper)
        {
            _stationService = stationService;
            _mapper = mapper;
        }
        // GET: api/<StationController>
        [HttpGet]
        public ActionResult<IEnumerable<StationDto>> Get()
        {
            return _stationService.GetAllStations().ToList();
        }

        // GET api/<StationController>/5
        [HttpGet("{id}")]
        public ActionResult<StationDto> Get(int id)
        {
            if (id <= 0) return BadRequest();
            StationDto? station = _stationService.GetStationById(id);
            if (station == null)
            {
                return NotFound();
            }
            return station;
        }

        // POST api/<StationController>
        [HttpPost]
        public ActionResult<StationDto> Post([FromBody] StationPostModal station)
        {
            if (station == null) return BadRequest();
            var stationDto=_mapper.Map<StationDto>(station);
            stationDto = _stationService.AddStation(stationDto);
            if (stationDto == null) {return BadRequest();}
            return stationDto;
            
        }

        // PUT api/<StationController>/5
        [HttpPut("{id}")]
        public ActionResult<StationDto> Put(int id, [FromBody] StationPostModal station)
        {
            var stationDto = _mapper.Map<StationDto>(station);
            stationDto = _stationService.UpdateStation(id, stationDto);
            if (stationDto != null)
            {
                return stationDto;
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
