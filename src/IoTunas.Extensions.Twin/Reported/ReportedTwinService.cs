namespace IoTunas.Extensions.Twin.Reported;

using IoTunas.Extensions.Twin.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

public class ReportedTwinService : IHostedService
{

    private readonly IServiceProvider provider;

    public ReportedTwinService(IServiceProvider provider)
    {
        this.provider = provider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var model = provider.GetRequiredService<IReportedTwinModel>();
        var mediator = provider.GetRequiredService<IReportedTwinMediator>();
        model.PropertyChanging += mediator.HandlePropertyChanging;
        model.PropertyChanged += mediator.HandlePropertyChanged;
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        var model = provider.GetRequiredService<IReportedTwinModel>();
        var mediator = provider.GetRequiredService<IReportedTwinMediator>();
        model.PropertyChanging -= mediator.HandlePropertyChanging;
        model.PropertyChanged -= mediator.HandlePropertyChanged;
        return Task.CompletedTask;
    }

}
