using Microsoft.EntityFrameworkCore;
using Organization.Business.Services;
using Organization.Business.Translators;
using Organization.DAL.Models;
using Organization.DAL.Repositories;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrganizationContext>(options => options.
      UseSqlServer(builder.Configuration.GetConnectionString("OrganizationConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOrganizationContext, OrganizationContext>();
builder.Services.AddSingleton<IOrganizationTranslator, OrganizationTranslator>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();



var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My service");
    c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
