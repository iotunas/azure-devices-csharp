namespace IoTunas.Extensions.Twin.Reported;
using System.ComponentModel;

public interface IReportedTwinMediator
{

    void HandlePropertyChanged(
        object? sender,
        PropertyChangedEventArgs args);

    void HandlePropertyChanging(
        object? sender,
        PropertyChangingEventArgs args);

}
