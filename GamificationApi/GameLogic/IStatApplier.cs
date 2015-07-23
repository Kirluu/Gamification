using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamificationApi.Models;

namespace GamificationApi.GameLogic
{
    public interface IStatApplier
    {
        void ApplyGeneralStats(Player player, List<GeneralStat> statsGained);
        void ApplyExperience(Player player, int expGained);
        void ApplyJobPoints(Player player, int jobPointsGained);
    }
}
