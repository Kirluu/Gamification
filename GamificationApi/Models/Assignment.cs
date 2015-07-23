using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public AssignmentType Type { get; set; } // Contains name or code, exp and general stat rewards
    }
}