using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_project.Core.Entities
{
    [Table("TrainRoute")]
    public class TrainRouteEntity
    {
        [Key]
        public int Id { get; set; }
        public int DriverId { get; set; }
        public EmployeeEntity Driver { get; set; }
        public int TrainId { get; set; }
        public TrainEntity Train { get; set; }
        public int StationId { get; set; }
        public StationEntity Station { get; set; }
        public DateTime FirstTrain { get; set; }
        public DateTime LastTrain { get; set; }
        public int SubstituteDriverId { get; set; }
        public EmployeeEntity SubstituteDriver { get; set; }
    }
}
