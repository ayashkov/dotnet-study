using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Configuration.AddJsonFile("etc/appsettings.conf", optional: true);

var app = builder.Build();
var options = new StaticFileOptions {
    FileProvider = new EmbeddedFileProvider(
        Assembly.Load(new AssemblyName("study.ui")), "study.ui.wwwroot")
};

app.UseStaticFiles(options);
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html", options);
app.Run();
