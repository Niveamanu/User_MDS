using Microsoft.EntityFrameworkCore;
using UserMDS.Data;
using UserMDS.Mappings;
using UserMDS.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<UserMDSDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("UserMDSDbConnection")));

builder.Services.AddScoped<IUserMDSRepository, UserMDSRepository>();

builder.Services.AddControllers();


builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddCors(corsOption => corsOption.AddPolicy(
    "ReportingCORSPolicy",
    corsBuilder =>
    {
        corsBuilder.WithOrigins("https://localhost:44338")
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader();

        corsBuilder.WithOrigins("http://bfadev-rfp.readypac.net")
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader();

        corsBuilder.WithOrigins("http://bfa-rfp.readypac.net")
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader();
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserMDS}/{action=Index}/{id?}");
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
