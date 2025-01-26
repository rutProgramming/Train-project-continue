using Microsoft.AspNetCore.Mvc;
using Train_project.Core.Entities;
using Train_project.Core.IServices;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Train_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
         readonly ITrainService _trainService;
        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }
        // GET: api/<TrainController>
        [HttpGet]
        public ActionResult<IEnumerable<TrainEntity>> Get()
        {
            return _trainService.GetAllTrains().ToList();
            
        }

        // GET api/<TrainController>/5
        [HttpGet("{id}")]
        public ActionResult<TrainEntity> Get(int id)
        {
            if (id<=0) return BadRequest();
            TrainEntity? train = _trainService.GetTrainById(id);
            if (train == null)
            {
                return NotFound();
            }
            return train;
        }

        // POST api/<TrainController>
        [HttpPost]
        public ActionResult<TrainEntity> Post([FromBody] TrainEntity train)
        {
            if (train == null) return BadRequest();
            train = _trainService.AddTrain(train);
            if (train==null)
            {
                return BadRequest();
            }
            return train;

        }

        // PUT api/<TrainController>/5
        [HttpPut("{id}")]
        public ActionResult<TrainEntity> Put(int id, [FromBody] TrainEntity train)
        {
            
            train = _trainService.UpdateTrain(id, train);
            if (train!=null)
            {
                return train;
            }
            return NotFound();
        }

        // DELETE api/<TrainController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            bool success = _trainService.DeleteTrain(id);
            if (success)
            {
                return id;
            }
            return NotFound();
        }
    }
}
