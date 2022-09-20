using Microsoft.EntityFrameworkCore;
using PatelHiren_Assignment3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<Initializer>();
builder.Services.AddScoped<IMemberRepository, DbMemberRepository>();
builder.Services.AddScoped<IClassRepository, DbClassRepository>();
builder.Services.AddScoped<IMemberClassRepository, DbMemberClassRepository>();


var app = builder.Build();
SeedData(app);

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
    pattern: "{controller=Home}/{action=Index}/{id?}/{classId?}");

app.Run();

static void SeedData(WebApplication app)
{
	using var scope = app.Services.CreateScope();
	var services = scope.ServiceProvider;
	try
	{
		var initializer = services.GetRequiredService<Initializer>();
		initializer.SeedDatabase();
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError($"An error occurred while seeding the database: {ex.Message}");
	}
}
