using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var dbVersion = new MySqlServerVersion(new Version(8, 0, 40));
var connString = builder.Configuration.GetConnectionString("MariaDB_ConnectionString");

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MariaDBContext>(options => options
        .UseMySql(connString, dbVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    );
}
else
{
    builder.Services.AddDbContext<MariaDBContext>(options => options
        .UseMySql(connString, dbVersion)
    );
}

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var contextDependency = services.GetRequiredService<MariaDBContext>();
    contextDependency.Database.EnsureCreated();
}

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
