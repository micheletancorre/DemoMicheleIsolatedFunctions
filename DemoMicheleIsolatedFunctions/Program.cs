using DemoDunctionsIsolated.Interfaces;
using DemoDunctionsIsolated.Services;
using DemoFunctionsIsolated.Library;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<IClock, SystemClock>();
        services.AddScoped<IStudentsData, StudentsService>();
    })
    .Build();

host.Run();
