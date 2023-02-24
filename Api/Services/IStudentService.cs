namespace Api.Service;
using Api.Model;


using System.Security.Cryptography.X509Certificates;

public interface IStudentService
   {


   public IEnumerable<Student> GetAllStudents();
   
   public Student GetSpecificStudent(int id);
   
   

}
