using AspNet.Services;

var builder = WebApplication.CreateBuilder(args); // initialize instance of webappbuilder

// Add services to the container, enabling app to use MVC patterns
builder.Services.AddControllersWithViews(); // registers MVC services needed for controllers and views

// register default and custom defined Services for our app
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Dependency Injection: register services to be used in controllers
builder.Services.AddSingleton<IProfileService,  ProfileService>(); // here we use AddSingleton because we only want my profile to be displayed, so a single instance of our service is shared throughout the app's lifetime
builder.Services.AddScoped<IProductService, ProductService>(); // here we use AddScoped because we want a new instance of our service to be created for each request

// Add authentication with cookie-based authentication, so the browser can remember user sessions
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Redirect to login page
        options.AccessDeniedPath = "/"; // Redirect to home page if access is denied
    });

// Add authorization services to the app
builder.Services.AddAuthorization();


var app = builder.Build(); // uses configuration to build webapp instance

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.MapStaticAssets(); // enables wwwroot folder usage

app.UseRouting(); // enables http request routing

app.UseAuthentication(); // enables user authentication
app.UseAuthorization(); // enables user authorization

// defines a default route for the app
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // run app, start listening for http requests
