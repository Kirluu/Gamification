using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamificationApi.ModelRepositories;
using GamificationApi.Models;

namespace GamificationApi.GameLogic
{
    public class AchievementChecker : IAchievementChecker // TODO: Should have different methods for different kinds of achievements... This is too heavy
    {
        public List<Achievement> CheckAchievements(IStatApplier statApplier, IUnitOfWork unitOfWork, Player player)
        {
            // Retrieve all achievements, which the player did not already achieve
            var unachievedAchievements = unitOfWork.AchievementRepository.Get(ach => player.Achievements.TrueForAll(playerAch => playerAch.Id != ach.Id), null, "");

            var resList = new List<Achievement>();
            // Check for achieved achievements
            foreach (var unachievedAchievement in unachievedAchievements)
            {
                // Check for assignments completed of certain types
                if (!PassedAssignmentTypes(player, unachievedAchievement)) break; // Break if achievement failed here
                // Check for general stat requirements
                if (!PassedGeneralStats(player, unachievedAchievement)) break; // Break if achievement failed here
                // Check for Job Point purchase requirements
                if (!PassedJobPointPurchases(player, unachievedAchievement)) break; // Break if achievement failed here

                // Achievement gotten!
                player.Achievements.Add(unachievedAchievement);
                statApplier.ApplyJobPoints(player, unachievedAchievement.JobPointReward);
                statApplier.ApplyGeneralStats(player, unachievedAchievement.GeneralStatRewards);
                resList.Add(unachievedAchievement);
            }

            return resList; // Return all newly achieved achievements
        }

        private bool PassedAssignmentTypes(Player player, Achievement achievementToCheck)
        {
            foreach (var assTypeReq in achievementToCheck.AssignmentTypeReqs)
            {
                var assignmentsOfType = player.AssignmentsCompleted.FindAll(ass => ass.Type.NameOrCode == assTypeReq.AssignmentType.NameOrCode);
                if (assignmentsOfType.Count != assTypeReq.AmountReq) return false; // Not enough assignments of some type
            }
            return true;
        }

        private bool PassedGeneralStats(Player player, Achievement achievementToCheck)
        {
            foreach (var genStatReq in achievementToCheck.GeneralStatReqs)
            {
                var playerGeneralStatAmount =
                player.GeneralStats.FirstOrDefault(
                    u =>
                        u.StatEffect.AffectedStatBonus ==
                        genStatReq.StatEffect.AffectedStatBonus);
                if (playerGeneralStatAmount == null) throw new Exception("Database error, player has no such general stat entry");

                var res = genStatReq.CompareTo(playerGeneralStatAmount);
                if (res == 1)
                    return false; // General stat not high enough
            }
            return true;
        }

        private bool PassedJobPointPurchases(Player player, Achievement achievementToCheck)
        {
            foreach (var jpProductReq in achievementToCheck.JobPointProductReqs)
            {
                var fds = player.JobPointPurchases.FirstOrDefault(purch => purch.Product == jpProductReq);
                if (fds == null) return false; // Didn't purchase a required product
            }
            return true;
        }
    }
}