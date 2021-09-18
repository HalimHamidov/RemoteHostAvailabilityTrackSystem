using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Responses;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    public class GetCheckAllResultRepository : IGetCheckAllResultRepository
    {
        private readonly Func<DataContext> _contextFactory;

        public GetCheckAllResultRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ICollection<GetCheckInPeriodResponse>> GetAll(CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();

            var result = await context
                .CheckApiResults
                .Join(context.CheckApiJobModels, r => r.CheckApiJobId, j => j.Id, (r, j) => new GetCheckInPeriodResponse
                {
                    Api = j.Api,
                    Date = r.RunDate,
                    IsValid = r.IsValid
                })
                .ToListAsync(cancellationToken);
            return result;
        }
 
    }
}