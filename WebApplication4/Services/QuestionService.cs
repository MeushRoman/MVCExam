using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Entities;
using WebApplication4.Persistence;

namespace WebApplication4.Services
{
    public class QuestionService
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Question GetQuestionById(int id)
        {
            return _dbContext.Questions.FirstOrDefault(w => w.Id == id);                       
        }        

        public List<Question> GetQuestionsBySurveyId(int id)
        {
            var res = _dbContext.SurveyQuestions.Include(i => i.Question).Where(q => q.SurveyId == id).ToList();

            List<Question> questions = new List<Question>();
            foreach (var item in res)
            {
                questions.Add(item.Question);
            }

            return questions;
        }

        public Answer GetAnswerByQuestionId(int id)
        {
            return _dbContext.Questions.Include(i=>i.Answer).FirstOrDefault(f => f.Id == id).Answer;           
        }

        public bool RemoveQuestionById(int id)
        {
            var q = _dbContext.Questions.FirstOrDefault(f => f.Id == id);
            if (q is null) return false;

            _dbContext.Questions.Remove(q);
            _dbContext.SaveChanges();
            return true;
        }

        public bool AddQuestion(string qText, string qAnswer)
        {
            _dbContext.Questions.Add(new Question { QuestionText = qText, Answer = new Answer { AnswerText = qText } });
            _dbContext.SaveChanges();

            return true;
        }
    }
}
