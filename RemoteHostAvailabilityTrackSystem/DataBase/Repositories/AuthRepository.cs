using System;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Func<DataContext> _contextFactory;

        public AuthRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public async Task Auth(UserModel userModel, CancellationToken cancellationToken)
        {
            await using var context = _contextFactory();
            context.Update(userModel);
            await context.SaveChangesAsync(cancellationToken);

        }
    }
}
