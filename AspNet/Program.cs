var builder = WebApplication.CreateBuilder(args); // initialize instance of webappbuilder

// Add services to the container, enabling app to use MVC patterns
builder.Services.AddControllersWithViews(); // registers MVC services needed for controllers and views

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build(); // uses configuration to build webapp instance

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.MapStaticAssets(); // enables wwwroot folder usage

app.UseRouting(); // enables http request routing

app.UseAuthorization(); // enables user authorization

// defines a default route for the app
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // run app, start listening for http requests
