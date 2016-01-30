namespace aspnet_logging_04_vs
{
    using Microsoft.Extensions.Logging;

    public class MyClass
    {
        private readonly ILogger<MyClass> _logger;

        public MyClass(ILogger<MyClass> logger)
        {
            _logger = logger;
        }

        public void DoSomething(int input)
        {
            _logger.LogDebug("Starting method {Method} with input: {Input}", nameof(DoSomething), input);

            if (input >= -1 && input <= 1)
            {
                _logger.LogInformation("Input of {Input} is within the optimal range.", input);
            }
            else if (input > 10)
            {
                _logger.LogWarning("Input of {Input} is greater than the typical range.", input);
            }
            else if (input < -10)
            {
                _logger.LogError("Input of {Input} is less than the typical range.", input);
            }

            _logger.LogDebug("Finished method {Method}", nameof(DoSomething));
        }
    }
}