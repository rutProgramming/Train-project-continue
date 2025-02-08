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
    public class PublicInquiryController : ControllerBase
    {
       private readonly IPublicInquiryService _publicInquityService;
       private readonly IMapper _mapper;

        public PublicInquiryController(IPublicInquiryService publicInquityService,IMapper mapper)
        {
            _publicInquityService = publicInquityService;
            _mapper = mapper;
        }
        // GET: api/<PublicInquiryController>
        [HttpGet]
        public ActionResult<IEnumerable<PublicInquiryDto>> Get()
        {
            return _publicInquityService.GetAllPublicInquiries().ToList();
        }

        // GET api/<PublicInquiryController>/5
        [HttpGet("{id}")]
        public ActionResult<PublicInquiryDto> Get(int id)
        {
            if (id<=0) return BadRequest();
            PublicInquiryDto? publicInquiry = _publicInquityService.GetPublicInquiryById(id);
            if (publicInquiry == null)
            {
                return NotFound();
            }
            return publicInquiry;
        }

        // POST api/<PublicInquiryController>
        [HttpPost]
        public ActionResult<PublicInquiryDto> Post([FromBody] PublicInquiryPostModal publicInquiry)
        {
            if (publicInquiry == null)
                return BadRequest();
            var publicInquiryDto=_mapper.Map<PublicInquiryDto>(publicInquiry);
            publicInquiryDto = _publicInquityService.AddPublicInquiry(publicInquiryDto);
             if (publicInquiryDto == null)
                return BadRequest();
            return publicInquiryDto;

        }

        // PUT api/<PublicInquiryController>/5
        [HttpPut("{id}")]
        public ActionResult<PublicInquiryDto> Put(int id, [FromBody] PublicInquiryPostModal publicInquiry)
        {
            var publicInquiryDto = _mapper.Map<PublicInquiryDto>(publicInquiry);
            publicInquiryDto = _publicInquityService.UpdatePublicInquiry(id, publicInquiryDto);
            if (publicInquiryDto != null)
            {
                return publicInquiryDto;
            }
            return NotFound();
        }

        // DELETE api/<PublicInquiryController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            bool success = _publicInquityService.DeletePublicInquiry(id);
            if (success)
            {
                return id;
            }
            return NotFound();
        }
    }
}
