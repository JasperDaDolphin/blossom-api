using Blossom.Data.Model.StudentProfiles;
using Blossom.Service.Model.StudentProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.Service.StudentProfiles
{
	public interface IStudentProfileService
    {
        StudentProfile CreateStudentProfile(StudentProfile profile);

        void DeleteStudentProfile(Guid id);

        List<StudentProfile> GetAll(Expression<Func<StudentProfileEntity, bool>> filter = null);

        StudentProfile GetById(Guid id);

        StudentProfile UpdateStudentProfile(StudentProfile profile);
    }
}
