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
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public StationService(IStationRepository stationRepository, IRepositoryManager repositoryManager,IMapper mapper)
        {
            _stationRepository = stationRepository;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<StationDto> GetAllStations()
        {
            IEnumerable< StationEntity> stations= _stationRepository.GetAll();
            return _mapper.Map<IEnumerable<StationDto>>(stations);
        }
        public StationDto? GetStationById(int id)
        {

            StationEntity  stations = _stationRepository.GetById(id);
            return _mapper.Map<StationDto>(stations);


        }
        public StationDto AddStation(StationDto stationDto)
        {
            var station = _stationRepository.GetById(stationDto.Id);
            if (station== null && ValidData(stationDto))
            {
                station=_mapper.Map<StationEntity>(stationDto);
                _stationRepository.AddEntity(station);
                _repositoryManager.save();
                stationDto.Id = station.Id;
                return stationDto;
            }
            return null;
        }
        public StationDto UpdateStation(int id, StationDto stationDto)
        {
            var station = _stationRepository.GetById(id);

            if (station!= null && ValidData(stationDto))
            {
                station = _mapper.Map<StationEntity>(stationDto);
                station = _stationRepository.UpdateStation(id, station);
                _repositoryManager.save();
                stationDto.Id = station.Id;
                return stationDto;

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
        public bool ValidData(StationDto station)
        {
            return station.LocationGPSCoordinates == null || Valid.IsValidGPSCoordinates(station.LocationGPSCoordinates);
        }


    }
}
