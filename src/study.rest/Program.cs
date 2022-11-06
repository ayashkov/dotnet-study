using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// https://stackoverflow.com/questions/36198633/include-wwwroot-from-a-library-project
app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new EmbeddedFileProvider(
        Assembly.Load(new AssemblyName("study.ui")), "study.ui.wwwroot")
});
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html");
app.Run();
