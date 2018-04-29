using SeraySis.BLL;
using SeraySis.BLL.Results;
using SeraySis.Entities;
using SeraySis.Entities.Messages;
using SeraySis.Entities.ValueObjects;
using SeraySis.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeraySis.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private UserManager usrMng = new UserManager();

        [HttpGet]
        [Route("")]

        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("")]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Users> result = usrMng.LoginUser(model);

                if (result.Errors.Count > 0)
                {
                    if (result.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNoActive) != null)
                    {
                        ViewBag.SetLink = "Tekrar E-Posta Gonder";
                    }

                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(model);
                }

                CurrentSession.Set<Users>("seraysis-online", result.Result);

                return Redirect("/Yonetim");
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return Redirect("/");
        }

    }
}