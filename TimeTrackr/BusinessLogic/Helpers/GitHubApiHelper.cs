using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Models.Git;
using BusinessLogic.TypeManagement;
using Newtonsoft.Json;

namespace BusinessLogic.Helpers
{
    public class GitHubApiHelper
    {
        public static async Task<List<Commit>> GetCommitsAsync(Project project)
        {
            var result = new List<Commit>();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Anything");
            var response = await client.GetAsync($"https://api.github.com/repos/{project.GitUsername}/{project.GitRepo}/commits").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return result;
            }

            var stringifiedCommits = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var gitCommits = JsonConvert.DeserializeObject<List<GitCommitWrapper>>(stringifiedCommits);

            foreach (var gitCommit in gitCommits)
            {
                result.Add(gitCommit.CopyTo<Commit>());
            }

            return result;
        }
    }
}
