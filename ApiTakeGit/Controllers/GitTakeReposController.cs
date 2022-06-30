using System;
using System.Linq;
using ApiTakeGit.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTakeGit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitTakeReposController : ControllerBase
    {

        [HttpGet(Name = "GetGitTakeRepos")]
        public async Task<List<GitTakeReposModel>> Get()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "LuisCo123");
            int numberPage = 1;
            string responsebody = "";
            List<GitTakeReposModel> repositories = new List<GitTakeReposModel>();
            while (responsebody != "[]")
            {
                HttpResponseMessage response = await client.GetAsync($"https://api.github.com/users/takenet/repos?sort=created_at&direction=asc&per_page=100&page={numberPage}");
                response.EnsureSuccessStatusCode();
                responsebody = await response.Content.ReadAsStringAsync();
                repositories.AddRange(JsonConvert.DeserializeObject<List<GitTakeReposModel>>(responsebody));
                numberPage++;
            }
            List<GitTakeReposModel> filteredRepos = repositories.Where(repos => repos.language == "C#")
                                                                .Take(5)
                                                                .ToList();
            return filteredRepos;
        }
    }
}