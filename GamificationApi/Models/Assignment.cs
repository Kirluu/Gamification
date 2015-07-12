using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Assignment
    {
        public AssignmentType Type { get; set; }
        public int ExpReward { get; set; }
        public List<GeneralStatAmount> GeneralStatRewards { get; set; }
    }
}