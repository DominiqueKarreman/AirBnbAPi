using Api.Data;
using Api.Model;
using Api.Repositories;
using Api.Service;

namespace Api.Services
{
   public class StudentDatabaseService : IStudentService
   {
      private readonly ISchoolRepository _schoolRepository;
      public StudentDatabaseService(ISchoolRepository schoolRepository)
      {
         _schoolRepository = schoolRepository;
      }



      public Student GetSpecificStudent(int id)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<Student> GetAllStudents()
      {
         return _schoolRepository.GetAllStudents();
      }

   }
}
