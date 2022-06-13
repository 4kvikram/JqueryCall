var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors();



builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddRazorPages()
//    .AddRazorRuntimeCompilation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");


app.Run();
