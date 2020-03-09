using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Entities
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string YserAnswer { get; set; }
    }
}
