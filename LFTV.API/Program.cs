using FluentValidation;
using LFTV.Application.Interfaces;
using LFTV.Application.Services;
using LFTV.Domain.Interfaces;
using LFTV.Infrastructure.Data;
using LFTV.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using LFTV.Infrastructure.Repositories.LFTV.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<LFTVDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

#if DEBUG
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
#endif
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProgramContentRepository, ProgramContentRepository>();
builder.Services.AddScoped<IEmissionRepository, EmissionRepository>();
builder.Services.AddScoped<ICalendarEntryRepository, CalendarEntryRepository>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<IProgramContentService, ProgramContentService>();
builder.Services.AddScoped<IEmissionService, EmissionService>();
builder.Services.AddScoped<ICalendarEntryService, CalendarEntryService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();



app.UseHttpsRedirection();
// Utilisez CORS
app.UseCors("AllowAll");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
