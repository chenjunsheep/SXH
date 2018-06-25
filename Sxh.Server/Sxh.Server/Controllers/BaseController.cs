using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Sxh.Server.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult ExceptionDefault(Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}