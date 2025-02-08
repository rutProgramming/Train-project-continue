using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.API.Models;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;
using Train_project.Core.IServices;

namespace Train_project.Service.Services
{
    public class PublicInquiryService : IPublicInquiryService
    {
       private readonly IPublicInquiryRepository _publicInquiryRepository;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public PublicInquiryService(IPublicInquiryRepository publicInquiryRepository, IRepositoryManager repositoryManager,IMapper mapper)
        {
            _publicInquiryRepository = publicInquiryRepository;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public IEnumerable<PublicInquiryDto> GetAllPublicInquiries()
        {
            IEnumerable<PublicInquiryEntity> publicInquiries= _publicInquiryRepository.GetAll();
            return _mapper.Map<IEnumerable<PublicInquiryDto>>(publicInquiries);
        }
        
        public PublicInquiryDto? GetPublicInquiryById(int id)
        {
            PublicInquiryEntity publicInquiry =_publicInquiryRepository.GetById(id);
            return _mapper.Map<PublicInquiryDto>(publicInquiry);
           
        }
        public PublicInquiryDto AddPublicInquiry(PublicInquiryDto publicInquiryDto)
        {
            var publicInquiry =_publicInquiryRepository.GetById(publicInquiryDto.Id);
            if (publicInquiry == null&&ValidData(publicInquiryDto))
            {
                publicInquiry = _mapper.Map<PublicInquiryEntity>(publicInquiryDto);
                _publicInquiryRepository.AddEntity(publicInquiry);
                _repositoryManager.save();
                publicInquiryDto.Id = publicInquiry.Id;
                return publicInquiryDto;
            }
            return null;
        }
        public PublicInquiryDto UpdatePublicInquiry(int id, PublicInquiryDto publicInquiryDto)
        {
            var publicInquiry = _publicInquiryRepository.GetById(id);
            if (publicInquiry != null&&ValidData(publicInquiryDto))
            {
                publicInquiry= _mapper.Map<PublicInquiryEntity>( publicInquiryDto);
                publicInquiry= _publicInquiryRepository.UpdatePublicInquiry(id,publicInquiry);
                _repositoryManager.save();
                publicInquiryDto.Id = publicInquiry.Id;
                return publicInquiryDto;
            }
            return null;
        }
        public bool DeletePublicInquiry(int id)
        {
            var publicInquiryCheck = _publicInquiryRepository.GetById(id);
            if (publicInquiryCheck != null)
            {
                _publicInquiryRepository.DeleteEntity(id);
                _repositoryManager.save();

                return true;
            }
            return false;
        }
        public bool ValidData(PublicInquiryDto publicInquiry)
        {
            return string.IsNullOrEmpty(publicInquiry.ComplainantsPhone)?true:Valid.IsIsraeliPhoneNumberValid(publicInquiry.ComplainantsPhone);
        }
    }
}
