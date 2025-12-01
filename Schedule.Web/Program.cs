using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Ports;
using Schedule.Domain.Service;
using Schedule.Domain.UseCase;
using Schedule.Infrastructure.Database.Context;
using Schedule.Infrastructure.Repositories.DayRepository;
using Schedule.Infrastructure.Repositories.MealRepository;
using Schedule.Infrastructure.Repositories.UoWRepository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ScheduleContext>(opt 
    => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repos
builder.Services.AddScoped<IDayChecks, DayChecksRepository>();
builder.Services.AddScoped<IDayQueries, DayQueriesRepository>();
builder.Services.AddScoped<IMealCheck, MealChecksRepository>();
builder.Services.AddScoped<IMealCommands, MealCommandsRepository>();
builder.Services.AddScoped<IMealQueries, MealQueriesRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<ICheckDayAssignMeal, CheckDayAssignMeal>();
builder.Services.AddScoped<ICheckMealExistanceService, CheckMealExistanceService>();
builder.Services.AddScoped<ICreateMealService, CreateMealService>();
builder.Services.AddScoped<IGetAllMealsService, GetAllMealsService>();
builder.Services.AddScoped<IGetDayByNameService, GetDayByNameService>();
builder.Services.AddScoped<IGetMealByIdService, GetMealByIdService>();

// Use Cases
builder.Services.AddScoped<ICreateMealCase, CreateMealCase>();
builder.Services.AddScoped<IAssingMealCase, AssignMealCase>();
builder.Services.AddScoped<IGetAllMealsCase, GetAllMealsCase>();
builder.Services.AddScoped<IGetDayAssignationCase, GetDayAssignationCase>();
builder.Services.AddScoped<IGetAllWeekIngredients, GetAllWeekIngredients>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
 );

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
