using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_project.Core.Entities
{
    public enum  StationType { UrbanStation=1, IntercityStation=2 }
    [Table("Station")]
    public class StationEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public PointGPS LocationGPSCoordinates { get; set; }
        public StationType Type { get; set; }
        public int NumberOfPlatforms { get; set; }

    }
    public class PointGPS
    {
        public double X { get; set; }
        public double Y{ get; set; }
    }

}
