using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;
using Train_project.Core.IServices;

namespace Train_project.Service.Services
{
    public class PublicInquiryService : IPublicInquiryService
    {
       private readonly IPublicInquiryRepository _publicInquiryRepository;
        private readonly IRepositoryManager _repositoryManager;
        public PublicInquiryService(IPublicInquiryRepository publicInquiryRepository, IRepositoryManager repositoryManager)
        {
            _publicInquiryRepository = publicInquiryRepository;
            _repositoryManager = repositoryManager;

        }
        public IEnumerable<PublicInquiryEntity> GetAllPublicInquiries()
        {
            return _publicInquiryRepository.GetAll();
        }
        
        public PublicInquiryEntity? GetPublicInquiryById(int id)
        {
            return _publicInquiryRepository.GetById(id);
           
        }
        public PublicInquiryEntity AddPublicInquiry(PublicInquiryEntity publicInquiry)
        {
            PublicInquiryEntity publicInquiryCheck =_publicInquiryRepository.GetById(publicInquiry.Id);
            if (publicInquiryCheck == null&&ValidData(publicInquiry))
            {
                 _publicInquiryRepository.AddEntity(publicInquiry);
                _repositoryManager.save();
                return publicInquiry;
            }
            return null;
        }
        public PublicInquiryEntity UpdatePublicInquiry(int id, PublicInquiryEntity publicInquiry)
        {
            PublicInquiryEntity publicInquiryCheck = _publicInquiryRepository.GetById(publicInquiry.Id);
            if (publicInquiryCheck != null&&ValidData(publicInquiry))
            {
                publicInquiry= _publicInquiryRepository.UpdatePublicInquiry(id,publicInquiry);
                _repositoryManager.save();
                return publicInquiry;
            }
            return null;
        }
        public bool DeletePublicInquiry(int id)
        {
            PublicInquiryEntity publicInquiryCheck = _publicInquiryRepository.GetById(id);
            if (publicInquiryCheck != null)
            {
                _publicInquiryRepository.DeleteEntity(id);
                _repositoryManager.save();

                return true;
            }
            return false;
        }
        public bool ValidData(PublicInquiryEntity publicInquiry)
        {
            return string.IsNullOrEmpty(publicInquiry.ComplainantsPhone)?true:Valid.IsIsraeliPhoneNumberValid(publicInquiry.ComplainantsPhone);
        }
    }
}
