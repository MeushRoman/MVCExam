using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
