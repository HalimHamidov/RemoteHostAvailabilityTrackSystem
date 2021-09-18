using System.Threading.Tasks;
using Quartz;

namespace RemoteHostAvailabilityTrackSystem.Jobs.Interfaces
{
    public interface ICheckApiJob
    {
        public Task Execute(IJobExecutionContext context);
    }
}
