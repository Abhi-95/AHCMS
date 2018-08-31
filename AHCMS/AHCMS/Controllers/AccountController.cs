using AHCMS.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHCMS.DAL.Repository;
using AHCMS.CORE;
using System.Web.Security;

namespace AHCMS.Controllers
{
    public class AccountController : Controller
    {
        private SessionModel sessionModel = new SessionModel();
        #region Login
        // GET: Account/PatientLogin
        [HttpGet]
        [AllowAnonymous]
        public ActionResult PatientLogin(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult PatientLogin(LoginViewModel model)
        //{
        //    model.Role = "Patient";
        //    model.UserType = UserRole.Patient;
        //    //Authentication 
        //    var result = PasswordSignIn(model.Email, model.Password, model.Role, model.UserType);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            string name = sessionModel.FirstName + " " + sessionModel.LastName;
        //            FormsAuthentication.SetAuthCookie(name, false);
        //            Session["ReffNo"] = sessionModel.ReffNo;
        //            Session["UserName"] = model.Email;
        //            Session["Img"] = sessionModel.Img;
        //            Session["Role"] = model.Role;
        //            Session["Name"] = name;
        //            return RedirectToAction("PatientDashboard");                   
        //        case SignInStatus.SessionOut:
        //            return View("SessionOut");
        //        case SignInStatus.RequiresVerification:
        //            return RedirectToAction("SendCode");
        //        case SignInStatus.Failure:
        //            ModelState.AddModelError("", "Invalid login attempt.");
        //            return View(model);
        //        default:                  
        //            return View(model);
        //    }
        //}

        [HttpGet]
        public ActionResult Login()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            // Store the originating URL so we can attach it to a form field
            //var viewModel = new AccountLoginModel { ReturnUrl = returnUrl };
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PatientLogin(LoginViewModel model)
        {
            model.Role = "Doctor";
            model.UserType = UserRole.Employee;
            //Authentication 
            var result = PasswordSignIn(model.Email, model.Password, model.Role, model.UserType);
            switch (result)
            {
                case SignInStatus.Success:
                    string name = sessionModel.FirstName + " " + sessionModel.LastName;
                    FormsAuthentication.SetAuthCookie(name, false);

                    Session["ReffNo"] = sessionModel.ReffNo;
                    Session["UserName"] = model.Email;
                    Session["Img"] = sessionModel.Img;
                    Session["Role"] = model.Role;
                    Session["Name"] = name;
                    return RedirectToAction("Dashboard");
                case SignInStatus.SessionOut:
                    return View("SessionOut");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode");
                case SignInStatus.Failure:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                default:
                    return View(model);
            }
        }


        public virtual SignInStatus PasswordSignIn(string Email, string Password, string Role, UserRole userType)
        {
            int source = 0;
            switch (userType)
            {
                case UserRole.Patient:
                    source = 0;
                    break;
                case UserRole.Employee:
                    source = 1;
                    break;
            }

            ValidateUser_Result result = new Authentication().Login(Email, Password, Role, source);

            switch (result.Status)
            {
                case 0:
                    sessionModel.ReffNo = result.ReffNo;
                    sessionModel.FirstName = result.FirstName;
                    sessionModel.LastName = result.LastName;
                    sessionModel.Img = result.Img;

                    return SignInStatus.Success;
                case 2:
                    return SignInStatus.RequiresVerification;
                case 3:
                    return SignInStatus.Failure;
            }

            return SignInStatus.Failure;
        }
        #endregion

        #region Registration
        // GET: Account/PatientSignUp
        [HttpGet]
        [AllowAnonymous]
        public ActionResult PatientSignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public int PatientRegister(AccountLoginModel model)
        {
            Patient p = new Patient();
            p.PatientID = new ViewModal().GenerateGuidCode();
            p.UserName = model.Username;
            p.Password = model.Password;
            p.FirstName = model.FirstName;
            p.MiddleName = model.MiddleName;
            p.LastName = model.LastName;
            p.Email = model.Email;
            p.PhoneNumber = model.PhoneNumber;
            p.Street = model.Street;
            p.City = model.City;
            p.State = model.State;
            p.Country = model.Country;
            p.ZipCode = model.ZipCode;
            p.BirthDate = model.BirthDate;
            p.BloodGroup = model.BloodGroup;
            p.Gender = model.Gender;

            int status = new Authentication().PatientRegistration(p);
            return status;
        }

        [HttpPost]
        public ActionResult EmployeeSignUp(AccountLoginModel model, string role)
        {
            Employee p = new Employee();
            p.EmployeeID = model.ID;
            p.ReffNo = model.ReffNo;
            p.UserName = model.Username;
            p.Password = model.Password;
            p.FirstName = model.FirstName;
            p.MiddleName = model.MiddleName;
            p.LastName = model.LastName;
            p.Email = model.Email;
            p.PhoneNumber = model.PhoneNumber;
            p.Street = model.Street;
            p.City = model.City;
            p.State = model.State;
            p.Country = model.Country;
            p.ZipCode = model.ZipCode;
            p.BirthDate = model.BirthDate;
            p.BloodGroup = model.BloodGroup;
            p.Gender = model.Gender;

            int status = new Authentication().EmployeeRegistration(p, role);

            return Json(status, JsonRequestBehavior.AllowGet);
        }
        #endregion


        public ActionResult Dashboard()
        {
            return RedirectToAction("DoctorProfile", "Appointment");
        }

        public ActionResult PatientDashboard()
        {

            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /account/forgotpassword
        [HttpPost]
        [AllowAnonymous]
        public int ForgotPassword_Patient(LoginViewModel model)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            ForgotPassword_Result result = new Authentication().ForgotPassword(model.Username, model.Email, 0);

            if (result.Password == "" && result.FirstName == "")
            {
                return 0;
            }
            else
            {
                string name = result.FirstName + " " + result.LastName;
                new Notification().ForgotPasswordMail(name, result.Password,model.Email);
                return 1;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public int ForgotPassword_Employee(LoginViewModel model)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            ForgotPassword_Result result = new Authentication().ForgotPassword(model.Username, model.Email, 1);

            if (result.Password == "" && result.FirstName == "")
            {
                return 0;
            }
            else
            {
                string name = result.FirstName + " " + result.LastName;
                new Notification().ForgotPasswordMail(name, result.Password, model.Email);
                return 1;
            }
        }

        //[HttpPost]
        //public ActionResult ForgotPassword(AccountModel model)
        //{
        //    Siteuser siteuser = new SiteuserRepository().CheckEmailExistOrNot(model.Emailaddress);
        //    if (siteuser != null)
        //    {
        //        new SiteuserRepository().SendEmail(model.Emailaddress);
        //    }
        //    return View();
        //}



        //[HttpPost]
        //public ActionResult Login(AccountModel model)
        //{
        //    if (Membership.ValidateUser(model.Username, model.Password))
        //    {
        //        var roles = Roles.GetRolesForUser(model.Username);
        //        SessionModel sessionVar = new SessionModel();
        //        sessionVar.user = new SiteuserRepository().GetUser(model.Username);
        //        var role = new SiteuserRepository().GetRole(sessionVar.user.RoleId);
        //        sessionVar.lstroles = roles;

        //        FormsAuthentication.RedirectFromLoginPage(model.Username, false);
        //        FormsAuthentication.SetAuthCookie(model.Username, false);

        //        Session["user"] = model.Username;
        //        Session["role"] = role.RoleName;
        //        Session["UserDetails"] = sessionVar;

        //        if (role.RoleName == "Applicants")
        //        {
        //            return RedirectToAction("Index", "Applicants");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }

        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Invalid UserName Or Password.");
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}




        //End of Login() - Get Method

        // POST: /account/login
        /// <summary>
        /// Start of Login() - Action to Validate User and allow user to Login into the system 
        /// Session is created after validate user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(AccountLoginModel viewModel)
        //{//commit and push
        //    // Ensure we have a valid viewModel to work with
        //    if (!ModelState.IsValid)
        //        return View(viewModel);
        //    if (Membership.ValidateUser(viewModel.user.UserName, viewModel.user.Password))
        //    {
        //        List<GetRolesForUser_Result> lstdbroles = new List<GetRolesForUser_Result>();
        //        FormsAuthentication.SetAuthCookie(viewModel.user.UserName, true);
        //        // var sss= JSON.Parse(Session["user"]);
        //        SessionModel sessionVar = new SessionModel();
        //        sessionVar.user = (User)Session["user"];

        //        sessionVar.lstroles = null;//role.getRolesForUser(viewModel.user.UserName);
        //        // sessionVar["role"] = roles.First();
        //        //sessionVar.UserRoles.UserRoleName = roles.First();
        //        Session["user"] = viewModel.user.UserName;
        //        Session["UserDetails"] = sessionVar;
        //        //if (roles.First() == "Administrator")
        //        //{ return RedirectToLocal(viewModel.ReturnUrl); }
        //        //else
        //        //{
        //        //    return RedirectToLocal(viewModel.ReturnUrl);
        //        //}
        //        ViewBag.session = sessionVar;
        //        return RedirectToLocal(viewModel.ReturnUrl);
        //    }
        //    // No existing user was found that matched the given criteria
        //    ModelState.AddModelError("", "Invalid username or password.");

        //    // If we got this far, something failed, redisplay form
        //    return View(viewModel);
        //}
        //End of Login() - Post Method


        // GET: /account/error
        //[AllowAnonymous]
        //public ActionResult Error()
        //{
        //    // We do not want to use any existing identity information
        //    EnsureLoggedOut();

        //    return View();
        //}

        //// POST: /account/Logout
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Logout()
        //{
        //    // HttpContext.Current.Request.Browser = new HttpBrowserCapabilities() { Capabilities = new Dictionary<string, string> { { "supportsEmptyStringInCookieValue", "false" } } };
        //    // First we clean the authentication ticket like always
        //    FormsAuthentication.SignOut();
        //    Session.Remove("user");
        //    Session.Remove("role");
        //    Session.Remove("UserDetails");
        //    //Session["user"] = null;
        //    //Session["role"] = null;
        //    //Session["UserDetails"] = null;

        //    // Second we clear the principal to ensure the user does not retain any authentication
        //    HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

        //    // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
        //    // this clears the Request.IsAuthenticated flag since this triggers a new request
        //    return RedirectToLocal();
        //}



        //private void AddErrors(DbEntityValidationException exc)
        //{
        //    foreach (var error in exc.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors.Select(validationError => validationError.ErrorMessage)))
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}

        //private void AddErrors(IdentityResult result)
        //{
        //    // Add all errors that were returned to the page error collection
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            //if (Request.IsAuthenticated)
            //    Logout();
            //Logout();
        }

        //private async Task SignInAsync(IdentityUser user, bool isPersistent)
        //{
        //    // Clear any lingering authencation data
        //    FormsAuthentication.SignOut();

        //    // Create a claims based identity for the current user
        //    var identity = await _manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

        //    // Write the authentication cookie
        //    FormsAuthentication.SetAuthCookie(identity.Name, isPersistent);
        //}

        // GET: /account/lock
        [AllowAnonymous]
        public ActionResult Lock()
        {
            return View();
        }

        #region Helper

        private ActionResult RedirectToLocal(string returnUrl = "")
        {
            if (!returnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            // If we cannot verify if the url is local to our host we redirect to a default location
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}