using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ConfiguringApps.Infractructure
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private UpTimeServises uptime;
        public ContentMiddleware(RequestDelegate next, UpTimeServises up)
        {   nextDelegate = next;
            uptime = up;
        }

        
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware" + 
                    $"(uptime: {uptime.Uptime}ms)", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
