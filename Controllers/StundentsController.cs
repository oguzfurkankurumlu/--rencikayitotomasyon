using Microsoft.AspNetCore.Mvc;
using summerschool.DMO;
using System.Linq;

public class StudentsController : Controller
{
    private readonly SummerSchoolContext _context;

    public StudentsController(SummerSchoolContext context)
    {
        _context = context;
    }


    // Yeni öğrenci ekleme formu için
    public IActionResult AddStudent()
    {
        return View();
    }

    // Yeni öğrenci ekleme işlemi için (HTTP POST)
    [HttpPost]
    public IActionResult AddStudent(TableStudent newStudent)
    {
        if (ModelState.IsValid)
        {
            _context.TableStudents.Add(newStudent); // Öğrenciyi veritabanına ekler
            _context.SaveChanges(); // Değişiklikleri kaydeder
            return RedirectToAction("Index"); // Listeleme sayfasına yönlendirir
        }

        return View(newStudent); // Hatalı formu tekrar göster
    }

    public IActionResult StudentTable()
    {
        var students = _context.TableStudents.ToList(); // Tüm öğrencileri al
        return View(students); // StudentTable.cshtml sayfasına gönder
    }


    public IActionResult Index()
    {
        var students = _context.TableStudents.ToList();
        return View(students);
    }
}