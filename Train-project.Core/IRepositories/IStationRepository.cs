using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;

namespace Train_project.Core.IRepositories
{
    public interface IStationRepository:IRepository<StationEntity>
    {
        StationEntity UpdateStation(int id, StationEntity station);
    }
}
