using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    /// <inheritdoc />
    public class UpdateRunDateJobRepository : IUpdateRunDateJobRepository
    {
        private readonly Func<DataContext> _contextFactory;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="contextFactory"></param>
        public UpdateRunDateJobRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        /// <inheritdoc />
        public async Task UpdateRunDate(int jobId, DateTime newRunDate, CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();
            var job = await context.CheckApiJobModels.FirstOrDefaultAsync(q => q.Id == jobId, cancellationToken);
            job.LastRunDate = newRunDate;
            context.Update(job);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
