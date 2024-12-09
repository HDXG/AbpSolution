using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RYDesign.AspNetCore.Filters
{
    public class HttpResponseSuccessFilter : IAsyncActionFilter
    {
        private Stopwatch _stopwatch;

        public HttpResponseSuccessFilter()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext executedContext = await next.Invoke();

            //统一返回时 如果是文件格式，直接返回，不进行统一的封装格式
            if (executedContext.Result as FileContentResult != null)
            {
                executedContext.Result = executedContext.Result as FileContentResult;
                return;
            }
            var objectResult = executedContext.Result as ObjectResult;
            _stopwatch.Stop();

            if (objectResult != null && objectResult.Value != null)
            {
                executedContext.Result = new ObjectResult(new HttpResponseSuccess(HttpStatusCode.OK, objectResult.Value, "请求成功！", DateTime.Now, _stopwatch.ElapsedMilliseconds));
            }
            else
            {
                executedContext.Result = new ObjectResult(new HttpResponseSuccess(HttpStatusCode.InternalServerError, new { }, "出现异常", DateTime.Now, _stopwatch.ElapsedMilliseconds));
            }
            
        }

    }

    /// <summary>
    /// 成功：返回数据格式
    /// </summary>
    /// <param name="code"></param>
    /// <param name="data"></param>
    /// <param name="msg"></param>
    /// <param name="ServiceTime"></param>
    /// <param name="TimeOut"></param>
    public record HttpResponseSuccess(HttpStatusCode code, object data, string msg, DateTime ServiceTime, long TimeOut);

}
