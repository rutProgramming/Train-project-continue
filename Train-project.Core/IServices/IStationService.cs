using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;

namespace Train_project.Core.IServices
{
    public interface IStationService
    {
       IEnumerable<StationEntity> GetAllStations();
       StationEntity? GetStationById(int id);
       StationEntity AddStation(StationEntity station);
       StationEntity UpdateStation(int id, StationEntity station);
       bool DeleteStation(int id);
       bool ValidData(StationEntity station);
    }
}
