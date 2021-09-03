using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blossom.Data.StudentProfiles;
using Blossom.Data.Model.StudentProfiles;
using Blossom.Data.Model.Users;
using Blossom.Data.Users;
using Blossom.Service.StudentProfiles;
using Blossom.Service.Model.StudentProfiles;

namespace Blossom.Service.Implementation.StudentProfiles
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly IMapper _mapper;
        private readonly IStudentProfilesRepository _studentProfileRepository;
        private readonly IUserRepository _userRepository;

        public StudentProfileService(
            IMapper mapper,
            IStudentProfilesRepository studentProfileRepository,
            IUserRepository userRepository
        )
        {
            _mapper = mapper;
            _studentProfileRepository = studentProfileRepository;
            _userRepository = userRepository;
        }

        public StudentProfile CreateStudentProfile(StudentProfile profile)
        {
            var user = _userRepository.GetById(profile.UserId);
            if (user != null)
            {
                if (user.StudentProfile.Count() <= 0)
                {
                    var studentProfileEntity = new StudentProfileEntity
                    {
                        FirstName = profile.FirstName,
                        MiddleName = profile.MiddleName,
                        LastName = profile.LastName,
                        Gender = profile.Gender,
                        University = profile.University,
                        Degree = profile.Degree,
                        Majors = profile.Majors,
                        StartingYear = profile.StartingYear,
                        GraduationYear = profile.GraduationYear,
                        WorkingStatus = profile.WorkingStatus,
                        PhoneNumber = profile.PhoneNumber,
                        About = profile.About,
                        State = profile.State,
                        Skills = profile.Skills,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        User = user
                    };

                    var result = _studentProfileRepository.Insert(studentProfileEntity);

                    return _mapper.Map<StudentProfile>(result);
                }
                else
                {
                    throw new ArgumentException("User already has StudentProfile.");
                }
            }
            else
            {
                throw new ArgumentException("User does not exist.");
            }
        }

        public void DeleteStudentProfile(Guid id)
        {
            _studentProfileRepository.Delete(id);
        }

        public List<StudentProfile> GetAll(Expression<Func<StudentProfileEntity, bool>> filter = null)
        {
            var userEntities = _studentProfileRepository.Get(filter);
            return _mapper.Map<List<StudentProfile>>(userEntities);
        }

        public StudentProfile GetById(Guid id)
        {
            var userEntity = _studentProfileRepository.GetById(id);
            return _mapper.Map<StudentProfile>(userEntity);
        }

        public StudentProfile UpdateStudentProfile(StudentProfile profile)
        {
            var profileEntity = _mapper.Map<StudentProfileEntity>(profile);
            return _mapper.Map<StudentProfile>(_studentProfileRepository.Update(profileEntity));
        }
    }
}
