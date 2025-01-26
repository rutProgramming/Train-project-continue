using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_project.Core.Entities
{
   public enum typeWork { driver=0,cleaner=1,workerOffice=2}
    [Table("Employee")]
    public class EmployeeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Tz { get; set; }
        public string Name { get; set; }
        public string? Address{ get; set; }
        public typeWork Type { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public DateTime EmployedFrom { get; set; }
        
    }
}
