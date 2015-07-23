using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamificationApi.ModelRepositories;
using GamificationApi.Models;

namespace GamificationApi.GameLogic
{
    public interface IAchievementChecker
    {
        List<Achievement> CheckAchievements(IStatApplier statApplier, IUnitOfWork unitOfWork, Player player);
    }
}
