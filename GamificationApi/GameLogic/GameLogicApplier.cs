using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamificationApi.ModelRepositories;
using GamificationApi.Models;

namespace GamificationApi.GameLogic
{
    public class GameLogicApplier : IGameLogicApplier
    {
        private readonly IUnitOfWork _unitOfWork; // TODO: Shouldn't really have the whole unit of work - just the collection required in level up - or I dunno fds
        private readonly ILevelUpChecker _levelUpChecker;
        private readonly IStatApplier _statApplier;
        private readonly IAchievementChecker _achievementChecker;

        public GameLogicApplier(IUnitOfWork unitOfWork, IAchievementChecker achChecker, IStatApplier genStatApp, ILevelUpChecker levelChecker)
        {
            _unitOfWork = unitOfWork;
            _levelUpChecker = levelChecker;
            _achievementChecker = achChecker;
            _statApplier = genStatApp;
        }

        public List<Achievement> CompleteTask(Player player, AssignmentType assignmentTypeCompleted)
        {
            // Apply general stats - bonuses from here included henceforth
            _statApplier.ApplyGeneralStats(player, assignmentTypeCompleted.GeneralStatRewards);
            
            // Apply experience TODO: ExperienceApplier, JobPointApplier - Combine to StatApplier
            _statApplier.ApplyExperience(player, assignmentTypeCompleted.ExpReward);

            // Check level up
            _levelUpChecker.LevelUp(_unitOfWork, _statApplier, player, assignmentTypeCompleted); // Levels up, assigns rewards if achieved

            // Add assignment to assignment list
            player.AssignmentsCompleted.Add(new Assignment{Type = assignmentTypeCompleted});

            // Check for achievements TODO: (Return achievementGet ??? fds)
            var achievements = _achievementChecker.CheckAchievements(_statApplier, _unitOfWork, player);

            return achievements;
        }
    }
}