using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }

        // Information
        public string Name { get; set; }
        public string Description { get; set; }

        // Requirements
        public List<AssignmentTypeReq> AssignmentTypeReqs { get; set; }
        public List<GeneralStat> GeneralStatReqs { get; set; }
        public List<JobPointProduct> JobPointProductReqs { get; set; }

        // Rewards
        public int JobPointReward { get; set; }
        public List<GeneralStat> GeneralStatRewards { get; set; }
    }
}