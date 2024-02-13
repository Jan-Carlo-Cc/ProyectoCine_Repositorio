using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AplicacionCine.Data;
using AplicacionCine.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AplicacionCineContextConnection") ?? throw new InvalidOperationException("Connection string 'AplicacionCineContextConnection' not found.");

builder.Services.AddDbContext<AplicacionCineContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AplicacionCineUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AplicacionCineContext>();

//Aqui se inyectan servicios al contenedor 
builder.Services.AddControllersWithViews();

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

app.MapRazorPages();

app.Run();
