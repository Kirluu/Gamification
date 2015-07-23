using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Dtos
{
    public class AssignmentTypeDto
    {
        public string NameOrCode { get; set; }
        public int ExpReward { get; set; }
        public List<GeneralStatDto> GeneralStatRewards { get; set; }
    }
}