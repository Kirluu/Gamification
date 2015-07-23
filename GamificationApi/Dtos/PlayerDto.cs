using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Dtos
{
    public class PlayerDto
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public string Title { get; set; }
        public int JobPoints { get; set; }
        public List<GeneralStatDto> GeneralStats { get; set; }
        public List<AssignmentDto> AssignmentsCompleted { get; set; }
        public List<AchievementDto> Achievements { get; set; }
        public List<JobPointPurchaseDto> JobPointPurchases { get; set; }
    }
}