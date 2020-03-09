using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        //public string YserAnswer { get; set; }
        //public int AnswerId { get; set; }  
        public Answer Answer { get; set; }
        public List<SurveyQuestion> SurveyQuestion { get; set; }
    }
}
