using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class AssignmentTypeReq
    {
        [Key]
        public int Id { get; set; }
        public AssignmentType AssignmentType { get; set; }
        public int AmountReq { get; set; }
    }
}