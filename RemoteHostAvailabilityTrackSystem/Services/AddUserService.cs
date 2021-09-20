using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    public class AddUserService : IAddUserService
    {
        private readonly IAddUserRepository _addUserRepository;
        private readonly IGetUsersRepository _getUsersRepository;

        public AddUserService(IAddUserRepository addUserRepository, IGetUsersRepository getUsersRepository)
        {
            _addUserRepository = addUserRepository;
            _getUsersRepository = getUsersRepository;
        }
        public async Task AddUser(string login, string password, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new Exception("login not filled");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("password not filled");
            var users = await _getUsersRepository.GetUsers(cancellationToken);
            if (users.FirstOrDefault(q => string.Equals(q.Login, login, StringComparison.CurrentCultureIgnoreCase)) !=
                null)
                throw new Exception("User with such login already exists");
            await _addUserRepository.AddUser(login, password, cancellationToken);

        }

    }

}
