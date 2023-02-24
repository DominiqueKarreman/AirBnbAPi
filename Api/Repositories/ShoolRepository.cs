using Api.Data;
using Api.Model;

namespace Api.Repositories
{
   public class ShoolRepository : ISchoolRepository
   {
      private readonly ApiContext _context;
      public ShoolRepository(ApiContext context)
      {
         _context = context;
      }
      public IEnumerable<Student> GetAllStudents()
      {
         return _context.Student.ToList();
      }

      public IEnumerable<string> GetAllTeachers()
      {
         throw new NotImplementedException();
      }

      public Student GetStudent(int id)
      {
         throw new NotImplementedException();
      }

      public string GetTeacher(int id)
      {
         throw new NotImplementedException();
      }
   }
}
