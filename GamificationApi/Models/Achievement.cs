using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Achievement
    {
        // Requirements
        public List<AssignmentTypeReq> AssignmentTypeReqs { get; set; }
        public List<GeneralStatAmount> GeneralStatReqs { get; set; }
        public List<JobPointProduct> JobPointProductReqs { get; set; }

        // Rewards
        public int JobPointReward { get; set; }
        public List<GeneralStatAmount> GeneralStatRewards { get; set; }
    }
}