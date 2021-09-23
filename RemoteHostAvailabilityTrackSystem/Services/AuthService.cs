using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    /// <inheritdoc />
    public class AuthService : IAuthService
    {

        private readonly IGetUsersRepository _getUsersRepository;
        private readonly IAuthRepository _authRepository;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="getUsersRepository"></param>
        /// <param name="authRepository"></param>
        public AuthService(IGetUsersRepository getUsersRepository, IAuthRepository authRepository)
        {
            _getUsersRepository = getUsersRepository;
            _authRepository = authRepository;
        }
        /// <inheritdoc />
        public async Task<string> Auth(string login, string password, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new Exception("login not filled");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("password not filled");
            var users = await _getUsersRepository.GetUsers(cancellationToken);
            var needUser =
                users.FirstOrDefault(q => q.Login.ToLower() == login.ToLower());
            if (needUser == null)
                throw new Exception("User not found");
            if (needUser.FinishKeyDate != null && needUser.FinishKeyDate >= DateTime.Now)
                return needUser.Key;

            needUser.Key = Guid.NewGuid().ToString();
            needUser.FinishKeyDate = DateTime.Now.AddHours(1);

            await _authRepository.Auth(needUser, cancellationToken);

            users = await _getUsersRepository.GetUsers(cancellationToken);
            needUser = users.FirstOrDefault(q => q.Login.ToLower() == login.ToLower());
            return needUser?.Key;
        }
    }
}
