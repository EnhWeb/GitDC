using Ding.Helpers;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace GitDC.Common.Filter
{
    public class BasePageModel : PageModelBase
    {
        /// <summary>
        /// 防跨站攻击字符串
        /// </summary>
        public string CSRF { get; set; }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            base.OnPageHandlerSelected(context);
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            base.OnPageHandlerExecuting(context);
        }

        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            base.OnPageHandlerExecuted(context);
        }

        public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var antiforgery = Ioc.Create<IAntiforgery>();
            var tokens = antiforgery.GetAndStoreTokens(context.HttpContext);
            CSRF = tokens.RequestToken;


            await base.OnPageHandlerExecutionAsync(context, next);
        }

        public override Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            return base.OnPageHandlerSelectionAsync(context);
        }

    }
}
