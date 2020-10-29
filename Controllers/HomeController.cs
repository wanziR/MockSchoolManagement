using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MockSchoolManagement.Models;
using MockSchoolManagement.ViewModels;

namespace MockSchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;//@_@
        private readonly IStudentRepository _studentRepository;
        //使用构造函数注入的方式注入IStudentRepository...
        public HomeController(IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger, IConfiguration configuration, IStudentRepository studentRepository)
        {
            _webHostEnvironment = webHostEnvironment;
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

        #region 列表 

        // [Route("")]
        public IActionResult Index()
        {
            var model = _studentRepository.GetAllStudent();
            return View(model);
        }

        #endregion

        #region 详情

        public ViewResult Details(int id)
        {
            //实例化homeDetialsViewModel并存储Student详细信息和PageTitle
            HomeDetailsViewModel homeDetialsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudentById(id),
                PageTitle = "学生详情"

            };
            //将ViewModel传递给View()方法
            return View(homeDetialsViewModel);
        }

        #endregion

        #region 添加
        // [HttpPost]
        // public IActionResult Create(Student student)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         Student newStudent = _studentRepository.Add(student);
        //         return RedirectToAction("Details", new {id = newStudent.Id});
        //     }
        //     return View();
        // }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    //必须将图片文件上传到wwwroot的images文件夹中
                    //而要获取wwwroot文件夹路径,我们需要注入ASP.NET Core提供的WebHostEnvironment
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "svstars");
                    //为了确保文件名是唯一的，我们在文件名后附一个新的GUID和一个下划线
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    //使用IFromFile接口提供的CopyTo方法将文件复制到wwwroot/images/文件夹
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Student newStudent = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    Major = model.Major,
                    //将文件保存名保存在Student对象的PhotoPath属性中
                    //它将保存到数据库Students表中
                    PhotoPath = uniqueFileName
                };
                _studentRepository.Insert(newStudent);
                return RedirectToAction("Details", new { id = newStudent.Id });
            }
            return View();
        }

        #endregion

        #region 编辑
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _studentRepository.GetStudentById(id);
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Major = student.Major,
                ExistingPhotoPath = student.PhotoPath
            };
            return View(studentEditViewModel);
        }

        #endregion


    }
}
