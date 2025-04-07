using _02_MVC.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Appsettingteki Connection Stringimin Eklenmesi
var connectionString = builder.Configuration.GetConnectionString("UrunConnection");

var app = builder.Build();

//Eklenen ConnectionString'in SQL Server Ile Baglantısının Saglanması
builder.Services.AddDbContext <UrunDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
