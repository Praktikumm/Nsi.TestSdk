using Microsoft.AspNetCore.Mvc;
using PraktikumNsiSdk;
using PraktikumNsiSdk.Application.Client;
using PraktikumNsiSdk.Application.Models;
using Refit;

namespace Nsi.TestSdk.Controllers;

public class CategoryController() : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreatePost(PostCategoryModel request)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5137")
        };

        var api = RestService.For<INsiApi>(httpClient);
        var client = new NsiClient(api);

        var headers = new Dictionary<string, string>
        {
            { "X-Nsi-Username", "pbisevac@singidunum.ac.rs" },
            { "X-Nsi-Password", "test1" }
        };

        var result = await client.CreateCategoryAsync(new PostCategoryModel(request.Title, request.Content),
            headers);

        return Ok(result);
    }
}