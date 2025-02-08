using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.API.Models;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;
using Train_project.Core.IServices;

namespace Train_project.Service.Services
{
    public class TrainService : ITrainService
    {
        private readonly ITrainRepository _trainRepository;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public TrainService(ITrainRepository trainRepository,IRepositoryManager repositoryManage,IMapper mapper)
        {
            _trainRepository = trainRepository;
            _repositoryManager = repositoryManage;
            _mapper = mapper;
        }
        public IEnumerable<TrainDto> GetAllTrains()
        {
            IEnumerable< TrainEntity> train= _trainRepository.GetAll();
            return _mapper.Map<IEnumerable<TrainDto>>(train);
        }

        public TrainDto? GetTrainById(int id)
        {
            TrainEntity train = _trainRepository.GetById(id);
            return _mapper.Map<TrainDto>(train);


        }
        public TrainDto AddTrain(TrainDto trainDto)
        {
            var train = _trainRepository.GetById(trainDto.Id);
            if (train== null)
            {
                train=_mapper.Map<TrainEntity>(trainDto);
                _trainRepository.AddEntity(train);
                _repositoryManager.save();
                trainDto.Id = train.Id;
                return trainDto;
            }
            return null;
        }
        public TrainDto UpdateTrain(int id, TrainDto trainDto)
        {
            var train = _trainRepository.GetById(id);
            if (train != null)
            {
                train = _mapper.Map<TrainEntity>(trainDto);
                train = _trainRepository.UpdateTrain(id, train);
                _repositoryManager.save();
                trainDto.Id = train.Id;
                return trainDto;
            }
            return null;
        }
        public bool DeleteTrain(int id)
        {
            TrainEntity TrainCheck = _trainRepository.GetById(id);
            if (TrainCheck != null)
            {
                _trainRepository.DeleteEntity(id);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

    }
}
