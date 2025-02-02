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
        readonly ITrainRouteService _trainRouteService;
        public TrainRouteController(ITrainRouteService trainRouteService)
        {
                _trainRouteService= trainRouteService;
        }
        // GET: api/<TrainRouteController>
        [HttpGet]
        public ActionResult<IEnumerable<TrainRoutDto>> Get()
        {
           return _trainRouteService.GetAllTrainRoutes().ToList();
        }

        // GET api/<TrainRouteController>/5
        [HttpGet("{id}")]
        public ActionResult<TrainRoutDto> Get(int id)
        {
            if (id<=0) return BadRequest();
            TrainRoutDto? trainRoute = _trainRouteService.GetTrainRouteById(id);
            if (trainRoute == null)
            {
                return NotFound();
            }
            return trainRoute;
        }

        // POST api/<TrainRouteController>
        [HttpPost]
        public ActionResult<TrainRouteEntity> Post([FromBody] TrainRouteEntity trainRoute)
        {
            if (trainRoute == null) return BadRequest();
            trainRoute = _trainRouteService.AddTrainRoute(trainRoute);
            if (trainRoute==null) return BadRequest();
            return trainRoute;
        }

        // PUT api/<TrainRouteController>/5
        [HttpPut("{id}")]
        public ActionResult<TrainRouteEntity> Put(int id, [FromBody] TrainRouteEntity trainRoute)
        {
            trainRoute = _trainRouteService.UpdateTrainRoute(id, trainRoute);
            if (trainRoute!=null)
            {
                return trainRoute;
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
