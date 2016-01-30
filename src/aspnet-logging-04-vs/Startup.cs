namespace aspnet_logging_04_vs
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Serilog;

    public class Startup
    {
        public Startup()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.EventLog("Serilog App")
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyClass>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;

            loggerFactory.AddSerilog();

            app.UseIISPlatformHandler();

            app.Run(async context =>
            {
                var myClass = context.RequestServices.GetService<MyClass>();

                myClass.DoSomething(1);
                myClass.DoSomething(20);
                myClass.DoSomething(-20);

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}