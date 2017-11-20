using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    public interface IArrange_CourseService
    {
        int AddArrange_Course(string course_id, string teacher_id, string class_id, string classroom_id, string time_id);

        IList<ModelObject> SelArrangeInfoByDetail(string class_id, string opentime);

        IList<ModelObject> SelArrangeInfoById(string id);

        IList<ModelObject> SelArrangeInfoByTeacherCourseId(string id);

        int DelArrange_CourseById(string id);
    }
}
