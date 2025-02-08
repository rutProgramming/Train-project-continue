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
    public class TrainRouteService : ITrainRouteService
    {
        private readonly ITrainRouteRepository _trainRouteRepository;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public TrainRouteService(ITrainRouteRepository trainRouteRepository, IRepositoryManager repositoryManager,IMapper mapper)
        {
            _trainRouteRepository = trainRouteRepository;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public IEnumerable<TrainRouteDto> GetAllTrainRoutes()
        {
            IEnumerable<TrainRouteEntity> trainRoutes= _trainRouteRepository.GetAll();
            return _mapper.Map<IEnumerable<TrainRouteDto>>(trainRoutes);
        }

        public TrainRouteDto? GetTrainRouteById(int id)
        {
            TrainRouteEntity trainRoute= _trainRouteRepository.GetById(id);
            return _mapper.Map<TrainRouteDto>(trainRoute);

        }
        public TrainRouteDto AddTrainRoute(TrainRouteDto trainRouteDto)
        {
            var trainRoute = _trainRouteRepository.GetById(trainRouteDto.Id);
            if (trainRoute == null && ValidData(trainRouteDto))
            {
                trainRoute = _mapper.Map<TrainRouteEntity>(trainRouteDto);
                 _trainRouteRepository.AddEntity(trainRoute);
                _repositoryManager.save();
                trainRouteDto.Id = trainRoute.Id;
                return trainRouteDto;
            }
            return null;
        }

        public TrainRouteDto UpdateTrainRoute(int id, TrainRouteDto trainRouteDto)
        {
            TrainRouteEntity trainRoute = _trainRouteRepository.GetById(id);

            if (trainRoute != null && ValidData(trainRouteDto))
            {
                trainRoute = _mapper.Map<TrainRouteEntity>(trainRouteDto);
                trainRoute = _trainRouteRepository.UpdateTrainRoute(id, trainRoute);
                _repositoryManager.save();
                trainRouteDto.Id = trainRoute.Id;
                return trainRouteDto;
            }
            return null;
        }
        public bool DeleteTrainRoute(int id)
        {
            TrainRouteEntity TrainRouteCheck = _trainRouteRepository.GetById(id);
            if (TrainRouteCheck != null)
            {
                _repositoryManager.save();
                _trainRouteRepository.DeleteEntity(id);
                return true;
            }
            return false;
        }

        public bool ValidData(TrainRouteDto trainRoute)
        {
            return (trainRoute.FirstTrain == default || trainRoute.LastTrain == default) ? true : Valid.LastTimeAfterFirstTime(trainRoute.FirstTrain, trainRoute.LastTrain);
        }
    }
}

