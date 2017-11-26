using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherService teacherService = new TeacherServiceImpl();
        private IRoleInfoService roleInfoService = new RoleInfoServiceImpl();
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回所有课程信息
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectCourse()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string teacher_id = Session["teacher_id"].ToString();
            IList<Teacher_course> courseList = teacherService.SelectAllCourse(teacher_id);
            return Json(new { courseList = courseList });
        }


        /// <summary>
        /// 学生打分信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStudentInfo()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string courseId;
            if (Session["course_id"] == null)
            {
                courseId = Request["courseid"];
            }
            else
            {
                courseId = Session["course_id"].ToString();
            }
        
            Status status = teacherService.GetStatus(courseId);

            IList<Course_choosing> studentList = teacherService.SelectAllStudentCourse(courseId);          
            return Json(new { studentList = studentList , status = status }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查看当前情况
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStudentInfo2()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string courseId;
            if (Session["course_id"] == null)
            {
                courseId = Request["courseid"];
            }
            else
            {
                courseId = Session["course_id"].ToString();
            }     

            IList<Course_choosing> studentList = teacherService.SelectAllStudentCourse(courseId);
            return Json(new { studentList = studentList, status = "0" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 教师主界面
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherManager()
        {
            //教师登录后在session中写入教师id
            //获取教师登录的id
            Login info = (Login)Session["loginInfo"];
            if(info == null)
            {
                return RedirectToAction("Index","Login");
            }

            Session.Add("teacher_id", info.username);
            return View();
        }

        /// <summary>
        /// 教师打分
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherCheckScore()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }


            //此处需要在session中设置课程号
            string course_id = Request["courseid"];
            Session.Add("course_id", course_id);
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherCheckScore2()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }


            //此处需要在session中设置课程号
            string course_id = Request["courseid"];
            Session.Add("course_id", course_id);
            return View();
        }

        /// <summary>
        /// 老师查看课程
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherSelectCourse()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

        /// <summary>
        /// 老师查看课程和成绩
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherSelectCourse2()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        /// <summary>
        /// 保存成绩
        /// </summary>
        /// <returns></returns>
        public ActionResult SetScore()
        {
            Login info = (Login)Session["loginInfo"];
            if (info == null)
            {
                return RedirectToAction("Index", "Login");
            }


            //设置session
            string courseid = Session["course_id"].ToString();
            //保存成绩
            if(Request["myflag"] == "" || Request["myflag"] == null)
            {
                Response.Write("<script>alert('无效')</script>");
                return null;
            }

            int count = Convert.ToInt32(Request["myflag"]);
            
            for(int i=1; i<=count; i++)
            {
                string mystudent = "student_id" + i;
                string myusual = "usual_grade" + i;
                string mytest = "test_grade" + i;
                string mytotal = "total_grade" + i;

                string student_id = Request[mystudent];               
                string usual_grade = Request[myusual];
                string test_grade = Request[mytest];               
                string total_grade = Request[mytotal];

                teacherService.InsertStudentGrade(usual_grade, test_grade, total_grade, student_id);

            }

            //设置状态
            string mystatus = Request["mystatus"];
          
            string mycourseid = Request["mycourse"];
            if(mystatus == "0")
            {
                //保存状态，页面上不能修改成绩
                teacherService.SetStatus(mystatus, mycourseid);
            }

            return RedirectToAction("TeacherCheckScore",new { courseid = courseid });
        }


        public ActionResult ChangeSelfInfo()
        {
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                //跳转到登录页面
                Session["prePage"] = "/Teacher/TeacherManager";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }

            string username = login.username;
            //string username = "201702";

            Teacher teacher = roleInfoService.SelectTeacherByID(username);
            ViewData["teacher"] = teacher;
            return View();
        }


        public ActionResult ChangePassPage()
        {
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                //跳转到登录页面
                Session["prePage"] = "/Teacher/TeacherManager";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }

            string username = login.username;
            //string username = "201702";

            Teacher teacher = roleInfoService.SelectTeacherByID(username);
            ViewData["teacher"] = teacher;

            return View();
        }


        //提交修改后的个人信息
        public ActionResult SubmitUpdateTeacherInfo(string teacherID, string contact, string other)
        {
            Teacher teacher = roleInfoService.SelectTeacherByID(teacherID);

            string teacherName = teacher.teacher_name;
            string teacherSex = teacher.teachert_sex;
            string teacherIDCard = teacher.teacher_id_card;
            int teacherAge = Convert.ToInt32(teacher.teachert_age);
            string teacherDepartment = teacher.teacher_department;
            string teacherTitle = teacher.teacher_title;
            string teacherNative = teacher.teacher_native;
            string teacherBirthplace = teacher.teacher_birthplace;
            string teacherPoliticsstatus = teacher.teacher_politicsstatus;
            string teacherTeachingtime = teacher.teacher_teachingtime;
            string teacherContact = teacher.teacher_contact;
            string teacherOther = teacher.teacher_other;
            int teacherStatus = Convert.ToInt32(teacher.status);
            if (!contact.Equals(teacherContact))
            {
                teacherContact = contact;
            }
            if (!other.Equals(teacherOther))
            {
                teacherContact = other;
            }

            string result = roleInfoService.UpdateTeacherInfo(teacherID, teacherName, teacherSex, teacherIDCard, teacherAge, teacherDepartment, teacherTitle, teacherNative, teacherBirthplace, teacherPoliticsstatus, teacherTeachingtime, teacherContact, teacherOther, teacherStatus);

            return View("ChangeSelfInfo");
        }

        public ActionResult CheckStatus()
        {
            Status status = teacherService.GetAllStatus("t");
            if (status.global_status == "0")
            {
                return Json(new { status = "0", msg = "系统已经关闭，请联系管理员！" });
            }
            else
            {
                return Json(new { status = "1", msg = "正常使用" });
            }
        }

        public ActionResult CheckStatusStudent()
        {
            Status status = teacherService.GetAllStatus("s");
            if (status.global_status == "0")
            {
                return Json(new { status = "0", msg = "系统已经关闭，请联系管理员！" });
            }
            else
            {
                return Json(new { status = "1", msg = "正常使用" });
            }
        }

    }
}