using BusinessData.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AttendanceRepo : RepositoryBase<Attendance>
    {
        public AttendanceRepo(CourseManageContext context) : base(context) { }
    }
}
