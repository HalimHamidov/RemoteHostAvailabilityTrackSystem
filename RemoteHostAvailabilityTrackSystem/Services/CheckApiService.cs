using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    public class CheckApiService : ICheckApiService
    {
        public async Task<CheckApiResponse> CheckApi(CheckApiRequest request, CancellationToken cancellationToken)
        {
            if (!Uri.IsWellFormedUriString(request.Api, UriKind.Absolute))
                return new CheckApiResponse
                {
                    IsValid = false
                };
            var uri = new Uri(request.Api);
            try
            {
                var httpWebRequest = WebRequest.Create(uri);
                await httpWebRequest.GetResponseAsync();
                return new CheckApiResponse
                {
                    IsValid = true
                };

            }
            catch
            {
                return new CheckApiResponse
                {
                    IsValid = false
                };
            }
        }
        
    }
}