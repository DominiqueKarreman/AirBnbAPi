using Api.Model;

namespace Api.Repositories
{
   public interface ISchoolRepository
   {
      public IEnumerable<Student> GetAllStudents();

      public Student GetStudent(int id);
      public IEnumerable<string> GetAllTeachers();
      public string GetTeacher(int id);
   }
}
