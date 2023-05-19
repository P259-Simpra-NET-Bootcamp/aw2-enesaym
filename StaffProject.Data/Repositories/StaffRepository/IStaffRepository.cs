using StaffProject.Data.Domain;
using StaffProject.Data.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffProject.Data.Repositories
{
    public interface IStaffRepository :IGenericRepository<Staff>
    {
        IEnumerable<Staff> GetFilteredStaff(string city, string firstName);
        public bool ControlUniqueEmail(string email);
    }
}
