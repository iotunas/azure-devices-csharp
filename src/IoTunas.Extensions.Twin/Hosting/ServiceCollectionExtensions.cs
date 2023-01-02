namespace IoTunas.Extensions.Twin.Hosting;

using IoTunas.Extensions.Twin.Models;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddTwinServices<TDesired, TReported>(
        this IServiceCollection services,
        Action<ITwinServicesBuilder>? configureAction = null)
        where TDesired : class, IDesiredTwinModel
        where TReported : class, IReportedTwinModel
    {
        var builder = new TwinServiceBuilder();
        builder.SetDesiredTwinModel<TDesired>();
        builder.SetReportedTwinModel<TReported>();
        configureAction?.Invoke(builder);
        builder.AddDesiredTwinServices(services);
        builder.AddReportedTwinServices(services);
        return services;
    }

    public static IServiceCollection AddDesiredTwinOnly<TDesired>(
        this IServiceCollection services,
        Action<ITwinServicesBuilder>? configureAction = null)
        where TDesired : class, IDesiredTwinModel
    {
        var builder = new TwinServiceBuilder();
        builder.SetDesiredTwinModel<TDesired>();
        configureAction?.Invoke(builder);
        builder.AddDesiredTwinServices(services);
        return services;
    }

    public static IServiceCollection AddReporetedTwinOnly<TReported>(
        this IServiceCollection services,
        Action<ITwinServicesBuilder>? configureAction = null)
        where TReported : class, IReportedTwinModel
    {
        var builder = new TwinServiceBuilder();
        builder.SetReportedTwinModel<TReported>();
        configureAction?.Invoke(builder);
        builder.AddReportedTwinServices(services);
        return services;
    }

}
