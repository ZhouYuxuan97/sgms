using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface IHomeDAL
    {
        /// <summary>
        /// 主页获取课程信息
        /// </summary>
        /// <param name="status">课程状态</param>
        /// <param name="size">课程状态</param>
        /// <returns></returns>
        IList<Course> SelectCourseForHome(int status, int size);

        /// <summary>
        /// 根据课程类型查询课程
        /// </summary>
        /// <param name="courseType">课程类型</param>
        /// <param name="size">每页数据的条数</param>
        /// <returns></returns>
        IList<Course> SelectCourseByType(CourseType courseType,int size);
    }
}
