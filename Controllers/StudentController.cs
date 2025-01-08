using Microsoft.AspNetCore.Mvc;
using summerschool.DMO;

public class StudentsController : Controller
{
    private readonly SummerSchoolContext _context;

    public StudentsController(SummerSchoolContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Tüm öğrencileri listelemek için
        var students = _context.TableStudents.ToList();
        return View(students);
    }
}
