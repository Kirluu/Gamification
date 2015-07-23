using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public enum AffectedStatBonus { Exp, JobPoints, GeneralStats, AllRewards }
    
    public class StatEffect
    {
        public AffectedStatBonus AffectedStatBonus { get; set; }
        public double Multiplier { get; set; } // TODO: Pr. stat? Algorithmic? %?
    }
}