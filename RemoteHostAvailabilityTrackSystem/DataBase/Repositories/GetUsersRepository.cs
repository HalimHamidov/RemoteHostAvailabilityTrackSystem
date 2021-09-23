using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    /// <inheritdoc />
    public class GetUsersRepository : IGetUsersRepository
    {
        private readonly Func<DataContext> _contextFactory;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="contextFactory"></param>
        public GetUsersRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        /// <inheritdoc />
        public async Task<ICollection<UserModel>> GetUsers(CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();

            var result = await context.UserModels.ToListAsync(cancellationToken);
            return result;
        }
    }
}
