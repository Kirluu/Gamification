using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Level
    {
        [Key]
        public int Id { get; set; }
        // Requirements
        public int LevelNumber { get; set; }
        public string Title { get; set; }
        public int ExperienceReq { get; set; }
        public List<GeneralStat> GeneralStatsReq { get; set; }
        public List<Achievement> AchievementsReq { get; set; } // Maybe? (Leveling paths? - tougher to make generic)

        // Rewards
        public int JobPointReward { get; set; }
        public List<GeneralStat> GeneralStatRewards { get; set; }
    }
}