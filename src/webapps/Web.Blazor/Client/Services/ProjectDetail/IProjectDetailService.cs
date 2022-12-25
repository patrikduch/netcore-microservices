namespace Web.Blazor.Client.Services.ProjectDetail;

using Web.Blazor.Shared;

public interface IProjectDetailService
{
    public ProjectDetail ProjectDetail { get; set; }

    Task GetProjectDetailAsync();
}
