using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MockSchoolManagement.Models;
using MockSchoolManagement.ViewModels;

namespace MockSchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;//@_@
        private readonly IStudentRepository _studentRepository;
        //使用构造函数注入的方式注入IStudentRepository...
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IStudentRepository studentRepository)
        {
            _logger = logger;
            _configuration = configuration;//@_@
            _studentRepository = studentRepository;


        }


        //public IActionResult Index()
        //{
        //    return Content(_configuration["MyKey"]);//@_@.

        //}
        //public string Index()
        //{
        //    //返回学生的名字
        //    return _studentRepository.GetStudent(1).Name;

        //}
       // [Route("")]
        public IActionResult Index()
        {
            var model = _studentRepository.GetAllStudent();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            //实例化homeDetialsViewModel并存储Student详细信息和PageTitle
            HomeDetailsViewModel homeDetialsViewModel = new HomeDetailsViewModel() {
                Student = _studentRepository.GetStudentById(id),
                PageTitle = "学生详情"
            
            };
           //将ViewModel传递给View()方法
            return View(homeDetialsViewModel);
        }

        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

            }
            return View();
        }
    }
}
