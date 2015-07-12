using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class AssignmentTypeReq
    {
        public AssignmentType AssignmentType { get; set; }
        public int AmountReq { get; set; }
    }
}