using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    public class GetJobsRepository : IGetJobsRepository
    {
        private readonly Func<DataContext> _contextFactory;

        public GetJobsRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();

            var result = await context.CheckApiJobModels.ToListAsync(cancellationToken);
            return result;
        }
    }
}
