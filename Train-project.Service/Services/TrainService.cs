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
    public class TrainService : ITrainService
    {
        private readonly ITrainRepository _trainRepository;
        private readonly IRepositoryManager _repositoryManager;
        public TrainService(ITrainRepository trainRepository,IRepositoryManager repositoryManager)
        {
            _trainRepository = trainRepository;
            _repositoryManager = repositoryManager;
        }
        public IEnumerable<TrainEntity> GetAllTrains()
        {
            return _trainRepository.GetAll();
        }

        public TrainEntity? GetTrainById(int id)
        {
            return _trainRepository.GetById(id);

        }
        public TrainEntity AddTrain(TrainEntity train)
        {
            TrainEntity TrainCheck = _trainRepository.GetById(train.Id);
            if (TrainCheck == null)
            {
                _trainRepository.AddEntity(train);
                _repositoryManager.save();
                return train;
            }
            return null;
        }
        public TrainEntity UpdateTrain(int id, TrainEntity train)
        {
            TrainEntity TrainCheck = _trainRepository.GetById(id);
            if (TrainCheck != null)
            {
                train = _trainRepository.UpdateTrain(id, train);
                _repositoryManager.save();
                return train;
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
