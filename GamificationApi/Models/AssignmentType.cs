using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class AssignmentType
    {
        [Key]
        public int Id { get; set; }
        public string NameOrCode { get; set; }
        public int ExpReward { get; set; }
        public List<GeneralStat> GeneralStatRewards { get; set; }
    }
}