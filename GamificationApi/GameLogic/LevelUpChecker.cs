using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamificationApi.ModelRepositories;
using GamificationApi.Models;
using Microsoft.Ajax.Utilities;

namespace GamificationApi.GameLogic
{
    public class LevelUpChecker : ILevelUpChecker
    {
        public void LevelUp(IUnitOfWork unitOfWork, IStatApplier statApplier, Player player, AssignmentType completedAssignment)
        {
            var currentLevel = player.Level;
            var nextLevel = unitOfWork.LevelRepository.Get((level => level.LevelNumber == currentLevel + 1), null, "").FirstOrDefault();
            // TODO: Make several games on one API ? Check if right game fds
            if (nextLevel == null) return; // Max level reached

            // Check if experience reached
            if (player.Experience < nextLevel.ExperienceReq) return; // Not enough experience

            // Check general stats
            foreach (var generalStatAmountReq in nextLevel.GeneralStatsReq)
            {
                var playerGeneralStatAmount =
                    player.GeneralStats.FirstOrDefault(
                        u =>
                            u.StatEffect.AffectedStatBonus ==
                            generalStatAmountReq.StatEffect.AffectedStatBonus);
                if (playerGeneralStatAmount == null) throw new Exception("Database error, player has no such general stat entry");
                
                var res = generalStatAmountReq.CompareTo(playerGeneralStatAmount);
                if (res == 1)
                    return; // No level up
            }

            // Level up reached! DING DING DING
            player.Level += 1;
            player.JobPoints += nextLevel.JobPointReward;
            statApplier.ApplyGeneralStats(player, nextLevel.GeneralStatRewards);
        }
    }
}