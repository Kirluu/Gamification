using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public string Title { get; set; }
        public int JobPoints { get; set; }
        public List<GeneralStat> GeneralStats { get; set; }
        public List<Assignment> AssignmentsCompleted { get; set; }
        public List<Achievement> Achievements { get; set; }
        public List<JobPointPurchase> JobPointPurchases { get; set; }
    }
}