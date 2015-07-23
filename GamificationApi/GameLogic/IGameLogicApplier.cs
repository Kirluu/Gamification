using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamificationApi.Models;

namespace GamificationApi.GameLogic
{
    public interface IGameLogicApplier
    {
        List<Achievement> CompleteTask(Player player, AssignmentType assignmentTypeCompleted); // Does everything
    }
}
