using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Entities
{
    public class UserSurveys
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }  
        public int SurveysId { get; set; }
        public Survey Surveys { get; set; }
    }
}
