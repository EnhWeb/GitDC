using Ding.Helpers;
using GitDC.Service.Abstractions.dbo;
using GitDC.Service.Dtos.dbo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GitDC.Controllers
{
    public class HomeController : DCControllerBase
    {
        //public async Task<IActionResult> Index()
        //{
        //    var username = HttpContext.User.Identity.Name;

        //    var DCRepositoriesService = Ioc.Create<IDCRepositoriesService>();
        //    var reps = await DCRepositoriesService.GetListByUserName(username);

        //    return View(reps);
        //}

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(string name, string remoteurl, string description)
        {
            LibGit2Sharp.Repository result = null;
            name = name.Trim();

            var UserName = string.Empty;
            var Uid = 0;

            var auth = await HttpContext.AuthenticateAsync();

            UserName = HttpContext.User.Identity.Name;
            Uid = auth.Principal.Identities.First(u => u.IsAuthenticated).FindFirst(ClaimTypes.NameIdentifier).Value.ToInt();

            var DCRepositoriesService = Ioc.Create<IDCRepositoriesService>();
            var reps = await DCRepositoriesService.GetListByUserName(UserName);

            if (reps.Count > 9)
                return View(new { error = "已超过10个限制" });
            if (reps.Exists(r => r.Name == name))
                return View(new { error = "已存在仓库" });

            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(remoteurl))
            {
                result = DCRepositoriesService.CreateRepository(Path.Combine(UserName, name));
            }
            else if (!string.IsNullOrEmpty(remoteurl))
            {
                remoteurl = remoteurl.Trim();
                result = DCRepositoriesService.CreateRepository(Path.Combine(UserName, name), remoteurl);
            }

            if (result != null)
            {
                var modelRep = new DCRepositoriesDto();
                modelRep.Name = name;
                modelRep.Description = description;
                modelRep.CreatId = Uid;
                modelRep.CreationTime = DateTime.Now;
                modelRep.DefaultBranch = "master";
                modelRep.UserName = UserName;
                modelRep.LastModifiTime = DateTime.Now;
                modelRep.LastModifiId = Uid;
                await DCRepositoriesService.CreateAsync(modelRep);
                return Redirect("/");
            }

            return View();
        }
    }
}
