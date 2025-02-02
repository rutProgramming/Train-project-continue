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
        IEnumerable<TrainRoutDto> GetAllTrainRoutes();
        TrainRoutDto? GetTrainRouteById(int id);
        TrainRouteEntity AddTrainRoute(TrainRouteEntity trainRoute);
        TrainRouteEntity UpdateTrainRoute(int id, TrainRouteEntity trainRoute);
        bool DeleteTrainRoute(int id);
        bool ValidData(TrainRouteEntity trainRoute);
    }
}
