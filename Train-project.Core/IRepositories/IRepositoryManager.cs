using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;

namespace Train_project.Core.IRepositories
{
    public interface IRepositoryManager
    {
        IRepository<EmployeeEntity> Employees {get;}
        IRepository<PublicInquiryEntity> PublicInquiries {get;}
        IRepository<StationEntity> Stations {get;}
        IRepository<TrainEntity> Trains {get;}
        IRepository<TrainRouteEntity> TrainsRoute {get;}

        void save();
    }
}
