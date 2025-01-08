using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using summerschool.DMO;
using System.Linq;

public class DashboardController : Controller
{
    private readonly SummerSchoolContext _context;

    // Constructor Dependency Injection ile SummerSchoolContext'i alıyoruz
    public DashboardController(SummerSchoolContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // ViewModel'e verileri yükleyelim
        var model = new DashboardViewModel
        {
            Students = _context.TableStudents.ToList(),
            Lessons = _context.TableLessons.ToList(),
            Teachers = _context.TableTeachers.ToList(),
            FormApplies = _context.FormApplies.ToList()
        };

        return View(model);
    }
}
