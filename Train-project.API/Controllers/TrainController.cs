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
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _trainService;
        private readonly IMapper _mapper;

        public TrainController(ITrainService trainService,IMapper mapper)
        {
            _trainService = trainService;
            _mapper = mapper;
        }
        // GET: api/<TrainController>
        [HttpGet]
        public ActionResult<IEnumerable<TrainDto>> Get()
        {
            return _trainService.GetAllTrains().ToList();
            
        }

        // GET api/<TrainController>/5
        [HttpGet("{id}")]
        public ActionResult<TrainDto> Get(int id)
        {
            if (id<=0) return BadRequest();
            TrainDto? train = _trainService.GetTrainById(id);
            if (train == null)
            {
                return NotFound();
            }
            return train;
        }

        // POST api/<TrainController>
        [HttpPost]
        public ActionResult<TrainDto> Post([FromBody] TrainPostModel train)
        {
            if (train == null) return BadRequest();
            var trainDto=_mapper.Map<TrainDto>(train);
            trainDto = _trainService.AddTrain(trainDto);
            if (trainDto == null)
            {
                return BadRequest();
            }
            return trainDto;

        }

        // PUT api/<TrainController>/5
        [HttpPut("{id}")]
        public ActionResult<TrainDto> Put(int id, [FromBody] TrainPostModel train)
        {
            var trainDto = _mapper.Map<TrainDto>(train);
            trainDto = _trainService.UpdateTrain(id, trainDto);
            if (trainDto != null)
            {
                return trainDto;
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
