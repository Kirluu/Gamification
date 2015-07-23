using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Dtos
{
    public class AssignmentDto
    {
        public string TypeOrName { get; set; }
        public int Amount { get; set; } // Amount 'required' (achievement) or 'completed' (by player)
        public int ExpReward { get; set; }
        public List<GeneralStatDto> GeneralStatRewards { get; set; }
    }
}