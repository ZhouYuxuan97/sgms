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
    public class Arrange_CourseDALImpl : IArrange_CourseDAL
    {
        public int AddArrange_Course(string course_id, string teacher_id, string class_id, string classroom_id, string time_id)
        {
            /*           //多级连接查询填写teacher_course表
                      string sql1 = "insert into teacher_course ( teacher_course_id,course_id,course_name , teacher_id, teacher_name,class_id,major,major_id ,department,college_id,course_credit)values(@teacher_course_id, @course_id, (select course_name from course where course_id = @course_id), @teacher_id,(select teacher_name from teacher where teacher_id = @teacher_id),@class_id,(select major_name from major where major_id in (select major_id from class where class_id = @class_id)),(select major_id from class where class_id = @class_id),(select name from college where college_id in (select college_id from major where major_id in(select major_id from class where class_id = @class_id))),(select college_id from major where major_id in(select major_id from class where class_id = @class_id)),(select course_credit from course where course_id = @course_id))";



                      SqlParameter[] pars1 = {
                          new SqlParameter("@teacher_course_id",course_id+teacher_id+class_id),
                          new SqlParameter("@classroom_id",classroom_id),
                          new SqlParameter("@teacher_id",teacher_id),
                          new SqlParameter("@class_id",class_id)
                      };*/

            string sql2 = "insert into Arrange_course values(@arrange_id,@teacher_course_id,@classroom_id,@time_id,'1')";

            SqlParameter[] pars2 = {
                new SqlParameter("@arrange_id",course_id+teacher_id+class_id+classroom_id+time_id),
                new SqlParameter("@teacher_course_id",course_id+teacher_id+class_id),
                new SqlParameter("@classroom_id",classroom_id),
                new SqlParameter("@time_id",time_id)

            };
            //插入
            //   int i = DBUtils.getDBUtils().cud(sql1, pars1);

            int j = DBUtils.getDBUtils().cud(sql2, pars2);

            return j;
        }

        public IList<ModelObject> SelArrangeInfoByDetail(string class_id, string opentime)
        {
            string sql = "select course.course_type,course.course_name,course_hour,Course.course_credit,teacher_name,Arrange_course.classroom_id,time_id, arrange_course.id, arrange_course.teacher_course_id, course.course_opentime from Arrange_course,Teacher_course,Course where Arrange_course.teacher_course_id=Teacher_course.teacher_course_id and Teacher_course.class_id=@class_id and Course.course_opentime = @opentime and Course.course_id=Teacher_course.course_id";

            SqlParameter[] pars = {
                new SqlParameter("@class_id",class_id),
                new SqlParameter("@opentime",opentime),


            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<ModelObject> moList = new List<ModelObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ModelObject mo = new ModelObject();
                mo.item1 = dataTable.Rows[i]["course_name"].ToString();
                mo.item2 = dataTable.Rows[i]["course_hour"].ToString();
                mo.item3 = dataTable.Rows[i]["course_credit"].ToString();
                mo.item4 = dataTable.Rows[i]["teacher_name"].ToString();
                mo.item5 = dataTable.Rows[i]["classroom_id"].ToString();
                mo.item6 = dataTable.Rows[i]["time_id"].ToString();
                mo.item7 = dataTable.Rows[i]["id"].ToString();
                mo.item8 = dataTable.Rows[i]["teacher_course_id"].ToString();
                mo.item9 = dataTable.Rows[i]["course_type"].ToString();
                mo.item10 = dataTable.Rows[i]["course_opentime"].ToString();
                moList.Add(mo);
            }
            return moList;


        }

        public IList<ModelObject> SelArrangeInfoById(string id)
        {
            string sql = "select course_type,teacher_course.college_id,department,major_id,major,teacher_course.class_id,class,teacher_id,teacher_name,course.course_id,course.course_name,arrange_course.classroom_id,building,classroom,arrange_course.time_id,weekday,classtime ,course.course_opentime from Arrange_course,Teacher_course,classroom,Course_Time,course where arrange_course.id = @id and teacher_course.teacher_course_id = Arrange_course.teacher_course_id and Teacher_course.course_id = course.course_id and Arrange_course.classroom_id = classroom.classroom_id and Arrange_course.time_id = Course_Time.time_id";

            SqlParameter[] pars = {
                new SqlParameter("@id",id),

            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<ModelObject> moList = new List<ModelObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ModelObject mo = new ModelObject();
                mo.item1 = dataTable.Rows[i]["course_type"].ToString();
                mo.item2 = dataTable.Rows[i]["college_id"].ToString();
                mo.item3 = dataTable.Rows[i]["department"].ToString();
                mo.item4 = dataTable.Rows[i]["major_id"].ToString();
                mo.item5 = dataTable.Rows[i]["major"].ToString();
                mo.item6 = dataTable.Rows[i]["class_id"].ToString();
                mo.item7 = dataTable.Rows[i]["class"].ToString();
                mo.item8 = dataTable.Rows[i]["teacher_id"].ToString();
                mo.item9 = dataTable.Rows[i]["teacher_name"].ToString();
                mo.item10 = dataTable.Rows[i]["course_id"].ToString();
                mo.item11 = dataTable.Rows[i]["course_name"].ToString();
                mo.item12 = dataTable.Rows[i]["classroom_id"].ToString();
                mo.item13 = dataTable.Rows[i]["building"].ToString();
                mo.item14 = dataTable.Rows[i]["classroom"].ToString();
                mo.item15 = dataTable.Rows[i]["time_id"].ToString();
                mo.item16 = dataTable.Rows[i]["weekday"].ToString();
                mo.item17 = dataTable.Rows[i]["classtime"].ToString();
                mo.item18 = dataTable.Rows[i]["course_opentime"].ToString();
                moList.Add(mo);
            }
            return moList;


        }

        public IList<ModelObject> SelArrangeInfoByTeacherCourseId(string id)
        {
            string sql = "select * from arrange_course where teacher_course_id=@id";

            SqlParameter[] pars = {
                new SqlParameter("@id",id),

            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<ModelObject> moList = new List<ModelObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ModelObject mo = new ModelObject();
                mo.item1 = dataTable.Rows[i]["id"].ToString();

                moList.Add(mo);
            }
            return moList;
        }

        public int DelArrange_CourseById(string id)
        {
            string sql = "delete from arrange_course where id=@id";

            SqlParameter[] pars = {
                new SqlParameter("@id",id),

            };


            int j = DBUtils.getDBUtils().cud(sql, pars);

            return j;
        }
    }
}
