using System;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.DataBase.Repositories
{
    public class AddUserRepository : IAddUserRepository
    {
        private readonly Func<DataContext> _contextFactory;

        public AddUserRepository(Func<DataContext> contextFactory)
        {
            _contextFactory = contextFactory;

        }

        public async Task AddUser(string login, string password, CancellationToken cancellationToken)
        {
            var user = new UserModel
            {
                Login = login,
                Password = password
            };

            await using var context = _contextFactory();
            await context.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
