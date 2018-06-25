﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sxh.Business.Repository.Interface;
using Sxh.Business.ViewModel;

namespace Sxh.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Proxy")]
    public class ProxyController : BaseController
    {
        private IProxyRepository _repoProxy;

        public ProxyController(IProxyRepository repoProxy) : base()
        {
            _repoProxy = repoProxy;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] vmLogin para)
        {
            try
            {
                var token = await _repoProxy.LoginAsync(para);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return ExceptionDefault(ex);
            }
        }
    }
}
