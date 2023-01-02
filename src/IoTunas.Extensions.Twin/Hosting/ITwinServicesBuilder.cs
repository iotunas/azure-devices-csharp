namespace IoTunas.Extensions.Twin.Hosting;

using IoTunas.Extensions.Twin.Models;

public interface ITwinServicesBuilder
{

    void SetDesiredTwinModel<TDesired>(
        TDesired? initialModel = null)
        where TDesired : class, IDesiredTwinModel;

    void SetReportedTwinModel<TReported>(
        TReported? initialModel = null)
        where TReported : class, IReportedTwinModel;

}
