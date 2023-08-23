using BusinessData.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SlotRepo : RepositoryBase<Slot>
    {
        SlotRepo(CourseManageContext context) : base(context) { }
    }
}
