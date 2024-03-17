using BlogApp.Data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogContext>(options => { // BlogContext DbContext'i oldugunu belirtir
    var connectionStr = builder.Configuration.GetConnectionString("mysql-connection"); // appsettings'ten str'yi alır
    //options.UseSqlite(connectionStr); // options ile veritabanı yapılandırılır, connectionStr erişimi sağlar

    var version = new MySqlServerVersion(new Version(8,0,36));
    options.UseMySql(connectionStr, version);
});

var app = builder.Build();

SeedData.CreateSeedData(app); // app başlangıcı ile seed datayı olustur

app.MapGet("/", () => "Hello World!");

app.Run();
