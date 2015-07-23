using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamificationApi.Models;

namespace GamificationApi.GameLogic
{
    public class StatApplier : IStatApplier
    {
        public void ApplyGeneralStats(Player player, List<GeneralStat> statsGained)
        {
            foreach (var currentGeneralStat in statsGained)
            {
                var playerGeneralStat = player.GeneralStats.FirstOrDefault(u => u.StatEffect.AffectedStatBonus == currentGeneralStat.StatEffect.AffectedStatBonus);
                if (playerGeneralStat != null)
                {
                    var generalStatIncrease =
                        player.GeneralStats.FirstOrDefault(
                            gs => gs.StatEffect.AffectedStatBonus == AffectedStatBonus.GeneralStats);
                    var allRewardsIncrease =
                        player.GeneralStats.FirstOrDefault(
                            gs => gs.StatEffect.AffectedStatBonus == AffectedStatBonus.AllRewards);
                    if (generalStatIncrease != null && allRewardsIncrease != null)
                    {
                        var generalStatBonus = generalStatIncrease.StatEffect.Multiplier *
                                               generalStatIncrease.Amount;
                        var allStatsBonus = allRewardsIncrease.StatEffect.Multiplier *
                                            allRewardsIncrease.Amount;
                        playerGeneralStat.Amount += (currentGeneralStat.Amount + generalStatBonus + allStatsBonus);
                    }
                    else
                    {
                        throw new Exception("General stat appliance failed - some player data was null");
                    }
                }
                else
                {
                    throw new Exception("General stat appliance failed - player and assignment combination invalid");
                }
            }
        }

        public void ApplyExperience(Player player, int expGained)
        {
            var experienceIncrease =
                        player.GeneralStats.FirstOrDefault(
                            gs => gs.StatEffect.AffectedStatBonus == AffectedStatBonus.Exp);
            var allRewardsIncrease =
                player.GeneralStats.FirstOrDefault(
                    gs => gs.StatEffect.AffectedStatBonus == AffectedStatBonus.AllRewards);
            if (experienceIncrease != null && allRewardsIncrease != null)
            {
                var experienceStatBonus = experienceIncrease.StatEffect.Multiplier*
                                          experienceIncrease.Amount;
                var allStatsBonus = allRewardsIncrease.StatEffect.Multiplier*
                                    allRewardsIncrease.Amount;
                player.Experience += (int) (experienceStatBonus + allStatsBonus);
            }
            else
            {
                throw new Exception("General stat appliance failed - some player data was null");
            }
        }

        public void ApplyJobPoints(Player player, int jobPointsGained)
        {
            var jobPointIncrease =
                        player.GeneralStats.FirstOrDefault(
                            gs => gs.StatEffect.AffectedStatBonus == AffectedStatBonus.JobPoints);
            var allRewardsIncrease =
                player.GeneralStats.FirstOrDefault(
                    gs => gs.StatEffect.AffectedStatBonus == AffectedStatBonus.AllRewards);
            if (jobPointIncrease != null && allRewardsIncrease != null)
            {
                var jobPointStatBonus = jobPointIncrease.StatEffect.Multiplier *
                                        jobPointIncrease.Amount;
                var allStatsBonus = allRewardsIncrease.StatEffect.Multiplier *
                                    allRewardsIncrease.Amount;
                player.JobPoints += (int)(jobPointStatBonus + allStatsBonus);
            }
            else
            {
                throw new Exception("General stat appliance failed - some player data was null");
            }
        }
    }
}