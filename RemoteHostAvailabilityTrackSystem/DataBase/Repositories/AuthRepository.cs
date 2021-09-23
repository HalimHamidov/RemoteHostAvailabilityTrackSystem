using System;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    /// <inheritdoc />
    public class AuthRepository : IAuthRepository
    {
        private readonly Func<DataContext> _contextFactory;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="contextFactory"></param>
        public AuthRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        /// <inheritdoc />
        public async Task Auth(UserModel userModel, CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();
            context.Update(userModel);
            await context.SaveChangesAsync(cancellationToken);

        }
    }
}
