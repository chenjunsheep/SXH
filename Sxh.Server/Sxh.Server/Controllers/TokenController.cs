using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Api.Auth.Jwt;
using Shared.Util;
using Shared.Util.Extension;
using Sxh.Business;
using Sxh.Business.DbProxy;
using Sxh.Business.ViewModel;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sxh.Server.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("welcome to Cee Jay!");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] vmLogin para)
        {
            using (var db = DbContextFactory.CreateSxhContext())
            {
                var targetUser = await db.User.FirstOrDefaultAsync(u => u.Id == para.UserName);
                if (targetUser != null)
                {
                    if (targetUser.Expired.HasValue)
                    {
                        if (DateTime.UtcNow > targetUser.Expired.Value.ToUniversalTime())
                        {
                            return StatusCode((int)HttpStatusCode.Forbidden, "user expired");
                        }
                    }

                    var pswEncrpyt = TypeParser.GetStringValue(para.Password).Md5Encrypt();
                    if (string.IsNullOrEmpty(targetUser.Psw) || targetUser.Psw == pswEncrpyt)
                    {
                        if (string.IsNullOrEmpty(targetUser.Psw))
                        {
                            //first time login
                            targetUser.Psw = pswEncrpyt;
                            db.User.Update(targetUser);
                            await db.SaveChangesAsync();
                        }

                        var mgr = new JwtManager(AppSetting.Instance.SecretKey);
                        var token = mgr.TokenCreate(para.UserName, para.UserName, AppSetting.Instance.TokenExpiredHour);
                        return Ok(token);
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.Forbidden, "invalid user name or password");
                    }
                }
            }

            return Unauthorized();
        }

        [HttpGet("Decode")]
        public IActionResult Decode()
        {
            var content = JwtManager.TokenDecrypt(User);
            return Ok(content);
        }
    }
}
