using Assignment_1_Exam_Week_1.Data;
using Assignment_1_Exam_Week_1.Models;
using Assignment_1_Exam_Week_1.Services;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(@"Data Source=.;Initial Catalog=AspDotNetCoreCourse;Trusted_Connection=True;TrustServerCertificate=True;"));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Configuration.GetSection("MailSettings").Get<MailSettings>();

builder.Services.AddTransient<IEmailService, EmailService>();

var app = builder.Build();

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
    pattern: "{controller=Registration}/{action=Index}/{id?}");

app.Run();
