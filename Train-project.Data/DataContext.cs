using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Train_project.Core.Entities;

namespace Train_project.Data
{
    public class DataContext: DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<PublicInquiryEntity> PublicInquiries { get; set; }
        public DbSet<StationEntity> Stations { get; set; }
        public DbSet<TrainEntity> Trains { get; set; }
        public DbSet<TrainRouteEntity> TrainRoutes { get; set; }

        
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }

           public DataContext() { }

            
        

    }

}
