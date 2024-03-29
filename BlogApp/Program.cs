using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options => { // BlogContext DbContext'i oldugunu belirtir
    var connectionStr = builder.Configuration.GetConnectionString("mysql-connection"); // appsettings'ten str'yi alır
    //options.UseSqlite(connectionStr); // options ile veritabanı yapılandırılır, connectionStr erişimi sağlar

    var version = new MySqlServerVersion(new Version(8,0,36));
    options.UseMySql(connectionStr, version);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.CreateSeedData(app); // app başlangıcı ile seed datayı olustur

// sabit kısım (posts) gördükte sonra eşleştirme yapacağı kısım;
app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",
    defaults: new {controller="Posts",action="Details"}
);

app.MapControllerRoute(
    name: "post_by_tag",
    pattern: "posts/tag/{url}",
    defaults: new {controller="Posts",action="Index"}
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
