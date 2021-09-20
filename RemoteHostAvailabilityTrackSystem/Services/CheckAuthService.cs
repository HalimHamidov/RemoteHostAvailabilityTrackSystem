using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    public class CheckAuthService : ICheckAuthService
    {
        private readonly IGetUsersRepository _getUsersRepository;

        public CheckAuthService(IGetUsersRepository getUsersRepository)
        {
            _getUsersRepository = getUsersRepository;
        }

        public async Task<long> CheckAuth(string key, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new Exception("User not authorized");
            var users = await _getUsersRepository.GetUsers(cancellationToken);
            var needUser =
                users.FirstOrDefault(q => string.Equals(q.Key, key, StringComparison.CurrentCultureIgnoreCase));
            if (needUser == null)
                throw new Exception("User not authorized");
            if (needUser.FinishKeyDate < DateTime.Now)
                throw new Exception("User is not authorized");

            return needUser.Id;
        }

    }
}
