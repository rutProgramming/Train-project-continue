﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_project.Core.Entities
{
    [Table("PublicInquiry")]
    public class PublicInquiryEntity
    {

        [Key]
        public int InquiryId { get; set; }

        public int DriverId { get; set; }
        public EmployeeEntity Driver { get; set; }
        public DateTime DateAndTime { get; set; }
        public string? DescriptionInquiry { get; set; }
        public bool? StatusInquiry { get; set; }

        public int TreatedBy { get; set; }
        public EmployeeEntity Worker { get; set; }

        public string ComplainantsName { get; set; }
        public string ComplainantsPhone { get; set; }

    }
}