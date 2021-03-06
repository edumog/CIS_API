using CIS.Db;
using CIS.Interfaces;
using CIS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<ApplicationDbContext>(opt => opt.UseSqlServer(@"Data Source=DESKTOP-T6PJIPS\SQLEXPRESS;Initial Catalog=CMR;Integrated Security=True"));
builder.Services.AddScoped<StandardizationContract, StandardizationService>();
builder.Services.AddScoped<ICrmCampaignDb, CrmCampaigns>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
