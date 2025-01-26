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
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IRepositoryManager _repositoryManager;
        public StationService(IStationRepository stationRepository, IRepositoryManager repositoryManager)
        {
            _stationRepository = stationRepository;
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<StationEntity> GetAllStations()
        {
            return _stationRepository.GetAll();
        }
        public StationEntity? GetStationById(int id)
        {
            return _stationRepository.GetById(id);

        }
        public StationEntity AddStation(StationEntity station)
        {
            StationEntity StationCheck = _stationRepository.GetById(station.Id);
            if (StationCheck == null && ValidData(station))
            {
                _stationRepository.AddEntity(station);
                _repositoryManager.save();
                return station;
            }
            return null;
        }
        public StationEntity UpdateStation(int id, StationEntity station)
        {
            StationEntity StationCheck = _stationRepository.GetById(id);

            if (StationCheck != null && ValidData(station))
            {
                station = _stationRepository.UpdateStation(id, station);
                _repositoryManager.save();
                return station;

            }
            return null;
        }
        public bool DeleteStation(int id)
        {
            StationEntity StationCheck = _stationRepository.GetById(id);
            if (StationCheck != null)
            {
                _stationRepository.DeleteEntity(id);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
        public bool ValidData(StationEntity station)
        {
            return station.LocationGPSCoordinates == null || Valid.IsValidGPSCoordinates(station.LocationGPSCoordinates);
        }


    }
}
