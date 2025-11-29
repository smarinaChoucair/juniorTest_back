using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Service;
using Schedule.Domain.UseCase;
using Schedule.Infrastructure.Database.Context;
using Schedule.Infrastructure.Repositories.AssignationRepository;
using Schedule.Infrastructure.Repositories.MealRepository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ScheduleContext>(opt 
    => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repos
builder.Services.AddScoped<ICreateMealRepository, CreateMealRepository>();
builder.Services.AddScoped<IGetMealByIdRepository, GetMealByIdRepository>();
builder.Services.AddScoped<ICreateAssignationRepository, CreateAssignationRepository>();
builder.Services.AddScoped<IGetAssignatedDaysByIdRepository, GetAssignatedDaysByIdRepository>();
builder.Services.AddScoped<IGetAllMealsRepository, GetAllMealsRepository>();

// Services
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IAssignationService, AssignationService>();

// Use Cases
builder.Services.AddScoped<ICreateMealCase, CreateMealCase>();
builder.Services.AddScoped<IAssingExistingMealCase, AssingExistingMealCase>();
builder.Services.AddScoped<IGetDayAssignationCase, GetDayAssignationCase>();
builder.Services.AddScoped<IGetAllWeekIngredients, GetAllWeekIngredients>();
builder.Services.AddScoped<IGetAllMealsCase, GetAllMealsCase>();


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
