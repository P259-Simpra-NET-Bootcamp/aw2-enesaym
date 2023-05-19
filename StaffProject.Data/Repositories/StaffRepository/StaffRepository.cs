using StaffProject.Data.Context;
using StaffProject.Data.Domain;
using StaffProject.Data.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffProject.Data.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(StaffDbContext context): base(context)
        {
        
        }

        public IEnumerable<Staff> GetFilteredStaff(string firstName, string city)
        {
            var query = dbContext.Set<Staff>().AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(s => s.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(s => s.City.Contains(city));
            }

            return query.ToList();
        }
        public bool ControlUniqueEmail(string email)
        {
            var existingStaff = dbContext.Staff.FirstOrDefault(x => x.Email == email);
            return existingStaff == null;
          
        }
    }
}
