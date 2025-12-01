using Moq;
using Schedule.Domain.Entities;
using Schedule.Domain.Ports;
using Schedule.Domain.Service;
using Schedule.Domain.UseCase;

namespace Schedule.Test;

public class MealAssignationTest
{
    [Fact]
    public async Task CorrectAssignation()
    {
        var checkMeal = new Mock<ICheckMealExistanceService>();
        var getDayByName = new Mock<IGetDayByNameService>();
        var uow = new Mock<IUnitOfWork>();


        var day = new Day
        {
            DayId = 1,
            DayName = "lunes",
            AssignedMeal = null
        };

        checkMeal
            .Setup(s => s.Exists(1))
            .ReturnsAsync(1);

        getDayByName
            .Setup(s => s.GetDayByName("lunes"))
            .ReturnsAsync(day);

        uow
            .Setup(u => u.SaveChangesAsync())
            .Returns(Task.CompletedTask);


        var useCase = new AssignMealCase
        (
            checkMeal.Object,
            getDayByName.Object,
            uow.Object
        );

        var result = await useCase.AssingMealCase(1, "lunes");

        Assert.Equal(1, result.DayId);
        Assert.Contains("lunes", result.AssignationDay);
        Assert.Equal(1, day.AssignedMeal);
        uow.Verify(s => s.SaveChangesAsync(), Times.Once);
    }


    [Fact]
    public async Task ErrorByDayWithAssignation()
    {
        var checkMeal = new Mock<ICheckMealExistanceService>();
        var getDayByName = new Mock<IGetDayByNameService>();
        var uow = new Mock<IUnitOfWork>();

        var day = new Day
        {
            DayId = 1,
            DayName = "lunes",
            AssignedMeal = 5
        };

        checkMeal
            .Setup(s => s.Exists(1))
            .ReturnsAsync(1);

        getDayByName
            .Setup(s => s.GetDayByName("lunes"))
            .ReturnsAsync(day);

        uow
            .Setup(u => u.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        var useCase = new AssignMealCase
        (
            checkMeal.Object,
            getDayByName.Object,
            uow.Object
        );


        await Assert.ThrowsAsync<Exception>(() => useCase.AssingMealCase(1, "lunes"));

        uow.Verify(s => s.SaveChangesAsync(), Times.Never);
    }


    [Fact]
    public async Task ErrorByIncorrectMeal()
    {
        var checkMeal = new Mock<ICheckMealExistanceService>();
        var getDayByName = new Mock<IGetDayByNameService>();
        var uow = new Mock<IUnitOfWork>();

        var day = new Day
        {
            DayId = 1,
            DayName = "lunes",
            AssignedMeal = null
        };

        checkMeal
            .Setup(s => s.Exists(5))
            .ThrowsAsync(new Exception("Meal no existe"));

        getDayByName
            .Setup(s => s.GetDayByName("lunes"))
            .ReturnsAsync(day);

        uow
            .Setup(u => u.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        var useCase = new AssignMealCase
        (
            checkMeal.Object,
            getDayByName.Object,
            uow.Object
        );


        var ex = await Assert.ThrowsAsync<Exception>(() => useCase.AssingMealCase(5, "lunes"));

        Assert.Contains("Meal no existe", ex.Message);
        uow.Verify(s => s.SaveChangesAsync(), Times.Never);
    }
}
