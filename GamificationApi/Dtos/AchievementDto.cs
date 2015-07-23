using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Dtos
{
    public class AchievementDto
    {
        public List<AssignmentTypeReqDto> AssignmentTypeReqs { get; set; } // Contains type info and amount
        public List<GeneralStatDto> GeneralStatReqs { get; set; }
        public List<JobPointProductDto> JobPointProductReqs { get; set; }

        // Rewards
        public int JobPointReward { get; set; }
        public List<GeneralStatDto> GeneralStatRewards { get; set; }
    }
}