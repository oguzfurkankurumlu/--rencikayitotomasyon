
Uygulamaların veri tabanına bağlanması 4 farklı şekilde olmaktadır

 1 : Ado.net (eski bir yöntemdir, günümüzde hantal kalmaktadır)
 2 : Entity Framework Code First(Bu yöntemde veri tabanı yoktur, veri tabanı oluşturma c# tarafında yazılan kodlarla olur)
 3 : Entity Framework DbFirst (Bu yöntemde, veri tabanı vardır ve bu veri tabanına yazılım tarafından ulaşmak ve kullanmak için bazı yöntemler uygulanır!!)
 4 : Dapper diye bir yöntem vardır, Kolay ve basit bir pakettir, Hızlı şekilde veri tabanına bağlanmak için kullanılır(Dapper arka planda, Ado.net kullanmaktadır)


Örnek DBFirst örneği olacaktır, mevcutta olan bir veri tabanının içerisindeki tüm kolonları,
c# tarafında dmo modele çevirecek bir komut ile bu işlem yapılır!!


dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0

--------------------------------------------------------------------------------------------------------------------------
DATABASEIM LOCALDE.
appsetings.json

     "ConnectionStrings": {
    "DefaultConnection":" "Server=localhost; Database=SummerSchool; Trusted_Connection=True; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;"
    }

-------------------------------------------------------------------------------------------------------------------------
        
Vs Code’da terminale yazılabilir
proje kaydedıldıkten sonra 
terminale;
dotnet ef dbcontext scaffold "Name=DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer -o DMO   

-------------------------------------------------------------------------------------------------------------------------

builder.Services.AddDbContext<SummerSchoolContext>(options=>{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

-------------------------------------------------------------------------------------------------------------------------
