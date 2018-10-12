using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Shared.Api.Auth.Jwt;
using Sxh.Business;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sxh.Server.Middleware
{
    public static class Authentication
    {
        public static JwtBearerOptions UseMiddleware(this JwtBearerOptions options)
        {
            if (options != null)
            {
                var defOpt = JwtOptions.Default;

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = async ctx =>
                    {
                        ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await ctx.Response.WriteAsync(ctx.Exception.Message);
                    },
                    OnTokenValidated = async ctx =>
                    {
                        var accessToken = ctx.SecurityToken as JwtSecurityToken;
                        if (accessToken != null)
                        {
                            if (DateTime.UtcNow > accessToken.ValidTo)
                            {
                                ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                ctx.Fail(new UnauthorizedAccessException());
                                await ctx.Response.WriteAsync("token expired, please relogin");
                            }
                            else
                            {
                                var content = JwtManager.TokenDecrypt(accessToken);
                                var targetUser = BusinessCache.Users.FirstOrDefault(u => u.Id == content);
                                if (targetUser == null)
                                {
                                    ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                    ctx.Fail(new UnauthorizedAccessException());
                                    await ctx.Response.WriteAsync("server restared, please relogin");
                                }
                                else
                                {
                                    var identity = ctx.Principal.Identity as ClaimsIdentity;
                                    if (identity != null)
                                    {
                                        identity.AddClaim(new Claim(defOpt.fieldtoken, accessToken.RawData));
                                        await Task.CompletedTask;
                                    }
                                }
                            }
                        }
                    },
                };
            }

            return options;
        }
    }
}
