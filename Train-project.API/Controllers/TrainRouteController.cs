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
    public class TrainRouteController : ControllerBase
    {
        private readonly ITrainRouteService _trainRouteService;
        private readonly IMapper _mapper;

        public TrainRouteController(ITrainRouteService trainRouteService,IMapper mapper)
        {
            _trainRouteService= trainRouteService;
            _mapper=mapper;
        }
        // GET: api/<TrainRouteController>
        [HttpGet]
        public ActionResult<IEnumerable<TrainRouteDto>> Get()
        {
           return _trainRouteService.GetAllTrainRoutes().ToList();
        }

        // GET api/<TrainRouteController>/5
        [HttpGet("{id}")]
        public ActionResult<TrainRouteDto> Get(int id)
        {
            if (id<=0) return BadRequest();
            TrainRouteDto? trainRoute = _trainRouteService.GetTrainRouteById(id);
            if (trainRoute == null)
            {
                return NotFound();
            }
            return trainRoute;
        }

        // POST api/<TrainRouteController>
        [HttpPost]
        public ActionResult<TrainRouteDto> Post([FromBody] TrainRoutePostModal trainRoute)
        {
            if (trainRoute == null) return BadRequest();
            var trainRouteDto=_mapper.Map<TrainRouteDto>(trainRoute);
            trainRouteDto = _trainRouteService.AddTrainRoute(trainRouteDto);
            if (trainRouteDto ==null) return BadRequest();
            return trainRouteDto;
        }

        // PUT api/<TrainRouteController>/5
        [HttpPut("{id}")]
        public ActionResult<TrainRouteDto> Put(int id, [FromBody] TrainRoutePostModal trainRoute)
        {
            var trainRouteDto = _mapper.Map<TrainRouteDto>(trainRoute);
            trainRouteDto = _trainRouteService.UpdateTrainRoute(id, trainRouteDto);
            if (trainRouteDto != null)
            {
                return trainRouteDto;
            }
            return NotFound();
        }

        // DELETE api/<TrainRouteController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            bool success = _trainRouteService.DeleteTrainRoute(id);
            if (success)
            {
                return id;
            }
            return NotFound();
        }
    }
}
