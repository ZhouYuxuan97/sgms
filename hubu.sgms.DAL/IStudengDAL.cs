using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface IStudengDAL
    {
        /// <summary>
        /// 通过学生id获取学生详细信息
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        Student SelectStudentById(string stuId);
    }
}
