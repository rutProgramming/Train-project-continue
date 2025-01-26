using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;

namespace Train_project.Data.Repositories
{
    public class TrainRouteRepository : Repository<TrainRouteEntity>, ITrainRouteRepository
    {
        public TrainRouteRepository(DataContext dataContext) : base(dataContext) { }
        public IEnumerable<TrainRouteEntity> GetAll()
        {
            return _dbSet.Include(t => t.Train).Include(t => t.Driver).Include(t => t.Station);
        }


        public TrainRouteEntity UpdateTrainRoute(int id, TrainRouteEntity updatedTrainRoute)
        {
            TrainRouteEntity existingTrainRoute = GetById(id);
            existingTrainRoute.DriverId = updatedTrainRoute.DriverId;
            existingTrainRoute.TrainId = updatedTrainRoute.TrainId;
            existingTrainRoute.StationId = updatedTrainRoute.StationId;
            existingTrainRoute.FirstTrain = updatedTrainRoute.FirstTrain;
            existingTrainRoute.LastTrain = updatedTrainRoute.LastTrain;
            existingTrainRoute.SubstituteDriverId = updatedTrainRoute.SubstituteDriverId;
            return existingTrainRoute;
        }

    }
}
