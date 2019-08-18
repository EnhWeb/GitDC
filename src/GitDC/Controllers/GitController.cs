using Ding.Log;
using Ding.Logs;
using Ding.Logs.Extensions;
using GitDC.Git;
using GitDC.Handlers;
using LibGit2Sharp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitDC.Controllers
{
    [Authorize(AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme)]
    public class GitController : DCControllerBase
    {
        [Route("{userName}/{repoName}.git/git-upload-pack")]
        public IActionResult ExecuteUploadPack(string userName, string repoName)
        {
            return TryGetResult(repoName, () => GitUploadPack(Path.Combine(userName, repoName)));
        }

        [Route("{userName}/{repoName}.git/git-receive-pack")]
        [DisableRequestSizeLimit]  //取消上传大小的限制
        public IActionResult ExecuteReceivePack(string userName, string repoName)
        {
            //return ExecutePack($"{userName}/{repoName}", "git-receive-pack");

            return GitReceivePack(Path.Combine(userName, repoName));
        }

        [Route("{userName}/{repoName}.git/info/refs")]
        public IActionResult GetInfoRefs(string userName, string repoName, string service)
        {
            return TryGetResult(repoName, () => GitCommand(Path.Combine(userName, repoName), service, true));
        }

        protected IActionResult ExecutePack(string project, string service)
        {
            XTrace.UseConsole();
            Response.ContentType = string.Format(CultureInfo.InvariantCulture, "application/x-{0}-result", service);
            SetNoCache();

            try
            {
                XTrace.WriteLine(project);
                using (var git = new GitService(project))
                {
                    var svc = service.Substring(4);
                    git.ExecutePack(svc, GetInputStream(), Response.Body);
                }
                return new EmptyResult();
            }
            catch (RepositoryNotFoundException e)
            {
                e.Log(GetLog().Exception(e));
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                throw new HttpRequestException(string.Empty, e);
            }
            catch (Exception e)
            {
                e.Log(GetLog().Exception(e));
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpRequestException(string.Empty, e);
            }
        }

        #region GitController Extension
        private void SetNoCache()
        {
            Response.Headers.Add("Expires", "Fri, 01 Jan 1980 00:00:00 GMT");
            Response.Headers.Add("Pragma", "no-cache");
            Response.Headers.Add("Cache-Control", "no-cache, max-age=0, must-revalidate");
        }

        private Stream GetInputStream()
        {
            if (Request.Headers["Content-Encoding"] == "gzip")
            {
                return new GZipStream(Request.Body, CompressionMode.Decompress);
            }
            return Request.Body;
        }

        private static string FormatMessage(string input)
        {
            return (input.Length + 4).ToString("X4", CultureInfo.InvariantCulture) + input;
        }

        private static string FlushMessage()
        {
            return "0000";
        }
        #endregion
    }
}
