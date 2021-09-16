using System;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    public class AddResultCheckRepository : IAddResultCheckRepository
    {
        private readonly Func<DataContext> _contextFactory;

        public AddResultCheckRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddResult(CheckApiResult checkApiResult, CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();
            await context.CheckApiResults.AddAsync(checkApiResult, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}

