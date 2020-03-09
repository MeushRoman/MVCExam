using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Entities;
using WebApplication4.Persistence;

namespace WebApplication4
{
    public static class InitialData
    {
       
        public static void Initial(ApplicationDbContext dbContext)
        {
            dbContext.Questions.AddRange(
               new Question { QuestionText = "Сколько материков на Земле?", Answer = new Answer { AnswerText = "6" } },
               new Question { QuestionText = "Сколько планет в солнечной системе", Answer = new Answer { AnswerText = "8" } },
               new Question { QuestionText = "Спутник земли", Answer = new Answer { AnswerText = "Луна" } },
               new Question { QuestionText = "День защиты детей в июне", Answer = new Answer { AnswerText = "1" } },
               new Question { QuestionText = "Фамилия первого космонавта", Answer = new Answer { AnswerText = "Гагарин" } }
               );

            dbContext.Surveys.Add(
                new Survey { Name = "Test 1" });

            dbContext.SaveChanges();

            dbContext.SurveyQuestions.AddRange(
                new SurveyQuestion { QuestionId = 1, SurveyId = 1 },
                new SurveyQuestion { QuestionId = 2, SurveyId = 1 },
                new SurveyQuestion { QuestionId = 3, SurveyId = 1 },
                new SurveyQuestion { QuestionId = 4, SurveyId = 1 },
                new SurveyQuestion { QuestionId = 5, SurveyId = 1 }
            );

            dbContext.SaveChanges();
        }
    }
}
