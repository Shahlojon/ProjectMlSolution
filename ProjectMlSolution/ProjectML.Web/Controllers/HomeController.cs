using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ProjectMl.Core.Services;
using ProjectML.Core.Enum;
using ProjectML.Core.Filter;
using ProjectML.Core.Models;
using ProjectML.Infrastructure.Context;
using ProjectML.Infrastructure.Repository;
using ProjectML.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectML.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly Service _service;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
            _service = new Service();
        }

        public IActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "Student")]
        public IActionResult Essay()
        {
            var student = _context.Users.Where(x => x.Id == 1).FirstOrDefault();
            //ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            if (User.Identity.Name != null)
                student = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            _context.Entry(student).Reference(s => s.Group).Load();
            var exam = _context.Exams.Where(x => x.GroupId == student.Group.Id).OrderByDescending(x => x.Id).FirstOrDefault();
            _context.Entry(exam).Reference(s => s.Subject).Load();
            ViewBag.Subject = exam.Subject;
            ViewBag.Lesson = _context.Lessons.Where(x => x.SubjectId == exam.Subject.Id).ToList();
            ViewData["AlgorithmId"] = new SelectList(_context.Algorithms, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> Essay(Topic topic, int algorithmId)
        {

            if (ModelState.IsValid)
            {
                var algorithmKey = _context.Algorithms.Where(x => x.Id == algorithmId).FirstOrDefault();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                topic.ExamId = 1;
                int studentId = 1;
                if (User.Identity.Name != null)
                {
                    var student = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                    studentId = student.Id;
                }
                topic.StudentId = studentId;
                topic.LessonId = topic.LessonId;
                topic.TimeStamp = Convert.ToDateTime(date);
                var lessonName = _context.Lessons.Where(x => x.Id == topic.LessonId).FirstOrDefault();
                topic.Lesson = lessonName;
                var Description = Regex.Replace(topic.Description, "<[^>]+>", string.Empty);
                Description = Description.Trim('"');
                Filters filter = new()
                {
                    Topic = topic.Lesson.Name,
                    Description = Description,
                    Algorithm = algorithmKey.Key
                };
                var Result = _service.GetPredict(filter);
                while (Result.Status.ToString() == "WaitingForActivation" || Result.Result == null)
                {
                    Thread.Sleep(1000);
                }
                _context.Topics.Add(topic);
                await _context.SaveChangesAsync();
                if (Result.Result != null)
                {
                    var grade = 0;
                    if (Result.Result.Percent > 90)
                    {
                        grade = 10;
                    }
                    else if (Result.Result.Percent < 90 && Result.Result.Percent > 70)
                    {
                        grade = 9;
                    }
                    else if (Result.Result.Percent < 70 && Result.Result.Percent > 60)
                    {
                        grade = 8;
                    }
                    else if (Result.Result.Percent < 60 && Result.Result.Percent > 50)
                    {
                        grade = 7;
                    }
                    else if (Result.Result.Percent < 50 && Result.Result.Percent > 40)
                    {
                        grade = 5;
                    }
                    else if (Result.Result.Percent < 40 && Result.Result.Percent > 30)
                    {
                        grade = 4;
                    }
                    //else if (Result.Result.Percent < 30 && Result.Result.Percent > 10)
                    //{
                    //    grade = 3;
                    //}
                    else
                    {
                        grade = 0;
                    }
                    TopicAlgorithm topicAlgorithm = new TopicAlgorithm()
                    {
                        AlgorithmId = algorithmId,
                        TopicId = topic.Id,
                        Percent = Result.Result.Percent,
                        Grade = grade,
                        NewTheme = Result.Result.NewTheme
                    };
                    ExamResult result = new ExamResult() { Grade = grade, TopicId = topic.Id };
                    _context.TopicAlgorithms.Add(topicAlgorithm);
                    _context.ExamResults.Add(result);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ResultView));
            }
            return View(topic);
        }
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> ResultView()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            var student = _context.Users.Where(x => x.Id == 1).FirstOrDefault();
            if (User.Identity.Name != null)
                student = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            // student.Group =await _context.Groups.FindAsync(student.GroupId);
            await _context.Entry(student).Reference(s => s.Group).LoadAsync();

            var prof = _context.Professions.Find(student.Group.ProfessionId);
            //а не через костыли потом
            var cource = _context.Cources.Find(student.Group.CourceId);
            ViewBag.Group = cource.Key + "_" + prof.Key + "." + student.Group.Key;
            var topic = _context.Topics.Where(x => x.StudentId == student.Id && x.TimeStamp >= Convert.ToDateTime(date)).OrderByDescending(x => x.Id).FirstOrDefault();
            topic.Lesson = _context.Lessons.Find(topic.LessonId);
            topic.Lesson.Subject = _context.Subjects.Find(topic.Lesson.SubjectId);
            var algorithmTop = _context.TopicAlgorithms.Where(x => x.TopicId == topic.Id).FirstOrDefault();
            var algorithm = _context.Algorithms.Where(x => x.Id == algorithmTop.AlgorithmId).FirstOrDefault();
            algorithmTop.Algorithm = algorithm;
            //ViewBag.Student = student;
            //ViewBag.Topic = topic;
            ViewBag.Algorithm = algorithmTop;
            return View();
        }
        //[Authorize]
        //public IActionResult Index()
        //{
        //    return Content(User.Identity.Name);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
