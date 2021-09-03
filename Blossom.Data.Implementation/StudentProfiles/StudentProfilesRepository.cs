using Blossom.Data.Model;
using Blossom.Data.Model.StudentProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blossom.Data.StudentProfiles;
using Microsoft.EntityFrameworkCore;

namespace Blossom.Data.Implementation.StudentProfiles
{
    public class StudentProfilesRepository : StringRepositoryBase<StudentProfileEntity>, IStudentProfilesRepository
    {
        public StudentProfilesRepository(BlossomContext context) : base(context) { }

        public override IEnumerable<StudentProfileEntity> Get(Expression<Func<StudentProfileEntity, bool>> filter = null)
        {
            var query = _context.Set<StudentProfileEntity>().Include(u => u.User).AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.AsEnumerable();
        }

        public override StudentProfileEntity GetById(Guid id)
        {
            return _context.Set<StudentProfileEntity>()
                .Include(u => u.User)
                .Where(u => u.Id == id)
                .SingleOrDefault();
        }

        public override StudentProfileEntity Update(StudentProfileEntity input)
        {
            var entity = this.GetById(input.Id);

            if (entity != null)
            {
                if (input.FirstName != null)
                {
                    entity.FirstName = input.FirstName;
                }

                if (input.MiddleName != null)
                {
                    entity.MiddleName = input.MiddleName;
                }

                if (input.LastName != null)
                {
                    entity.LastName = input.LastName;
                }

                if (input.Gender != null)
                {
                    entity.Gender = input.Gender;
                }

                if (input.PhoneNumber != null)
                {
                    entity.PhoneNumber = input.PhoneNumber;
                }

                if (input.University != null)
                {
                    entity.University = input.University;
                }

                if (input.StartingYear != null)
                {
                    entity.StartingYear = input.StartingYear;
                }

                if (input.GraduationYear != null)
                {
                    entity.GraduationYear = input.GraduationYear;
                }

                if (input.Degree != null)
                {
                    entity.Degree = input.Degree;
                }

                if (input.Majors != null)
                {
                    entity.Majors = input.Majors;
                }

                if (input.WorkingStatus != null)
                {
                    entity.WorkingStatus = input.WorkingStatus;
                }

                if (input.State != null)
                {
                    entity.State = input.State;
                }

                if (input.Skills != null)
                {
                    entity.Skills = input.Skills;
                }

                if (input.About != null)
                {
                    entity.About = input.About;
                }

                entity.DateUpdated = DateTime.Now;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Student Profile not found.");
            }

            return entity;
        }
    }
}
