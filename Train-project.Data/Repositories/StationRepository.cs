using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;
using static System.Collections.Specialized.BitVector32;

namespace Train_project.Data.Repositories
{
    public class StationRepository :Repository<StationEntity>, IStationRepository
    {
        public StationRepository(DataContext context) : base(context) { }
        

        public StationEntity UpdateStation(int id, StationEntity updatedStation)
        {
            StationEntity existingStation = GetById(id);

            if (!string.IsNullOrEmpty(updatedStation.StationName))
                existingStation.StationName = updatedStation.StationName;

            if (!string.IsNullOrEmpty(updatedStation.StationAddress))
                existingStation.StationAddress = updatedStation.StationAddress;

            if (!string.IsNullOrEmpty(updatedStation.StationCity))
                existingStation.StationCity = updatedStation.StationCity;

            if (!string.IsNullOrEmpty(updatedStation.LocationGPSCoordinates))
                existingStation.LocationGPSCoordinates = updatedStation.LocationGPSCoordinates;

            if (updatedStation.StationType != default)
                existingStation.StationType = updatedStation.StationType;

            if (updatedStation.NumberOfPlatforms > 0)
                existingStation.NumberOfPlatforms = updatedStation.NumberOfPlatforms;
            return existingStation;

        }
        
    }
}
