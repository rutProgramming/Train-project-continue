using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;

namespace Train_project.Core.IServices
{
    public interface IPublicInquiryService
    {
        IEnumerable<PublicInquiryEntity> GetAllPublicInquiries();
        PublicInquiryEntity? GetPublicInquiryById(int id);
        PublicInquiryEntity AddPublicInquiry(PublicInquiryEntity publicInquity);
        PublicInquiryEntity UpdatePublicInquiry(int id, PublicInquiryEntity publicInquity);
        bool DeletePublicInquiry(int id);
        bool ValidData(PublicInquiryEntity publicInquiry);
    }
}
