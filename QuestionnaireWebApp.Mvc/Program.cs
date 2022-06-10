using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuestionnaireWebApp.Core;
using QuestionnaireWebApp.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<QuestionnaireContext>(x => x.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Если в проекте используется EFCore то нужно при Сериализации исключать циклическую зависимость
JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
{
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
};

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();