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
        readonly IPublicInquiryService _publicInquityService;
        public PublicInquiryController(IPublicInquiryService publicInquityService)
        {
            _publicInquityService = publicInquityService;
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
        public ActionResult<PublicInquiryEntity> Post([FromBody] PublicInquiryEntity publicInquiry)
        {
            if (publicInquiry == null)
                return BadRequest();
             publicInquiry= _publicInquityService.AddPublicInquiry(publicInquiry);
             if (publicInquiry==null)
                return BadRequest();
            return publicInquiry;

        }

        // PUT api/<PublicInquiryController>/5
        [HttpPut("{id}")]
        public ActionResult<PublicInquiryEntity> Put(int id, [FromBody] PublicInquiryEntity publicInquiry)
        {
            publicInquiry = _publicInquityService.UpdatePublicInquiry(id, publicInquiry);
            if (publicInquiry!=null)
            {
                return publicInquiry;
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
