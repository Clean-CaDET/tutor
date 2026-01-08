using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class TokenWalletCommandTests : BaseCoursesIntegrationTest
{
    public TokenWalletCommandTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_wallet()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.Get(-1, -1).Result)?.Value as TokenWalletDto;

        result.ShouldNotBeNull();
        result.LearnerId.ShouldBe(-1);
        result.CourseId.ShouldBe(-1);
        result.TotalAllowance.ShouldBe(2000000);
        result.TotalSpent.ShouldBe(0);
        result.RemainingBalance.ShouldBe(2000000);
    }

    [Fact]
    public void Gets_wallet_with_spending()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.Get(-2, -1).Result)?.Value as TokenWalletDto;

        result.ShouldNotBeNull();
        result.LearnerId.ShouldBe(-2);
        result.CourseId.ShouldBe(-1);
        result.TotalAllowance.ShouldBe(2000000);
        result.TotalSpent.ShouldBe(150);
        result.RemainingBalance.ShouldBe(1999850);
    }

    [Fact]
    public void Deposits_tokens()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var depositDto = new TokenDepositDto
        {
            Amount = 100000,
            Reason = "Excellent progress"
        };

        var result = (OkResult)controller.Deposit(-1, -1, depositDto);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);

        var wallet = dbContext.TokenWallets.FirstOrDefault(w => w.LearnerId == -1 && w.CourseId == -1);
        wallet.ShouldNotBeNull();
        wallet.TotalAllowance.ShouldBe(2100000);
        wallet.RemainingBalance.ShouldBe(2100000);
    }

    [Fact]
    public void Fails_to_deposit_negative_amount()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var depositDto = new TokenDepositDto
        {
            Amount = -1000,
            Reason = "Invalid"
        };

        var result = (ObjectResult)controller.Deposit(-1, -1, depositDto);
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
    }

    private static TokenWalletController CreateController(IServiceScope scope)
    {
        return new TokenWalletController(scope.ServiceProvider.GetRequiredService<ITokenWalletService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}
