using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL.Impl
{
    public class HomeDALImpl : IHomeDAL
    {    

        public IList<Course> SelectCourseForHome(int status, int size)
        {

            String sql = "select course_id, course_name, course_credit, course_opentime, course_type," +
                "status, course_photo from Course where status = @status";
            SqlParameter[] pars = {
                new SqlParameter("@status",status)
            };

            return DoSelect(sql,pars,size);
        }

        public IList<Course> SelectCourseByType(CourseType courseType, int size)
        {
            String sql = "select course_id, course_name, course_credit, course_opentime, course_type," +
                "status, course_photo from Course where course_type like @courseType";
            SqlParameter[] pars = {
                new SqlParameter("@courseType", CourseTypeUtils.GetInfo(courseType))
            };
            return DoSelect(sql, pars, size);
        }

        /// <summary>
        /// 提取出公共查询代码
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">查询参数</param>
        /// <param name="size">每页的大小</param>
        /// <returns></returns>
        public IList<Course> DoSelect(string sql, SqlParameter[] pars, int size) {

            DataTable dataTable = DBUtils.getDBUtils().getRecordsWithPage(sql, pars, size, 1);
            IList<Course> courseList = new List<Course>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {

                    Course course = new Course
                    {
                        course_id = dataRow["course_id"].ToString(),
                        course_name = dataRow["course_name"].ToString(),
                        course_credit = Convert.ToDecimal(dataRow["course_credit"].ToString()),
                        course_opentime = dataRow["course_opentime"].ToString(),
                        course_type = dataRow["course_type"].ToString(),
                        status = Convert.ToInt32(dataRow["status"].ToString()),
                        course_photo = dataRow["course_photo"].ToString()

                    };

                    courseList.Add(course);

                }
            }
            return courseList;
        }

    }
}
