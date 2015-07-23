using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamificationApi.Dtos
{
    public class AssignmentTypeReqDto
    {
        public AssignmentTypeDto AssignmentType { get; set; }
        public int AmountReq { get; set; }
    }
}