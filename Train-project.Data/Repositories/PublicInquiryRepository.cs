using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;

namespace Train_project.Data.Repositories
{
    public class PublicInquiryRepository :Repository<PublicInquiryEntity>, IPublicInquiryRepository
    {
        public PublicInquiryRepository(DataContext Context) : base(Context) { }
        
        //question exists/not do it hear?
        public PublicInquiryEntity UpdatePublicInquiry(int id, PublicInquiryEntity updatedInquiry)
        {

            PublicInquiryEntity existingInquiry = GetById(id);

            if (updatedInquiry.DriverId > 0)
                existingInquiry.DriverId = updatedInquiry.DriverId;

            if (updatedInquiry.DateAndTime != default)
                existingInquiry.DateAndTime = updatedInquiry.DateAndTime;

            if (!string.IsNullOrEmpty(updatedInquiry.DescriptionInquiry))
                existingInquiry.DescriptionInquiry = updatedInquiry.DescriptionInquiry;
            if (updatedInquiry.StatusInquiry != default)
            {
                existingInquiry.StatusInquiry = updatedInquiry.StatusInquiry;
            }

            if (updatedInquiry.TreatedBy > 0)
                existingInquiry.TreatedBy = updatedInquiry.TreatedBy;

            if (!string.IsNullOrEmpty(updatedInquiry.ComplainantsName))
                existingInquiry.ComplainantsName = updatedInquiry.ComplainantsName;

            if (!string.IsNullOrEmpty(updatedInquiry.ComplainantsPhone))
                existingInquiry.ComplainantsPhone = updatedInquiry.ComplainantsPhone;

            return existingInquiry;
        }
        
    }
}

