using System.Threading.Tasks;

namespace RealTimeTransmission.API.Hubs
{
    /// <summary>
    /// Contract for SignalR <seealso cref="ViewHub"/>.
    /// </summary>
    public interface IViewHub
    {
        Task ViewCountUpdate(int viewCount);
    }
}
