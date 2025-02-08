using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.API.Models;
using Train_project.Core.Entities;

namespace Train_project.Core.IServices
{
    public interface IPublicInquiryService
    {
        IEnumerable<PublicInquiryDto> GetAllPublicInquiries();
        PublicInquiryDto? GetPublicInquiryById(int id);
        PublicInquiryDto AddPublicInquiry(PublicInquiryDto publicInquity);
        PublicInquiryDto UpdatePublicInquiry(int id, PublicInquiryDto publicInquity);
        bool DeletePublicInquiry(int id);
        bool ValidData(PublicInquiryDto publicInquiry);
    }
}
