﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ConfiguringApps.Infractructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;
        public ErrorMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response
                    .WriteAsync("Edge not supported", Encoding.UTF8);
            }
            else
            {
                if (httpContext.Response.StatusCode == 404)
                {
                    await httpContext.Response
                        .WriteAsync("No content middleware responce", Encoding.UTF8);
                }
            }
           
        }
    }
}
