using DataAccess;
using DataAccess.BlogData;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Web.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
// Add logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog();

// Add DB access
builder.Services.AddDbContext<DataContext>(options =>
{
    var configurationString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlServer(configurationString);
});
builder.Services.AddTransient<ArticleAccess>();

// Add identity
builder.Services.AddIdentitySettings();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.Cookie.Name = "Authentication";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
