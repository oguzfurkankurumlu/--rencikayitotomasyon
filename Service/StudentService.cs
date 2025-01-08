using summerschool.DMO;
using summerschool.DTO;
using System.Collections.Generic;
using System.Linq;

public class StudentService : IStudentService
{
    private readonly SummerSchoolContext _context;

    // Constructor ile SummerSchoolContext enjekte ediliyor
    public StudentService(SummerSchoolContext context)
    {
        _context = context;
    }

    // Yeni öğrenci ekleme işlemi
    public bool AddStudent(StudentDTO newStudent)
    {
        var student = new TableStudent
        {
            Stname = newStudent.Stname,
            Stlastname = newStudent.Stlastname,
            Stnumber = newStudent.Stnumber,
            Stmail = newStudent.Stmail,
            Stbalance = newStudent.Stbalance
        };

        _context.TableStudents.Add(student);  // Öğrenci ekleme
        _context.SaveChanges();               // Değişiklikleri kaydetme
        return true;
    }

    // Öğrenci silme işlemi
    public bool DeleteStudent(int id)
    {
        var student = _context.TableStudents.FirstOrDefault(s => s.Stid == id);
        if (student != null)
        {
            _context.TableStudents.Remove(student);  // Öğrenciyi silme
            _context.SaveChanges();                  // Değişiklikleri kaydetme
            return true;
        }
        return false;
    }

    // Öğrencinin bakiyesini ekleme işlemi
    public bool AddBalance(int id, decimal amount)
    {
        var student = _context.TableStudents.FirstOrDefault(s => s.Stid == id);
        if (student != null)
        {
            student.Stbalance += amount;  // Bakiye ekleme
            _context.SaveChanges();      // Değişiklikleri kaydetme
            return true;
        }
        return false;
    }

    // Tüm öğrencileri alma işlemi
    public List<StudentDTO> GetAllStudents()
    {
        return _context.TableStudents
            .Select(s => new StudentDTO
            {
                Stid = s.Stid,
                Stname = s.Stname,
                Stlastname = s.Stlastname,
                Stnumber = s.Stnumber,
                Stmail = s.Stmail,
                Stbalance = s.Stbalance ?? 0
            })
            .ToList();
    }
}
