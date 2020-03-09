using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Persistence;

namespace WebApplication4.Models
{
    public class QuestionModel
    {    
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
