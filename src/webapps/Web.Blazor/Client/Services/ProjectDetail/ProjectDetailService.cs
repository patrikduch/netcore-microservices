namespace Web.Blazor.Client.Services.ProjectDetail;

using System.Net.Http.Json;
using Web.Blazor.Shared;

public class ProjectDetailService : IProjectDetailService
{
    private readonly HttpClient _http;

    public ProjectDetail ProjectDetail { get; set; } = new ();

    public ProjectDetailService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetProjectDetailAsync()
    {
        var response = await _http.GetFromJsonAsync<ProjectDetail>("/projectdetail");


        if (response is not null)
        {
            ProjectDetail = response;
        } 
    }
}
