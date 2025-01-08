using Microsoft.EntityFrameworkCore;
using summerschool.DMO;
using summerschool.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UserLoginRepository>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<StudentService>();  // StudentService sınıfını DI container'a ekle
builder.Services.AddScoped<IStudentService, StudentService>(); // IStudentService ve StudentService'i DI konteynerine ekleyin











//veri tabanını(context)i dp ekleyelım 
builder.Services.AddDbContext<SummerSchoolContext>(options=>{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

// eğer external dosyadan almak istemezseniz connection string bilgisini aşağıdaki şekilde de verebilirsiniz
// options.UseSqlServer("Server=db11596.public.databaseasp.net; Database=db11596; User Id=db11596; Password=i#5G!Tc2p6J+; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
