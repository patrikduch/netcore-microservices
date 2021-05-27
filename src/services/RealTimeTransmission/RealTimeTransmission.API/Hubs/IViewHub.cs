using System.Linq;
using System.Threading.Tasks;

namespace RealTimeTransmission.API.Hubs
{
    public interface IViewHub
    {
        Task ViewCountUpdate(int viewCount);
    }
}
