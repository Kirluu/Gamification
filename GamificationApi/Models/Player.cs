using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int JobPoints { get; set; }
        public List<GeneralStatAmount> GeneralStats { get; set; }
        public List<Assignment> AssignmentsCompleted { get; set; }
        public List<Achievement> Achievements { get; set; }
        public List<JobPointPurchase> JobPointPurchases { get; set; }
    }
}