using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class JobPointPurchase
    {
        public JobPointProduct Product { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool Claimed { get; set; }
    }
}