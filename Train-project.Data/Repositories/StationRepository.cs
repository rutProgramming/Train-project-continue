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
    public class StationRepository : Repository<StationEntity>, IStationRepository
    {
        public StationRepository(DataContext context) : base(context) { }

        
        public StationEntity UpdateStation(int id, StationEntity updatedStation)
        {
            StationEntity existingStation = GetById(id);
            existingStation.Name = updatedStation.Name;
            existingStation.Address = updatedStation.Address;
            existingStation.City = updatedStation.City;
            existingStation.LocationGPSCoordinates.X = updatedStation.LocationGPSCoordinates.X;
            existingStation.LocationGPSCoordinates.Y = updatedStation.LocationGPSCoordinates.Y;
            existingStation.Type = updatedStation.Type;
            existingStation.NumberOfPlatforms = updatedStation.NumberOfPlatforms;
            return existingStation;

        }

    }
}
