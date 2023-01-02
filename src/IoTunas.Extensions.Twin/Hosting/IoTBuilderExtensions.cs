namespace IoTunas.Extensions.Twin.Hosting;

using IoTunas.Core.DependencyInjection;
using IoTunas.Extensions.Twin.Models;

public static class IoTBuilderExtensions
{

    public static void UseTwinServices<TDesired, TReported>(
        this IIoTBuilder iotBuilder,
        Action<ITwinServicesBuilder>? configureAction = null)
        where TDesired : class, IDesiredTwinModel
        where TReported : class, IReportedTwinModel
    {
        iotBuilder.Services.AddTwinServices<TDesired, TReported>(configureAction);
    }

    public static void UseDesiredTwin<TDesired>(
        this IIoTBuilder iotBuilder)
        where TDesired : class, IDesiredTwinModel
    {
        iotBuilder.Services.AddDesiredTwinOnly<TDesired>();
    }

    public static void UseReportedTwin<TReported>(
        this IIoTBuilder iotBuilder)
        where TReported : class, IReportedTwinModel
    {
        iotBuilder.Services.AddReporetedTwinOnly<TReported>();
    }

}
