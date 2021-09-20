using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    public class GetUsersRepository : IGetUsersRepository
    {
        private readonly Func<DataContext> _contextFactory;

        public GetUsersRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ICollection<UserModel>> GetUsers(CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();

            var result = await context.UserModels.ToListAsync(cancellationToken);
            return result;
        }
    }
}
