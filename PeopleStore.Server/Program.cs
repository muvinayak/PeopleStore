using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PeopleStore.Server.Data;
using PeopleStore.Server.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var connection = string.Empty;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// Add services to the Dependency Injection container.
builder.Services.AddAuthorization();
builder.Services.AddControllers().AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");
connection = builder.Configuration.GetConnectionString("peopleStoreDBConn");

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connection));

builder.Services.AddScoped<ProductsService>();
builder.Services.AddScoped<CategoriesService>();

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapSwagger().RequireAuthorization();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.MapFallbackToFile("/index.html");

app.Run();
