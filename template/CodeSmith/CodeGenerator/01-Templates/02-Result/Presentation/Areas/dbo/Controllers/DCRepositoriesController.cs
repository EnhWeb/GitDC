﻿using Microsoft.AspNetCore.Mvc;
using Ding.Ui.Controllers;

namespace GitDC.Areas.dbo.Controllers {
    /// <summary>
    /// 仓库表控制器
    /// </summary>
    [Area( "dbo" )]
    public class DCRepositoriesController : ViewControllerBase {        
        /// <summary>
        /// 首页
        /// </summary>
        public IActionResult Index() {
            return View();
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        public IActionResult Edit() {
            return View();
        }
        
        /// <summary>
        /// 详细
        /// </summary>
        public IActionResult Detail() {
            return View();
        }
    }
}