using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;

namespace Train_project.Data.Repositories
{
    public class TrainRepository : Repository<TrainEntity>, ITrainRepository
    {
        public TrainRepository(DataContext context) : base(context) { }

        public TrainEntity UpdateTrain(int id, TrainEntity updatedTrain)
        {
            TrainEntity existingTrain = GetById(id);
            existingTrain.Line = updatedTrain.Line;
            existingTrain.NumberOfCars = updatedTrain.NumberOfCars;
            existingTrain.Status = updatedTrain.Status;
            existingTrain.RegularRoute = updatedTrain.RegularRoute;
            existingTrain.Model = updatedTrain.Model;
            existingTrain.ServiceDate = updatedTrain.ServiceDate;
            return existingTrain;
        }


    }
}
