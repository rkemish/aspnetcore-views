// Build the WebApplication host using command-line arguments, appsettings.json,
// environment variables, and other default configuration sources.
var builder = WebApplication.CreateBuilder(args);

// Register MVC services so the app can serve controller actions that return Views.
builder.Services.AddControllersWithViews();

// Register the demo content service as a singleton so the same in-memory data is
// shared across all requests during the lifetime of the application.
builder.Services.AddSingleton<AspNetCoreViewsDemo.Web.Services.IDemoContentService, AspNetCoreViewsDemo.Web.Services.DemoContentService>();

var app = builder.Build();

// Configure the HTTP request pipeline (middleware order matters here).
if (!app.Environment.IsDevelopment())
{
    // In non-development environments, redirect unhandled exceptions to the error page
    // instead of showing the developer exception page.
    app.UseExceptionHandler("/Home/Error");

    // Enable HTTP Strict Transport Security (HSTS) so browsers always use HTTPS.
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirect all HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Add route-matching middleware so subsequent middleware can access route data.
app.UseRouting();

// Add the authorization middleware (required even if no [Authorize] attributes are
// used, to correctly place it relative to routing and endpoint execution).
app.UseAuthorization();

// Serve static files (CSS, JS, images) from wwwroot with content fingerprinting
// for optimal browser caching.
app.MapStaticAssets();

// Map the conventional MVC route: /{controller}/{action}/{id?}
// Defaults to HomeController.Index when no segments are provided.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets(); // Associates static asset fingerprinting with the route endpoints.

app.Run();
