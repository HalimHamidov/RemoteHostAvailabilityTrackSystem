Structure:

* RemoteHostAvailabilityTrackSystem.DataBase.Models -> public class CheckApiJobModel

* RemoteHostAvailabilityTrackSystem.DataBase -> public class DataContext = public DbSet<CheckApiJobModel> CheckApiJobModels { get; set; }

* RemoteHostAvailabilityTrackSystem.DataBase.Repositories -> public class GetJobsRepository ->
  public async Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken) ->
  return await context.CheckApiJobModels.ToListAsync(cancellationToken);

* RemoteHostAvailabilityTrackSystem.DataBase.Repositories.Interfaces->public interface IGetJobsRepository

* RemoteHostAvailabilityTrackSystem.Services -> public class GetJobsService : ->
  public async Task<ICollection<CheckApiJobModel>> GetJobs(CancellationToken cancellationToken)
  {
  return  await _getJobsRepository.GetJobs(cancellationToken);
  }

* RemoteHostAvailabilityTrackSystem.Services.Interfaces
  {
  public interface IGetJobsService
  {


*  RemoteHostAvailabilityTrackSystem.Controllers -> public class CheckApiController
   [HttpGet]
   [Route("get-jobs/{key}")]
   public async Task<ICollection<CheckApiJobModel>> GetJobs([FromRoute] string key, CancellationToken cancellationToken)
   {
   var userId = await _checkAuthService.CheckAuth(key, cancellationToken);
   var jobs = await _getJobsService.GetJobs(cancellationToken);
   return jobs.Where(q => q.UserId(CheckApiJobModel) == userId).ToList();
   }



http port

https://docs.microsoft.com/ru-ru/dotnet/api/system.net.ipaddress.loopback?view=net-5.0

http://127.0.0.1:8080/api/v1/auth/user


"C:\Program Files\JetBrains\JetBrains Rider 2020.3.2\plugins\dpa\DotFiles\JetBrains.DPA.Runner.exe" --handle=7008 --backend-pid=9112 --detach-event-name=dpa.detach.7008 "C:\Program Files\dotnet\dotnet.exe" "D:/Projects/INNOSTAGE-1st assignment/URLAvailabilityTrackTask/RemoteHostAvailabilityTrackSystem/RemoteHostAvailabilityTrackSystem/bin/Debug/net5.0/RemoteHostAvailabilityTrackSystem.dll"

Server started

Hosting environment: Development

Content root path: D:\Projects\INNOSTAGE-1st assignment\URLAvailabilityTrackTask\RemoteHostAvailabilityTrackSystem\RemoteHostAvailabilityTrackSystem\bin\Debug\net5.0\

Now listening on: http://127.0.0.1:8080

Application started. Press Ctrl+C to shut down.


https://microsoft.github.io/reverse-proxy/articles/transforms.html

// Set the comments path for the Swagger JSON and UI.

https://docs.microsoft.com/ru-ru/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio
