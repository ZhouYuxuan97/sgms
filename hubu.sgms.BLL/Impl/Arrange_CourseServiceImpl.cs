using hubu.sgms.DAL;
using hubu.sgms.DAL.Impl;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL.Impl
{
   public  class Arrange_CourseServiceImpl:IArrange_CourseService
    {
        IArrange_CourseDAL Arrange_CourseDAL = new Arrange_CourseDALImpl();
        public int AddArrange_Course(string course_id, string teacher_id, string class_id, string classroom_id, string time_id)
        {
            return Arrange_CourseDAL.AddArrange_Course(course_id,  teacher_id, class_id,  classroom_id,  time_id);
        }

        public IList<ModelObject> SelArrangeInfoByDetail(string class_id, string opentime)
        {
            return Arrange_CourseDAL.SelArrangeInfoByDetail(class_id, opentime);
        }

        public IList<ModelObject> SelArrangeInfoById(string id)
        {
            return Arrange_CourseDAL.SelArrangeInfoById(id);
        }

        public IList<ModelObject> SelArrangeInfoByTeacherCourseId(string id)
        {
            return Arrange_CourseDAL.SelArrangeInfoByTeacherCourseId(id);
        }

        public int DelArrange_CourseById(string id)
        {
            return Arrange_CourseDAL.DelArrange_CourseById(id);
        }
    }
}
