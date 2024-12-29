using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.Core.Entities;
using Train_project.Core.IRepositories;

namespace Train_project.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IRepository<EmployeeEntity> Employees { get; }

        public IRepository<PublicInquiryEntity> PublicInquiries { get; }

        public IRepository<StationEntity> Stations { get; }

        public IRepository<TrainEntity> Trains { get; }

        public IRepository<TrainRouteEntity> TrainsRoute { get; }

        public RepositoryManager(DataContext context, IRepository<EmployeeEntity> employees, IRepository<PublicInquiryEntity> publicInquiries, IRepository<StationEntity> stations, IRepository<TrainEntity> trains, IRepository<TrainRouteEntity> trainsRoute)
        {
            _context = context;
            Employees = employees;
            PublicInquiries = publicInquiries;
            Stations = stations;
            Trains = trains;
            TrainsRoute = trainsRoute;
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
