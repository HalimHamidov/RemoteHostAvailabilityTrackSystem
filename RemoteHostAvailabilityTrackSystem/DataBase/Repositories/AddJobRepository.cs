using System;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    /// <inheritdoc />
    public class AddJobRepository : IAddJobRepository
    {
        private readonly Func<DataContext> _contextFactory;
        /// <summary>
        /// .ctor
        /// </summary>
        public AddJobRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <inheritdoc />
        public async Task Add(CheckApiJobModel request, CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();
            await context.CheckApiJobModels.AddAsync(request, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
