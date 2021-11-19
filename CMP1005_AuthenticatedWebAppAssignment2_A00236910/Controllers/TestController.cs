using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMP1005_AuthenticatedWebAppAssignment2_A00236910.Controllers
{
    public class TestController : Controller
    {
        [Authorize]
        // GET: /<controller>/
        public IActionResult Secret()
        {
            return View();
        }
    }
}
