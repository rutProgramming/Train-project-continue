using System.ComponentModel.DataAnnotations;

namespace Train_project.API.Models
{
    public class TrainRoutePostModal
    {
        public int DriverId { get; set; }
        public int TrainId { get; set; }
        public int StationId { get; set; }
        public DateTime FirstTrain { get; set; }
        public DateTime LastTrain { get; set; }
        public int SubstituteDriverId { get; set; }
    }
}
