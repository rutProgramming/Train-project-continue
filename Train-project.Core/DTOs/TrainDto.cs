namespace Train_project.API.Models
{
    public class TrainDto
    {
        public int Id { get; set; }
        public int Line { get; set; }
        public int NumberOfCars { get; set; }
        public bool? Status { get; set; }
        public string RegularRoute { get; set; }
        public string? Model { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
