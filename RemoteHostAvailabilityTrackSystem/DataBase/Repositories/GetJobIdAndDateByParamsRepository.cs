using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    /// <inheritdoc />
    public class GetJobIdAndDateByParamsRepository : IGetJobIdAndDateByParamsRepository
    {
        private readonly Func<DataContext> _contextFactory;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="contextFactory"></param>
        public GetJobIdAndDateByParamsRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;

        }
        /// <inheritdoc />
        public async Task<(int, DateTime?)> GetId(string api, int? minutes, int? hours,
            CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();
            var result = (await context.CheckApiJobModels
                .FirstOrDefaultAsync(q=> q.Api == api && q.HoursInterval == hours && q.MinutesInterval == minutes,
                    cancellationToken));
            return (result.Id, result.LastRunDate);
        }
    }
}
