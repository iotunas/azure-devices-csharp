namespace IoTunas.Extensions.Twin.Desired;
using Microsoft.Azure.Devices.Shared;
using System.Threading.Tasks;

public interface IDesiredTwinMediator
{

    Task HandlePropertyUpdate(
        TwinCollection desiredProperties,
        object userContext);

}
