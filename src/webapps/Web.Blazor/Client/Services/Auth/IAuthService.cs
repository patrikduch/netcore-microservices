namespace Web.Blazor.Client.Services.Auth;

using NetMicroservices.ServiceConfig.Nuget;
using Web.Blazor.Shared;

public interface IAuthService
{
    Task<ServiceResponse<Guid>> Register(UserRegister request);

    Task<ServiceResponse<string>> Login(UserLogin request);
}