using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public List<UserSurveys> UserSurveys { get;set; }
    }
}
