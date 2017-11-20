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
    public class ClassDALImpl : IClassDAL
    {


        public IList<Class> SelClassByMajorId(string MajorId)
        {
            string sql = "select class_id,substring(class_id,5,4) class_name from class where major_id=@majorid ";
            SqlParameter[] pars = {
                new SqlParameter("@majorid",MajorId),

        };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<Class> classList = new List<Class>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Class c = new Class();
                c.class_id = dataTable.Rows[i]["class_id"].ToString();
                c.yuliu1 = dataTable.Rows[i]["class_name"].ToString();
                classList.Add(c);
            }
            return classList;
        }

        public Class SelClassByClassId(string ClassId)
        {
            string sql = "select yuliu1 from Class where Class_id=@id";

            SqlParameter[] pars = {
                new SqlParameter("@id",ClassId),

        };

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            Class c = null;


            if (dataTable.Rows.Count > 0)
            {
                c = new Class();
                DataRow dataRow = dataTable.Rows[0];

                c.yuliu1 = dataRow["yuliu1"].ToString();

            }

            return c;
        }

        public IList<ModelObject> SelCollegeandMajorByClassId(string ClassId)
        {
            string sql = "select college.college_id, name,major.major_id,major_name,class_id,substring(class_id,5,4)  class_name from college,major, class where class_id=@classid and college.college_id=major.college_id and major.major_id=class.major_id ";
            SqlParameter[] pars = {
                new SqlParameter("@classid",ClassId),

        };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<ModelObject> moList = new List<ModelObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ModelObject mo = new ModelObject();
                mo.item1 = dataTable.Rows[i]["college_id"].ToString();
                mo.item2 = dataTable.Rows[i]["name"].ToString();
                mo.item3 = dataTable.Rows[i]["major_id"].ToString();
                mo.item4 = dataTable.Rows[i]["major_name"].ToString();
                mo.item5 = dataTable.Rows[i]["class_id"].ToString();
                mo.item6 = dataTable.Rows[i]["class_name"].ToString();

                moList.Add(mo);
            }
            return moList;
        }
    }
}
