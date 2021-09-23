using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RemoteHostAvailabilityTrackSystem.DataBase.Models;
using RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces;
using RemoteHostAvailabilityTrackSystem.Requests;
using RemoteHostAvailabilityTrackSystem.Responses;
using RemoteHostAvailabilityTrackSystem.Services.Interfaces;

namespace RemoteHostAvailabilityTrackSystem.Services
{
    /// <inheritdoc />
    public class CheckApiService : ICheckApiService
    {
        private readonly IAddResultCheckRepository _addResultCheckRepository;
        private readonly IUpdateRunDateJobRepository _updateRunDateJobRepository;
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="addResultCheckRepository"></param>
        /// <param name="updateRunDateJobRepository"></param>
        public CheckApiService(IAddResultCheckRepository addResultCheckRepository, IUpdateRunDateJobRepository updateRunDateJobRepository)
        {
            _addResultCheckRepository = addResultCheckRepository;
            _updateRunDateJobRepository = updateRunDateJobRepository;
        }
        /// <inheritdoc />
        public async Task<CheckApiResponse> CheckApi(CheckApiRequest request, CancellationToken cancellationToken)
        {
            var response = new CheckApiResponse
            {
                IsValid = false
            };

            try
            {
                var uri = new Uri(request.Api);
                var httpWebRequest = WebRequest.Create(uri);
                await httpWebRequest.GetResponseAsync();
                response.IsValid = true;
            }
            catch
            {

                response.IsValid = false;
            }
            finally
            {
                if (request.JobId != null)
                {
                    var dateTime = DateTime.Now;
                    var result = new CheckApiResult
                    {
                        CheckApiJobId = request.JobId ?? 0,
                        IsValid = response.IsValid,
                        RunDate = dateTime
                    };

                await _addResultCheckRepository.AddResult(result, cancellationToken);
                await _updateRunDateJobRepository.UpdateRunDate(request.JobId ?? 0, dateTime, cancellationToken);
                }
            }
            return response;
        }
    }
}
