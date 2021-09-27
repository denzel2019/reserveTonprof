using Renci.SshNet;
using reserverProf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using DayPilot.Web.Mvc.Events.Gantt;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;

namespace reserverProf.Controllers
{
    public class LogController : Controller
    {
        public Models.maBaseEntities3 db = new maBaseEntities3();
        // GET: Log
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            return View(null);
        }
    }
}