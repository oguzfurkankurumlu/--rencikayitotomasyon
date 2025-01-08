
namespace summerschool.DTO
{
    public class StudentDTO
    {
        public int Stid { get; set; }
        public string Stname { get; set; }
        public string Stlastname { get; set; }
        public string Stnumber { get; set; }
        public string Stmail { get; set; }
        public decimal Stbalance { get; set; }
    }



    public interface IStudentService
    {
        bool AddStudent(StudentDTO newStudent);
        bool DeleteStudent(int id);
        bool AddBalance(int id, decimal amount);
        List<StudentDTO> GetAllStudents();
    }
}