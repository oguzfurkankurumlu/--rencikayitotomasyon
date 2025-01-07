using System.Linq;
using summerschool.DMO;
using Microsoft.EntityFrameworkCore;

public class UserLoginRepository
{
    private readonly SummerSchoolContext _context;

    public UserLoginRepository(SummerSchoolContext context)
    {
        _context = context;
    }

    // Mail ve Şifreye göre kullanıcıyı sorgulama
    public TableStudent Login(string mail, string password)
    {
        return _context.TableStudents
                       .FirstOrDefault(s => s.Stmail == mail && s.Stpassword == password);
    }
}
