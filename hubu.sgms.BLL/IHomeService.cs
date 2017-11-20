using hubu.sgms.DAL;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    public interface IHomeService
    {
        /// <summary>
        /// 获取课程信息
        /// </summary>
        /// <param name="status"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Course> SelectNewCourse(int status, int size);

        /// <summary>
        /// 根据课程类型查询课程
        /// </summary>
        /// <param name="courseType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Course> SelectCourseByType(CourseType courseType, int size);
    }
}
