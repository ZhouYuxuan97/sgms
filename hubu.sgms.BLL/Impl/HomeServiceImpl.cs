using hubu.sgms.Model;
using hubu.sgms.DAL;
using System.Collections.Generic;
using hubu.sgms.DAL.Impl;

namespace hubu.sgms.BLL.Impl
{
    public class HomeServiceImpl : IHomeService
    {
        IHomeDAL homeDAL = new HomeDALImpl();

        public IList<Course> SelectNewCourse(int status, int size)
        {
            return homeDAL.SelectCourseForHome(status, size);
        }

        public IList<Course> SelectCourseByType(CourseType courseType, int size)
        {
            return homeDAL.SelectCourseByType(courseType,size);
        }
    }
}
