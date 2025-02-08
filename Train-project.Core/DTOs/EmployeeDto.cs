using Train_project.Core.Entities;

namespace Train_project.API.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public typeWork Type { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public DateTime EmployedFrom { get; set; }
    }
}
