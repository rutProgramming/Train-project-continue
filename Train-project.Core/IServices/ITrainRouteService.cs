using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.API.Models;
using Train_project.Core.Entities;

namespace Train_project.Core.IServices
{
    public interface ITrainRouteService
    {
        IEnumerable<TrainRouteDto> GetAllTrainRoutes();
        TrainRouteDto? GetTrainRouteById(int id);
        TrainRouteDto AddTrainRoute(TrainRouteDto trainRoute);
        TrainRouteDto UpdateTrainRoute(int id, TrainRouteDto trainRoute);
        bool DeleteTrainRoute(int id);
        bool ValidData(TrainRouteDto trainRoute);
    }
}
