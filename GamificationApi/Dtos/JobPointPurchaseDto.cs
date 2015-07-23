using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Dtos
{
    public class JobPointPurchaseDto
    {
        public JobPointProductDto Product { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool Claimed { get; set; }
    }
}