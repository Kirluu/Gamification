using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class JobPointPurchase
    {
        [Key]
        public int Id { get; set; }
        public JobPointProduct Product { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool Claimed { get; set; }
    }
}