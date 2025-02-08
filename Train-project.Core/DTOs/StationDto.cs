using Train_project.Core.Entities;

namespace Train_project.API.Models
{
    public class StationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public PointGPS LocationGPSCoordinates { get; set; }
        public StationType Type { get; set; }
        public int NumberOfPlatforms { get; set; }
    }
}
