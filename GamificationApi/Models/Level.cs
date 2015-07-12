using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Level
    {
        // Requirements
        public int ExperienceReq { get; set; }
        public List<GeneralStatAmount> GeneralStatsReq { get; set; }
        public List<Achievement> AchievementsReq { get; set; } // Maybe? (Leveling paths? - tougher to make generic)

        // Rewards
        public int JobPointReward { get; set; }
    }
}