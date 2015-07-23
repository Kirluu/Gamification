using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Dtos
{
    public class GeneralStatDto
    {
        public string Name { get; set; }
        public string StatEffect { get; set; } // Description of the stat's effect
        public double Amount { get; set; }
    }
}