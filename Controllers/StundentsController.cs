using Microsoft.AspNetCore.Mvc;
using summerschool.DMO;
using summerschool.DTO;

public class StudentsController : Controller
{
    private readonly IStudentService _studentService; // IStudentService ile iletişim kuracağız

    // Constructor ile IStudentService enjekte et
    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService; // IStudentService'yi al
    }

    // Yeni öğrenci ekleme formu
    public IActionResult AddStudent()
    {
        return View();
    }

    // Yeni öğrenci ekleme işlemi (HTTP POST)
    [HttpPost]
    public IActionResult AddStudent(StudentDTO newStudent)
    {
        if (ModelState.IsValid)
        {
            var success = _studentService.AddStudent(newStudent); // Servis katmanına delegasyon
            if (success)
                return RedirectToAction("Index"); // Listeleme sayfasına yönlendir
            else
                ModelState.AddModelError("", "Öğrenci eklenemedi.");
        }
        return View(newStudent); // Hatalı formu tekrar göster
    }

    // Öğrenci silme işlemi
    [HttpPost]
    public IActionResult DeleteStudent(int id)
    {
        if (_studentService.DeleteStudent(id)) // Servis katmanında silme işlemi
        {
            return RedirectToAction("Index");
        }
        return Json(new { success = false, message = "Öğrenci bulunamadı." });
    }

    // Öğrenciye bakiye ekleme işlemi
    [HttpPost]
    public IActionResult AddBalance(int id, decimal amount)
    {
        if (_studentService.AddBalance(id, amount)) // Servis katmanına delegasyon
        {
            return RedirectToAction("Index");
        }
        return Json(new { success = false, message = "Öğrenci bulunamadı." });
    }

    // Öğrenci listesi
    public IActionResult Index()
    {
        var students = _studentService.GetAllStudents(); // Servisten tüm öğrencileri al
        return View(students); // Öğrenci listesine gönder
    }
}
