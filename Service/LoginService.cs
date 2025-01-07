using Microsoft.EntityFrameworkCore;
using summerschool.DMO;

public class LoginService
{
    private readonly UserLoginRepository _userLoginRepository;

    public LoginService(UserLoginRepository userLoginRepository)
    {
        _userLoginRepository = userLoginRepository;
    }

    // Mail ve Şifreye göre kullanıcıyı sorgulama
    public TableStudent Login(string mail, string password)
    {
        // UserLoginRepository üzerinden sorgu yapıyoruz
        return _userLoginRepository.Login(mail, password);
    }
}
