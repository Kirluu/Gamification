using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GamificationApi.Models
{
    public class GameContext : DbContext, IGameContext
    {
        public GameContext()
            : base("name=DefaultConnection")
        {

        }

        // DbSets
        public virtual IDbSet<Player> Players { get; set; }
        public virtual IDbSet<GeneralStat> GeneralStats { get; set; }
        public virtual IDbSet<Level> Levels { get; set; }
        public virtual IDbSet<AssignmentType> AssignmentTypes { get; set; }
        public virtual IDbSet<JobPointPurchase> JobPointPurchases { get; set; }

        // Methods
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
    
    // Interface
    public interface IGameContext
    {
        // DbSets
        IDbSet<Player> Players { get; set; }
        IDbSet<GeneralStat> GeneralStats { get; set; }
        IDbSet<Level> Levels { get; set; }

        // Other
        Task<int> SaveChangesAsync();
        void SetModified(object entity);
    }
}