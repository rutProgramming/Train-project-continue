namespace Train_project.API.Models
{
    public class PublicInquiryDto
    {
        public int DriverId { get; set; }
        public DateTime DateAndTime { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public int TreatedBy { get; set; }
        public string ComplainantsName { get; set; }
        public string ComplainantsPhone { get; set; }
    }
}
