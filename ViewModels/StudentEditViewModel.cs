using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.ViewModels
{
    public class StudentEditViewModel:StudentCreateViewModel
    {
        public int Id { get; set; }
        //已存在数据库中的图片路径
        public string ExistingPhotoPath { get; set; }
    }
}
