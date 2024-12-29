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
        public int EmployeeCode { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string? EmployeeAddress{ get; set; }
        public typeWork EmployeeType { get; set; }
        public string EmployeePhone { get; set; }
        public int Salary { get; set; }
        public DateTime EmployedFrom { get; set; }
        
    }
}
