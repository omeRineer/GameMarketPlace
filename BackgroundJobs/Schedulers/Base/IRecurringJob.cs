using System.Threading.Tasks;

namespace BackgroundJobs.Schedulers.Base
{
    public interface IRecurringJob
    {
        Task Run();
    }
}
