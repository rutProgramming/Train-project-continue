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

        public IEnumerable<PublicInquiryEntity> GetAll()
        {
            return _dbSet.Include(p => p.Driver).Include(p=>p.Worker);
        }
        public PublicInquiryEntity UpdatePublicInquiry(int id, PublicInquiryEntity updatedInquiry)
        {

            PublicInquiryEntity existingInquiry = GetById(id);
            existingInquiry.DriverId = updatedInquiry.DriverId;
            existingInquiry.DateAndTime = updatedInquiry.DateAndTime;
            existingInquiry.Description = updatedInquiry.Description;
            existingInquiry.Status = updatedInquiry.Status;
            existingInquiry.TreatedBy = updatedInquiry.TreatedBy;
            existingInquiry.ComplainantsName = updatedInquiry.ComplainantsName;
            existingInquiry.ComplainantsPhone = updatedInquiry.ComplainantsPhone;
            return existingInquiry;
        }

      
    }
}

