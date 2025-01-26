using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;

namespace Train_project.Core.IServices
{
    public interface ITrainService
    {
        IEnumerable<TrainEntity> GetAllTrains();
        TrainEntity? GetTrainById(int id);
        TrainEntity AddTrain(TrainEntity train);
        TrainEntity UpdateTrain(int id, TrainEntity train);
        bool DeleteTrain(int id);
    }
}
