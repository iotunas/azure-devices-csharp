namespace IoTunas.Extensions.Twin.Hosting;

using IoTunas.Extensions.Twin.Desired;
using IoTunas.Extensions.Twin.Models;
using IoTunas.Extensions.Twin.Reported;
using Microsoft.Extensions.DependencyInjection;

public class TwinServiceBuilder : ITwinServicesBuilder
{

    private Type? desiredTwinModelType;
    private IDesiredTwinModel? desiredTwinInitialModel;

    private Type? reportedTwinModelType;
    private IReportedTwinModel? reportedTwinInitialModel;

    internal void SetDesiredTwinModel(
        Type desiredTwinModelType, 
        IDesiredTwinModel? desiredTwinInitialModel = null)
    {
        this.desiredTwinModelType = desiredTwinModelType;
        this.desiredTwinInitialModel = desiredTwinInitialModel;
    }

    public void SetDesiredTwinModel<TDesired>(
        TDesired? desiredTwinInitialModel = null)
        where TDesired : class, IDesiredTwinModel
    {
        desiredTwinModelType = typeof(TDesired);
        this.desiredTwinInitialModel = desiredTwinInitialModel;
    }

    internal void SetReportedTwinModel(
        Type reportedTwinModelType,
        IReportedTwinModel? reportedTwinInitialModel = null)
    {
        this.reportedTwinModelType = reportedTwinModelType;
        this.reportedTwinInitialModel = reportedTwinInitialModel;
    }

    public void SetReportedTwinModel<TReported>(
        TReported? reportedTwinInitialModel = null)
        where TReported : class, IReportedTwinModel
    {
        reportedTwinModelType = typeof(TReported);
        this.reportedTwinInitialModel = reportedTwinInitialModel;
    }

    public void AddDesiredTwinServices(IServiceCollection services)
    {
        if(desiredTwinModelType != null)
        {
            if (desiredTwinInitialModel == null)
            {
                services.AddSingleton(desiredTwinModelType);
            }
            else
            {
                services.AddSingleton(desiredTwinModelType, desiredTwinInitialModel);
            }
            services.AddSingleton<IDesiredTwinModel>(provider =>
                provider.GetService(desiredTwinModelType) as IDesiredTwinModel ??
                    throw new InvalidCastException());
            services.AddSingleton<IDesiredTwinMediator, DesiredTwinMediator>();
        }
    }

    public void AddReportedTwinServices(IServiceCollection services)
    {
        if (reportedTwinModelType != null)
        {
            if (reportedTwinInitialModel == null)
            {
                services.AddSingleton(reportedTwinModelType);
            }
            else
            {
                services.AddSingleton(reportedTwinModelType, reportedTwinInitialModel);
            }
            services.AddSingleton<IReportedTwinModel>(provider =>
                provider.GetService(reportedTwinModelType) as IReportedTwinModel ??
                    throw new InvalidCastException());
            services.AddSingleton<IReportedTwinMediator, ReportedTwinMediator>();
        }
    }

}