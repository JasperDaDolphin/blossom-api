using Blossom.Data.Model.StudentProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.Data.StudentProfiles
{
	public interface IStudentProfilesRepository : IRepository<StudentProfileEntity>, IStringRepository<StudentProfileEntity>
	{
	}
}
