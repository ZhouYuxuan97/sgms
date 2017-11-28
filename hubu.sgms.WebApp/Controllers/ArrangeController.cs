using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
using hubu.sgms.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Controllers
{



    public class ArrangeController : Controller
    {
        static string arrangecourseid = "";
        private ICollegeService collegeService = new CollegeServiceImpl();
        private ITeacher_CourseService Teacher_CourseService = new Teacher_CourseServiceImpl();
        private ICourseService courseService = new CourseServiceImpl();
        private IMajorService majorService = new MajorServiceImpl();
        private IClassService classService = new ClassServiceImpl();
        private IArrange_CourseService arrange_courseService = new Arrange_CourseServiceImpl();
        private ITeacherService teacherService = new TeacherServiceImpl();
        private IClassroomService classroomService = new ClassroomServiceImpl();
        private ICourse_TimeService course_timeService = new Course_TimeServiceImpl();
        private IRoleInfoService roleInfoService = new RoleInfoServiceImpl();

        public ActionResult CAArrangeCourse()
        {
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                //跳转到登录页面
                Session["prePage"] = "/Admin/Index";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }
            Administrator admin = roleInfoService.SelectAdministratorByID(login.username);
            string dep = admin.administrator_photo;
            string depval = admin.administrator_department;
            ViewData["dep"] = dep;
            ViewData["depval"] = depval;
            arrangecourseid = Request.QueryString["id"];

            //如果url中有传值进来，说明不是初始的排课页面，需要填充信息
            if (arrangecourseid != null)
            {
                IList<ModelObject> molist = arrange_courseService.SelArrangeInfoById(arrangecourseid);

                var categoryModelObjectList = new List<ModelObject>();

                for (int i = 0; i < molist.Count; i++)
                {
                    categoryModelObjectList.Add(molist[i]);
                }

                ViewData["coursetype"] = molist[0].item1;
                ViewData["college"] = molist[0].item3;
                switch (molist[0].item13)
                {
                    case "1":
                        ViewData["building"] = "教一";
                        break;
                    case "2":
                        ViewData["building"] = "教二";
                        break;
                    case "3":
                        ViewData["building"] = "教三";
                        break;
                    case "4":
                        ViewData["building"] = "教四";
                        break;
                    case "5":
                        ViewData["building"] = "教五";
                        break;
                    default:
                        break;
                }
                switch (molist[0].item16)
                {
                    case "1":
                        ViewData["weekday"] = "一";
                        break;
                    case "2":
                        ViewData["weekday"] = "二";
                        break;
                    case "3":
                        ViewData["weekday"] = "三";
                        break;
                    case "4":
                        ViewData["weekday"] = "四";
                        break;
                    case "5":
                        ViewData["weekday"] = "五";
                        break;
                    case "6":
                        ViewData["weekday"] = "六";
                        break;
                    default:
                        break;
                }


                //填充majorlist
                IList<Major> m = majorService.SelMajorByCollegeId(molist[0].item3);

                var categoryMajorList = new List<Major>();

                for (int i = 0; i < m.Count; i++)
                {
                    categoryMajorList.Add(m[i]);
                }

                var selectItemListforMajor = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item4,Text=molist[0].item5,Selected=true}
                   };
                var selectMajorList = new SelectList(categoryMajorList, "major_id", "major_name");

                selectItemListforMajor.AddRange(selectMajorList);

                ViewBag.majorList = selectItemListforMajor.AsEnumerable();

                //填充classlist
                IList<Class> c1 = classService.SelClassByMajorId(molist[0].item4);

                var categoryClassList = new List<Class>();

                for (int i = 0; i < c1.Count; i++)
                {
                    categoryClassList.Add(c1[i]);
                }

                var selectItemListforClass = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item6,Text=molist[0].item7,Selected=true}
                   };
                var selectClassList = new SelectList(categoryClassList, "class_id", "yuliu1");

                selectItemListforClass.AddRange(selectClassList);

                ViewBag.classList = selectItemListforClass.AsEnumerable();

                //填充courselist
                IList<Course> c = courseService.SelCourseforArrangeCourse(molist[0].item1, molist[0].item2);

                var categoryList = new List<Course>();

                for (int i = 0; i < c.Count; i++)
                {
                    categoryList.Add(c[i]);
                }

                var selectItemListforCourse = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item10,Text=molist[0].item11,Selected=true}
                   };
                var selectCollegeList = new SelectList(categoryList, "course_id", "course_name");

                selectItemListforCourse.AddRange(selectCollegeList);

                ViewBag.courseList = selectItemListforCourse.AsEnumerable();

                //填充teacherlist
                IList<Teacher> t = teacherService.SelTeacherByCollegeId(molist[0].item2);

                var categoryTeacherList = new List<Teacher>();

                for (int i = 0; i < t.Count; i++)
                {
                    categoryTeacherList.Add(t[i]);
                }

                var selectItemListforTeacher = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item8,Text=molist[0].item9,Selected=true}
                   };
                var selectTeacherList = new SelectList(categoryTeacherList, "teacher_id", "teacher_name");

                selectItemListforTeacher.AddRange(selectTeacherList);

                ViewBag.teacherList = selectItemListforTeacher.AsEnumerable();

                //填充classroomlist
                IList<Classroom> c2 = classroomService.SelClassroomByBuilding(molist[0].item13);
                var categoryClassroomList = new List<Classroom>();
                for (int j = 0; j < c2.Count; j++)
                {
                    categoryClassroomList.Add(c2[j]);
                }
                var selectItemListforClassroom = new List<SelectListItem>();

                selectItemListforClassroom = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item12,Text=molist[0].item14,Selected=true}
                   };

                var selectClassroomList = new SelectList(categoryClassroomList, "classroom_id", "classroom");

                selectItemListforClassroom.AddRange(selectClassroomList);

                ViewBag.classroomList = selectItemListforClassroom.AsEnumerable();

                //填充classtimelist
                IList<Course_Time> ct = course_timeService.SelCourseTimeByItems(molist[0].item14, molist[0].item16, molist[0].item8, molist[0].item6);
                var categoryCourse_TimeList = new List<Course_Time>();

                for (int j = 0; j < ct.Count; j++)
                {
                    categoryCourse_TimeList.Add(ct[j]);
                }


                var selectItemListforCourse_Time = new List<SelectListItem>();

                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value=molist[0].item15,Text=molist[0].item17,Selected=true}
                   };

                var selectCourse_TimeList = new SelectList(categoryCourse_TimeList, "time_id", "classtime");

                selectItemListforCourse_Time.AddRange(selectCourse_TimeList);

                ViewBag.classtimeList = selectItemListforCourse_Time.AsEnumerable();
            }
            return View("CAArrangeCourse");
        }


        public ActionResult CASelArrangeCourseInfo()
        {
            var id = Request.QueryString["class1"];

            //如果地址栏传值，说明不是初始的查询信息页面
            if (id != null)
            {
                IList<ModelObject> molist = classService.SelCollegeandMajorByClassId(id);
                ViewData["college"] = molist[0].item2;

                //填充majorlist
                IList<Major> m = majorService.SelMajorByCollegeId(molist[0].item3);

                var categoryMajorList = new List<Major>();

                for (int i = 0; i < m.Count; i++)
                {
                    categoryMajorList.Add(m[i]);
                }

                var selectItemListforMajor = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item3,Text=molist[0].item4,Selected=true}
                   };
                var selectMajorList = new SelectList(categoryMajorList, "major_id", "major_name");

                selectItemListforMajor.AddRange(selectMajorList);

                ViewBag.majorList = selectItemListforMajor.AsEnumerable();

                //填充classlist
                IList<Class> c1 = classService.SelClassByMajorId(molist[0].item4);

                var categoryClassList = new List<Class>();

                for (int i = 0; i < c1.Count; i++)
                {
                    categoryClassList.Add(c1[i]);
                }

                var selectItemListforClass = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item5,Text=molist[0].item6,Selected=true}
                   };
                var selectClassList = new SelectList(categoryClassList, "class_id", "yuliu1");

                selectItemListforClass.AddRange(selectClassList);

                ViewBag.classList = selectItemListforClass.AsEnumerable();

            }
            return View("CASelArrangeCourseInfo");
        }

        public ActionResult SAArrangeCourse()
        {
            arrangecourseid = Request.QueryString["id"];

            //如果url中有传值进来，说明不是初始的排课页面，需要填充信息
            if (arrangecourseid != null)
            {
                IList<ModelObject> molist = arrange_courseService.SelArrangeInfoById(arrangecourseid);

                var categoryModelObjectList = new List<ModelObject>();

                for (int i = 0; i < molist.Count; i++)
                {
                    categoryModelObjectList.Add(molist[i]);
                }

                ViewData["coursetype"] = molist[0].item1;
                ViewData["college"] = molist[0].item3;
                switch (molist[0].item13)
                {
                    case "1":
                        ViewData["building"] = "教一";
                        break;
                    case "2":
                        ViewData["building"] = "教二";
                        break;
                    case "3":
                        ViewData["building"] = "教三";
                        break;
                    case "4":
                        ViewData["building"] = "教四";
                        break;
                    case "5":
                        ViewData["building"] = "教五";
                        break;
                    default:
                        break;
                }
                switch (molist[0].item16)
                {
                    case "1":
                        ViewData["weekday"] = "一";
                        break;
                    case "2":
                        ViewData["weekday"] = "二";
                        break;
                    case "3":
                        ViewData["weekday"] = "三";
                        break;
                    case "4":
                        ViewData["weekday"] = "四";
                        break;
                    case "5":
                        ViewData["weekday"] = "五";
                        break;
                    case "6":
                        ViewData["weekday"] = "六";
                        break;
                    default:
                        break;
                }


                //填充majorlist
                IList<Major> m = majorService.SelMajorByCollegeId(molist[0].item3);

                var categoryMajorList = new List<Major>();

                for (int i = 0; i < m.Count; i++)
                {
                    categoryMajorList.Add(m[i]);
                }

                var selectItemListforMajor = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item4,Text=molist[0].item5,Selected=true}
                   };
                var selectMajorList = new SelectList(categoryMajorList, "major_id", "major_name");

                selectItemListforMajor.AddRange(selectMajorList);

                ViewBag.majorList = selectItemListforMajor.AsEnumerable();

                //填充classlist
                IList<Class> c1 = classService.SelClassByMajorId(molist[0].item4);

                var categoryClassList = new List<Class>();

                for (int i = 0; i < c1.Count; i++)
                {
                    categoryClassList.Add(c1[i]);
                }

                var selectItemListforClass = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item6,Text=molist[0].item7,Selected=true}
                   };
                var selectClassList = new SelectList(categoryClassList, "class_id", "yuliu1");

                selectItemListforClass.AddRange(selectClassList);

                ViewBag.classList = selectItemListforClass.AsEnumerable();

                //填充courselist
                IList<Course> c = courseService.SelCourseforArrangeCourse(molist[0].item1, molist[0].item2);

                var categoryList = new List<Course>();

                for (int i = 0; i < c.Count; i++)
                {
                    categoryList.Add(c[i]);
                }

                var selectItemListforCourse = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item10,Text=molist[0].item11,Selected=true}
                   };
                var selectCollegeList = new SelectList(categoryList, "course_id", "course_name");

                selectItemListforCourse.AddRange(selectCollegeList);

                ViewBag.courseList = selectItemListforCourse.AsEnumerable();

                //填充teacherlist
                IList<Teacher> t = teacherService.SelTeacherByCollegeId(molist[0].item2);

                var categoryTeacherList = new List<Teacher>();

                for (int i = 0; i < t.Count; i++)
                {
                    categoryTeacherList.Add(t[i]);
                }

                var selectItemListforTeacher = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item8,Text=molist[0].item9,Selected=true}
                   };
                var selectTeacherList = new SelectList(categoryTeacherList, "teacher_id", "teacher_name");

                selectItemListforTeacher.AddRange(selectTeacherList);

                ViewBag.teacherList = selectItemListforTeacher.AsEnumerable();

                //填充classroomlist
                IList<Classroom> c2 = classroomService.SelClassroomByBuilding(molist[0].item13);
                var categoryClassroomList = new List<Classroom>();
                for (int j = 0; j < c2.Count; j++)
                {
                    categoryClassroomList.Add(c2[j]);
                }
                var selectItemListforClassroom = new List<SelectListItem>();

                selectItemListforClassroom = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item12,Text=molist[0].item14,Selected=true}
                   };

                var selectClassroomList = new SelectList(categoryClassroomList, "classroom_id", "classroom");

                selectItemListforClassroom.AddRange(selectClassroomList);

                ViewBag.classroomList = selectItemListforClassroom.AsEnumerable();

                //填充classtimelist
                IList<Course_Time> ct = course_timeService.SelCourseTimeByItems(molist[0].item14, molist[0].item16, molist[0].item8, molist[0].item6);
                var categoryCourse_TimeList = new List<Course_Time>();

                for (int j = 0; j < ct.Count; j++)
                {
                    categoryCourse_TimeList.Add(ct[j]);
                }

                var selectItemListforCourse_Time = new List<SelectListItem>();

                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value=molist[0].item15,Text=molist[0].item17,Selected=true}
                   };

                var selectCourse_TimeList = new SelectList(categoryCourse_TimeList, "time_id", "classtime");

                selectItemListforCourse_Time.AddRange(selectCourse_TimeList);

                ViewBag.classtimeList = selectItemListforCourse_Time.AsEnumerable();
            }
            return View("SAArrangeCourse");
        }

        public ActionResult SASelArrangeCourseInfo()
        {
            var id = Request.QueryString["class1"];
            //如果地址栏传值，说明不是初始的查询信息页面
            if (id != null)
            {
                IList<ModelObject> molist = classService.SelCollegeandMajorByClassId(id);
                ViewData["college"] = molist[0].item2;

                //填充majorlist
                IList<Major> m = majorService.SelMajorByCollegeId(molist[0].item3);

                var categoryMajorList = new List<Major>();

                for (int i = 0; i < m.Count; i++)
                {
                    categoryMajorList.Add(m[i]);
                }

                var selectItemListforMajor = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item3,Text=molist[0].item4,Selected=true}
                   };
                var selectMajorList = new SelectList(categoryMajorList, "major_id", "major_name");

                selectItemListforMajor.AddRange(selectMajorList);

                ViewBag.majorList = selectItemListforMajor.AsEnumerable();

                //填充classlist
                IList<Class> c1 = classService.SelClassByMajorId(molist[0].item4);

                var categoryClassList = new List<Class>();

                for (int i = 0; i < c1.Count; i++)
                {
                    categoryClassList.Add(c1[i]);
                }

                var selectItemListforClass = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item5,Text=molist[0].item6,Selected=true}
                   };
                var selectClassList = new SelectList(categoryClassList, "class_id", "yuliu1");

                selectItemListforClass.AddRange(selectClassList);

                ViewBag.classList = selectItemListforClass.AsEnumerable();

            }
            return View("SASelArrangeCourseInfo");
        }

        public ActionResult CAFillMajor(string college)
        {
            IList<Major> m = majorService.SelMajorByCollegeId(college);

            var categoryMajorList = new List<Major>();

            for (int i = 0; i < m.Count; i++)
            {
                categoryMajorList.Add(m[i]);
            }

            var selectItemListforMajor = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            var selectMajorList = new SelectList(categoryMajorList, "major_id", "major_name");

            selectItemListforMajor.AddRange(selectMajorList);

            ViewBag.majorList = selectItemListforMajor.AsEnumerable();

            return Json(selectItemListforMajor);
        }

        public ActionResult CAFillCourse(string college, string coursetype)
        {
            IList<Course> c = courseService.SelCourseforArrangeCourse(coursetype, college);

            var categoryList = new List<Course>();

            for (int i = 0; i < c.Count; i++)
            {
                categoryList.Add(c[i]);
            }

            var selectItemListforCourse = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            var selectCollegeList = new SelectList(categoryList, "course_id", "course_name");

            selectItemListforCourse.AddRange(selectCollegeList);

            return Json(selectItemListforCourse);
        }

        public ActionResult CAFillTeacher(string college)
        {
            IList<Teacher> t = teacherService.SelTeacherByCollegeId(college);

            var categoryTeacherList = new List<Teacher>();

            for (int i = 0; i < t.Count; i++)
            {
                categoryTeacherList.Add(t[i]);
            }

            var selectItemListforTeacher = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            var selectTeacherList = new SelectList(categoryTeacherList, "teacher_id", "teacher_name");

            selectItemListforTeacher.AddRange(selectTeacherList);

            return Json(selectItemListforTeacher);
        }

        public ActionResult CAFillClass(string major)
        {
            IList<Class> c1 = classService.SelClassByMajorId(major);

            var categoryClassList = new List<Class>();

            for (int i = 0; i < c1.Count; i++)
            {
                categoryClassList.Add(c1[i]);
            }

            var selectItemListforClass = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            var selectClassList = new SelectList(categoryClassList, "class_id", "yuliu1");

            selectItemListforClass.AddRange(selectClassList);

            return Json(selectItemListforClass);
        }

        public ActionResult CAFillClassroom(string building)
        {
            IList<Classroom> c = classroomService.SelClassroomByBuilding(building);
            var categoryClassroomList = new List<Classroom>();
            for (int j = 0; j < c.Count; j++)
            {
                categoryClassroomList.Add(c[j]);
            }
            var selectItemListforClassroom = new List<SelectListItem>();

            selectItemListforClassroom = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };

            var selectClassroomList = new SelectList(categoryClassroomList, "classroom_id", "classroom");

            selectItemListforClassroom.AddRange(selectClassroomList);

            return Json(selectItemListforClassroom);
        }

        public ActionResult CAFillClasstime(string classroom, string weekday, string teacher, string class1)
        {
            IList<Course_Time> ct = course_timeService.SelCourseTimeByItems(classroom, weekday, teacher, class1);
            var categoryCourse_TimeList = new List<Course_Time>();

            for (int j = 0; j < ct.Count; j++)
            {
                categoryCourse_TimeList.Add(ct[j]);
            }


            var selectItemListforCourse_Time = new List<SelectListItem>();
            if (ct.Count == 0)
            {
                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value="",Text="该教室当天已无空闲上课时段",Selected=true}
                   };
            }
            else {
                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            }
            var selectCourse_TimeList = new SelectList(categoryCourse_TimeList, "time_id", "classtime");

            selectItemListforCourse_Time.AddRange(selectCourse_TimeList);

            return Json(selectItemListforCourse_Time);
        }

        public ActionResult CAFillTotalPage(string class1, string courseopentime)
        {
            IList<ModelObject> molist = arrange_courseService.SelArrangeInfoByDetail(class1, courseopentime);

            int totalpage = molist.Count / 10 + 1;

            return Json(totalpage.ToString());
        }

        public ActionResult InsArrangeDetail(string class1, string course, string teacher, string classroom, string classtime, string weekday)

        {

            int i = 0;
            int j = 0;

            IList<Teacher_course> tc = Teacher_CourseService.SelTeacher_CourseByDetail(course, teacher, class1);

            if (tc.Count == 0) { i = Teacher_CourseService.AddTeacher_Course(course, teacher, class1); }

            j = arrange_courseService.AddArrange_Course(course, teacher, class1, classroom, classtime);

            IList<Course_Time> ct = course_timeService.SelCourseTimeByItems(classroom, weekday, teacher, class1);
            var categoryCourse_TimeList = new List<Course_Time>();
            for (int k = 0; k < ct.Count; k++)
            {
                categoryCourse_TimeList.Add(ct[k]);
            }
            var selectItemListforCourse_Time = new List<SelectListItem>();
            if (ct.Count == 0)
            {
                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value="",Text="该教室当天已无空闲上课时段",Selected=true}
                   };
            }
            else {
                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            }
            var selectCourse_TimeList = new SelectList(categoryCourse_TimeList, "time_id", "classtime");

            selectItemListforCourse_Time.AddRange(selectCourse_TimeList);

            return Json(selectItemListforCourse_Time);
        }

        public ActionResult CASelArrangeInfo(string class1, string courseopentime, string page)
        {

            int pagenum = int.Parse(page);
            IList<ModelObject> molist = arrange_courseService.SelArrangeInfoByDetail(class1, courseopentime);

            var categoryModelObjectList = new List<ModelObject>();

            for (int i = (pagenum - 1) * 10; i < molist.Count && i < pagenum * 10; i++)
            {
                categoryModelObjectList.Add(molist[i]);
            }


            return Json(categoryModelObjectList);
        }

        public ActionResult UpdateArrangeInfo(string class1, string course, string teacher, string classroom, string classtime, string weekday)
        {

            int i = 0;
            int j = 0;

            IList<Teacher_course> tc = Teacher_CourseService.SelTeacher_CourseByDetail(course, teacher, class1);

            if (tc.Count == 0) { i = Teacher_CourseService.AddTeacher_Course(course, teacher, class1); }

            //删除旧数据
            j = arrange_courseService.DelArrange_CourseById(arrangecourseid);

            //插入新数据
            j = arrange_courseService.AddArrange_Course(course, teacher, class1, classroom, classtime);


            return View("CASelArrangeCourseInfo");
        }

        public ActionResult DelArrangeCourse()
        {
            int j;
            int i;
            arrangecourseid = Request.QueryString["id"];
            string teachercourseid = arrangecourseid.Substring(0, 18);
            j = arrange_courseService.DelArrange_CourseById(arrangecourseid);


            //判断删掉的该时间-教室数据是否是该选课的最后一条数据，若是则一同删掉选课数据
            IList<ModelObject> molist = arrange_courseService.SelArrangeInfoByTeacherCourseId(teachercourseid);
            if (molist.Count == 0)
            {
                i = Teacher_CourseService.DelTeacher_CourseById(teachercourseid);
            }

            var classid = arrangecourseid.Substring(10, 8);
            //如果地址栏传值，说明不是初始的查询信息页面

            molist = classService.SelCollegeandMajorByClassId(classid);
            ViewData["college"] = molist[0].item2;

            //填充majorlist
            IList<Major> m = majorService.SelMajorByCollegeId(molist[0].item3);

            var categoryMajorList = new List<Major>();

            for (i = 0; i < m.Count; i++)
            {
                categoryMajorList.Add(m[i]);
            }

            var selectItemListforMajor = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item3,Text=molist[0].item4,Selected=true}
                   };
            var selectMajorList = new SelectList(categoryMajorList, "major_id", "major_name");

            selectItemListforMajor.AddRange(selectMajorList);

            ViewBag.majorList = selectItemListforMajor.AsEnumerable();

            //填充classlist
            IList<Class> c1 = classService.SelClassByMajorId(molist[0].item4);

            var categoryClassList = new List<Class>();

            for (i = 0; i < c1.Count; i++)
            {
                categoryClassList.Add(c1[i]);
            }

            var selectItemListforClass = new List<SelectListItem>() {
                       new SelectListItem(){Value=molist[0].item5,Text=molist[0].item6,Selected=true}
                   };
            var selectClassList = new SelectList(categoryClassList, "class_id", "yuliu1");

            selectItemListforClass.AddRange(selectClassList);

            ViewBag.classList = selectItemListforClass.AsEnumerable();


            return View("CASelArrangeCourseInfo");
        }

        
    }
}