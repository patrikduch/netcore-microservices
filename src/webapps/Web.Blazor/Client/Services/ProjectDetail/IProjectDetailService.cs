namespace Web.Blazor.Client.Services.ProjectDetailService;

using Web.Blazor.Shared;

public interface IProjectDetailService
{
    public ProjectDetail ProjectDetail { get; set; }

    Task GetProjectDetailAsync();
}
