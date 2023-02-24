using Api.Service;
using Api.Model;
using System.Security.Cryptography.X509Certificates;

namespace Api.Services
{
   public class StudentService : IStudentService
   {

      public IEnumerable<Student> GetAllStudents()
      {
         return new List<Student>()
         {
            new Student()
            {
               FirstName = "Dominique",
               LastName = "Karreman"
            },
             new Student()
            {
               FirstName = "Dominique",
               LastName = "Karreman"
            }

         };

      }
      public Student GetSpecificStudent(int id)
         {
         return new Student()
         {
            FirstName = "test",
            LastName = "last"
         };
         }
   }
}
