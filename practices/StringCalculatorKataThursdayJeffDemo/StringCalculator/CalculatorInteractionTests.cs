
namespace StringCalculator;

public class CalculatorInteractionTests
{

    [Fact]
    public void CalculatorLogsResponse()
    {
        // Mocks record the calls, and you verify them and that is what decides if the test passes or not.
        var mockedLogger = Substitute.For<ILogStringCalculations>();
        var maint = Substitute.For<IProvideMaintenencNotifications>();
        var calculator = new Calculator(mockedLogger, maint); // ??

        calculator.Add("1,2,3");

        // I want to make sure "6" was written to the log.
        mockedLogger.Received().LogResult("6");

        maint.DidNotReceive().NotifyOfStringCalculatorFailure(Arg.Any<string>());
    }

    [Fact]
    public void WebServiceIsCalledIfLoggerFails()
    {
        var stubbedLogger = Substitute.For<ILogStringCalculations>();
        var maint = Substitute.For<IProvideMaintenencNotifications>();
        var calculator = new Calculator(stubbedLogger, maint);
        stubbedLogger.When(l => l.LogResult(Arg.Any<String>())).Throws<InvalidOperationException>();

        calculator.Add("1");

        maint.Received(1).NotifyOfStringCalculatorFailure("Broke!");


    }

}
