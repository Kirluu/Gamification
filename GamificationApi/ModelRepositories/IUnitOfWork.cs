using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamificationApi.Models;

namespace GamificationApi.ModelRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Player> PlayerRepository { get; }
        IGenericRepository<Assignment> AssignmentRepository { get; }
        IGenericRepository<AssignmentType> AssignmentTypeRepository { get; }
        IGenericRepository<Achievement> AchievementRepository { get; }
        IGenericRepository<Level> LevelRepository { get; }
        IGenericRepository<JobPointPurchase> JobPointPurchaseRepository { get; }
        void Save();
    }
}
