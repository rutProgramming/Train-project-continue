using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.API.Models;
using Train_project.Core.Entities;

namespace Train_project.Core.IServices
{
    public interface ITrainService
    {
        IEnumerable<TrainDto> GetAllTrains();
        TrainDto? GetTrainById(int id);
        TrainDto AddTrain(TrainDto train);
        TrainDto UpdateTrain(int id, TrainDto train);
        bool DeleteTrain(int id);
    }
}
