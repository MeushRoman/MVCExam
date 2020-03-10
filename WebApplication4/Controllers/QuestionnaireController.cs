using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebApplication4.Entities;
using WebApplication4.Models;
using WebApplication4.Persistence;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private QuestionService _qService;
        public QuestionnaireController(ApplicationDbContext dbContext, QuestionService questionService)
        {
            _dbContext = dbContext;
            _qService = questionService;

            if (!dbContext.Questions.Any())
                InitialData.Initial(dbContext);

        }

        public IActionResult Index()
        {
            List<SurveyModel> surveys = new List<SurveyModel>();

            var s = _dbContext.Surveys.ToList();

            foreach (var item in s)
            {
                var count = _dbContext.SurveyQuestions.Where(w => w.SurveyId == item.Id).ToList().Count;

                surveys.Add(new SurveyModel { Id = item.Id, Name = item.Name, CountQuestion = count });
            }

            return View(surveys);
        }

        [HttpPost]
        public IActionResult StartTest(int id, string firstName, string lastName)
        {
            var user = new User { FirstName = firstName, LastName = lastName };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            _dbContext.UserSurveys.Add(new UserSurveys() { StartDate = DateTime.Now, User = user, SurveysId = id });
            _dbContext.SaveChanges();

            var q = _qService.GetQuestionsBySurveyId(id);

            ViewBag.SurveyId = id;

            List<QuestionModel> questionModels = new List<QuestionModel>();

            foreach (var item in q)
            {
                questionModels.Add(new QuestionModel() { Question = item.QuestionText, QuestionId = item.Id });
            }

            return View(questionModels.OrderBy(o => o.QuestionId));
        }

        [HttpGet]
        public ActionResult Result(string request, int surveyId)
        {
            var models = JsonSerializer.Deserialize<List<RAnswer>>(request);

            var m = _dbContext.SurveyQuestions.Include(i=>i.Question).Include(i=>i.Question.Answer).Where(w => w.SurveyId == surveyId).ToList();

            int ccAnswers = 0;

            foreach (var item in m)
            {
                item.YserAnswer = models.FirstOrDefault(f => Int32.Parse(f.qId) == item.QuestionId).qAnswer;
                if (item.Question.Answer.AnswerText == item.YserAnswer) ++ccAnswers;
            }
            _dbContext.SaveChanges();

            var tName = _dbContext.Surveys.FirstOrDefault(f => f.Id == surveyId).Name;

            var cQuestions = m.Count;

            ResultModel rm = new ResultModel() { TestName = tName, CountCorrectAnswers = ccAnswers, CountQuestions = cQuestions };

            return View(rm);
        }
    }
}