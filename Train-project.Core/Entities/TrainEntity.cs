using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_project.Core.Entities
{
    [Table("Train")]
    public class TrainEntity
    {
        [Key]
        public int Id { get; set; }
        public int Line{ get; set; }
        public int NumberOfCars { get; set; }
        public bool? Status{ get; set; }
        public string RegularRoute{ get; set; }
        public string? Model { get; set; }
        public DateTime ServiceDate { get; set; }

    }
}
