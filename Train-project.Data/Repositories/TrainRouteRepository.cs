using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;

namespace Train_project.Data.Repositories
{
    public class TrainRouteRepository :Repository<TrainRouteEntity>, ITrainRouteRepository
    {
        public TrainRouteRepository(DataContext dataContext):base(dataContext) { }
        
        public TrainRouteEntity UpdateTrainRoute(int id, TrainRouteEntity updatedTrainRoute)
        {
            TrainRouteEntity existingTrainRoute = GetById(id);
            if (updatedTrainRoute.Driver != null)
                existingTrainRoute.Driver = updatedTrainRoute.Driver;

            if (updatedTrainRoute.Train != null)
                existingTrainRoute.Train = updatedTrainRoute.Train;

            if (updatedTrainRoute.Station != null)
                existingTrainRoute.Station = updatedTrainRoute.Station;

            if (updatedTrainRoute.FirstTrain != default)
                existingTrainRoute.FirstTrain = updatedTrainRoute.FirstTrain;

            if (updatedTrainRoute.LastTrain != default)
                existingTrainRoute.LastTrain = updatedTrainRoute.LastTrain;

            if (updatedTrainRoute.SubstituteDriverId != 0)
                existingTrainRoute.SubstituteDriverId = updatedTrainRoute.SubstituteDriverId;

            return existingTrainRoute;
        }
       
    }
}
