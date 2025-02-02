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
        public IEnumerable<TrainRoutDto> GetAllTrainRoutes()
        {
            IEnumerable<TrainRouteEntity> trainRoutes= _trainRouteRepository.GetAll();
            return _mapper.Map<IEnumerable<TrainRoutDto>>(trainRoutes);
        }

        public TrainRoutDto? GetTrainRouteById(int id)
        {
            TrainRouteEntity trainRoute= _trainRouteRepository.GetById(id);
            return _mapper.Map<TrainRoutDto>(trainRoute);

        }
        public TrainRouteEntity AddTrainRoute(TrainRouteEntity trainRoute)
        {
            TrainRouteEntity TrainRouteCheck = _trainRouteRepository.GetById(trainRoute.Id);
            if (TrainRouteCheck == null /*&& ValidData(trainRoute)*/)
            {
                 _trainRouteRepository.AddEntity(trainRoute);
                _repositoryManager.save();
                return trainRoute;
            }
            return null;
        }

        public TrainRouteEntity UpdateTrainRoute(int id, TrainRouteEntity trainRoute)
        {
            TrainRouteEntity TrainRouteCheck = _trainRouteRepository.GetById(id);

            if (TrainRouteCheck != null && ValidData(trainRoute))
            {
                trainRoute = _trainRouteRepository.UpdateTrainRoute(id, trainRoute);
                _repositoryManager.save();
                return trainRoute;
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

        public bool ValidData(TrainRouteEntity trainRoute)
        {
            return (trainRoute.FirstTrain == default || trainRoute.LastTrain == default) ? true : Valid.LastTimeAfterFirstTime(trainRoute.FirstTrain, trainRoute.LastTrain);
        }
    }
}

