using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using pobreTITO_Models;
using pobreTITO_Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PobretitoDbContext>(options => options.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

builder.Services.AddIdentity<User, IdentityRole>(options =>
        { 
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 0;        
        }    
    ).AddEntityFrameworkStores<PobretitoDbContext>();

builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri("http://localhost:1337")
    });

var app = builder.Build();

UserService.SetManagers(app);
UserService.SetContext(app);

ReportService.SetContext(app);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "RegisterUser",
    pattern: "{controller=Home}/{action=Create}");


    

app.MapDefaultControllerRoute();
app.MapBlazorHub();

app.Run();
