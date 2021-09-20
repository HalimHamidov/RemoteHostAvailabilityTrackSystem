﻿using System.Threading;
using System.Threading.Tasks;

namespace RemoteHostAvailabilityTrackSystem.Services.Interfaces
{
    public interface IAddUserService
    {
        Task AddUser(string login, string password, CancellationToken cancellationToken);
    }
}