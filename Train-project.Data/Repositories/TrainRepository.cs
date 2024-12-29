using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;

namespace Train_project.Data.Repositories
{
    public class TrainRepository :Repository<TrainEntity>, ITrainRepository
    {
        public TrainRepository(DataContext context) : base(context) { }
       
        public TrainEntity UpdateTrain(int id, TrainEntity updatedTrain)
        {
            TrainEntity existingTrain = GetById(id);
            if (updatedTrain.TrainLine != 0)
                existingTrain.TrainLine = updatedTrain.TrainLine;

            if (updatedTrain.NumberOfCars > 0)
                existingTrain.NumberOfCars = updatedTrain.NumberOfCars;

            if (existingTrain.TrainStatus != default)
                existingTrain.TrainStatus = updatedTrain.TrainStatus;
            

            if (!string.IsNullOrWhiteSpace(updatedTrain.RegularRoute))
                existingTrain.RegularRoute = updatedTrain.RegularRoute;

            if (!string.IsNullOrWhiteSpace(updatedTrain.Model))
                existingTrain.Model = updatedTrain.Model;

            if (updatedTrain.ServiceDate != default)
                existingTrain.ServiceDate = updatedTrain.ServiceDate;
            return existingTrain;
        }
        

    }
}
