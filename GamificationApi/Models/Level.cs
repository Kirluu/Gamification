using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class Level
    {
        public int ExperienceReq { get; set; }
        public List<Attribute> AttributesReq { get; set; }
        public int JobPointReward { get; set; }
    }
}