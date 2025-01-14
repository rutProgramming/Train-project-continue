﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;
using Train_project.Core.IServices;

namespace Train_project.Service.Services
{
    public class TrainRouteService : ITrainRouteService
    {
        private readonly ITrainRouteRepository _trainRouteRepository;
        private readonly IRepositoryManager _repositoryManager;
        public TrainRouteService(ITrainRouteRepository trainRouteRepository, IRepositoryManager repositoryManager)
        {
            _trainRouteRepository = trainRouteRepository;
            _repositoryManager = repositoryManager;

        }
        public List<TrainRouteEntity> GetAllTrainRoutes()
        {
            return _trainRouteRepository.GetAll();
        }

        public TrainRouteEntity? GetTrainRouteById(int id)
        {
            return _trainRouteRepository.GetById(id);

        }
        public TrainRouteEntity AddTrainRoute(TrainRouteEntity trainRoute)
        {
            TrainRouteEntity TrainRouteCheck = _trainRouteRepository.GetById(trainRoute.TrainRouteId);
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

