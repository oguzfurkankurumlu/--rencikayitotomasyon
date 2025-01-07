using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }

    // Giriş ekranını getiren metot
    public IActionResult Index()
    {
        return View(); // Login formunu gösterecek
    }

    // Giriş işlemi yapan metot
    [HttpPost]
    public IActionResult Index(string mail, string password)
    {
        var user = _loginService.Login(mail, password);

        if (user != null)
        {
            // Giriş başarılı, yönlendirme yapılabilir
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // Giriş başarısız
            ViewBag.ErrorMessage = "E-posta adresi veya şifre yanlış.";
            return View();  // Login sayfasını tekrar göster
        }
    }
}
