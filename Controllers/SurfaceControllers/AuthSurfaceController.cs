﻿using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcUmbraco.Code;
using MvcUmbraco.Models;
using Umbraco.Core;
using Umbraco.Core.Persistence.Querying;
using Umbraco.Web.Mvc;

namespace MvcUmbraco.Controllers.SurfaceControllers
{
    public class AuthSurfaceController : SurfaceController
    {
        /// <summary>
        /// Renders the Login view
        /// @Html.Action("RenderLogin","AuthSurface");
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult RenderLogin()
        {
            var loginModel = new LoginViewModel();

            loginModel.ReturnUrl = string.IsNullOrEmpty(HttpContext.Request["ReturnUrl"]) ? "/" : HttpContext.Request["ReturnUrl"];

            return PartialView("LoginForm", loginModel);
        }


        /// <summary>
        /// Handles the login form when user posts the form/attempts to login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleLogin(LoginViewModel model)
        {
            var membershipService = ApplicationContext.Current.Services.MemberService;

            if (!ModelState.IsValid)
            {
                //return RedirectToCurrentUmbracoPage();
                return PartialView("LoginForm", model);
            }

            //Member already logged in - redirect to home
            if (Members.IsLoggedIn())
            {
                return Redirect("/");
            }

            //Lets TRY to log the user in
            try
            {
                //Try and login the user...
                if (Membership.ValidateUser(model.EmailAddress, model.Password))
                {
                    //Valid credentials

                    //Get the member from their email address
                    var checkMember = membershipService.GetByEmail(model.EmailAddress);
                    
                    //Check the member exists
                    if (checkMember != null)
                    {
                        //Let's check they have verified their email address
                        if (Convert.ToBoolean(checkMember.Properties["hasVerifiedEmail"].Value))
                        {
                            //Update number of logins counter
                            int noLogins = 0;
                            /*
                            // Doesnt Work
                            if (int.TryParse(checkMember.Properties["numberOfLogins"].Value.ToString(), out noLogins))
                            {
                                //Managed to parse it to a number
                                //Don't need to do anything as we have default value of 0
                            }
                             */

                            //Update the counter
                            checkMember.Properties["numberOfLogins"].Value = noLogins + 1;

                            //Update label with last login date to now
                            checkMember.LastLoginDate = DateTime.Now;

                            //Update label with last logged in IP address & Host Name
                            string hostName         = Dns.GetHostName();
                            string clientIPAddress  = Dns.GetHostAddresses(hostName).GetValue(0).ToString();

                            checkMember.Properties["hostNameOfLastLogin"].Value = hostName;
                            checkMember.Properties["iPofLastLogin"].Value       = clientIPAddress;

                            //Save the details
                            membershipService.Save(checkMember);

                            //If they have verified then lets log them in
                            //Set Auth cookie
                            FormsAuthentication.SetAuthCookie(model.EmailAddress, true);

                            //Once logged in - redirect them back to the return URL
                            return new RedirectResult(model.ReturnUrl);
                        }
                        else
                        {
                            //User has not verified their email yet
                            ModelState.AddModelError("LoginForm.", "Email account has not been verified");

                            //Get the verify guid on the member (so we can resend out verification email)
                            var verifyGUID = checkMember.Properties["emailVerifyGUID"].Value.ToString();

                            // TODO: Implement the Email helper/send the Email :)
                            //Get Email Settings from Login Node (current node)
                            //var emailFrom = CurrentPage.GetPropertyValue("emailFrom", "robot@your-site.co.uk").ToString();
                            //var emailSubject = CurrentPage.GetPropertyValue("emailSubject", "CWS - Verify Email").ToString();

                            //Send out verification email, with GUID in it
                            //EmailHelper.SendVerifyEmail(checkMember.Email, emailFrom, emailSubject, verifyGUID);

                            return CurrentUmbracoPage();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginForm.", "Invalid details");
                    return CurrentUmbracoPage();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("LoginForm.", "Error: " + ex.ToString());
                return CurrentUmbracoPage();
            }

            //In theory should never hit this, but you never know...
            return RedirectToCurrentUmbracoPage();
        }

        //Used with an ActionLink
        //@Html.ActionLink("Logout", "Logout", "AuthSurface")
        public ActionResult Logout()
        {
            //Member already logged in, lets log them out and redirect them home
            if (Members.IsLoggedIn())
            {
                //Log member out
                FormsAuthentication.SignOut();

                //Redirect home
                return Redirect("/");
            }
            else
            {
                //Redirect home
                return Redirect("/");
            }
        }

        /// <summary>
        /// Renders the Forgotten Password view
        /// @Html.Action("RenderForgottenPassword","AuthSurface");
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderForgottenPassword()
        {
            // Partial Has to have different name to template for it to work
            return PartialView("ForgottenPasswordForm", new ForgottenPasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleForgottenPassword(ForgottenPasswordViewModel model)
        {
            var membershipService = ApplicationContext.Current.Services.MemberService;

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            //Find the member with the email address
            var findMember = membershipService.GetByEmail(model.EmailAddress);

            if (findMember != null)
            {
                //We found the member with that email

                //Set expiry date to 
                DateTime expiryTime = DateTime.Now.AddMinutes(15);

                //Lets update resetGUID property
                findMember.Properties["resetGUID"].Value = expiryTime.ToString("ddMMyyyyHHmmssFFFF");

                //Save the member with the up[dated property value
                membershipService.Save(findMember);

                //Send user an email to reset password with GUID in it
                EmailHelper email = new EmailHelper();
                email.SendResetPasswordEmail(findMember.Email, expiryTime.ToString("ddMMyyyyHHmmssFFFF"));
            }
            else
            {
                ModelState.AddModelError("ForgottenPasswordForm.", "No member found");
                return CurrentUmbracoPage();
            }

            TempData["IsSuccessful"] = true;
            return RedirectToCurrentUmbracoPage();
        }

        /// <summary>
        /// Renders the Reset Password View
        /// @Html.Action("RenderResetPassword","AuthSurface");
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderResetPassword()
        {
            return PartialView("ResetPasswordForm", new ResetPasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleResetPassword(ResetPasswordViewModel model)
        {
            var membershipService = ApplicationContext.Current.Services.MemberService;

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            //Get member from email
            var resetMember = membershipService.GetByEmail(model.EmailAddress);

            //Ensure we have that member
            if (resetMember != null)
            {
                //Get the querystring GUID
                var resetQueryString = Request.QueryString["resetGUID"];

                //Ensure we have a vlaue in QS
                if (!string.IsNullOrEmpty(resetQueryString))
                {
                    // Added to prevent nullexception from using password reset link after reseting your password
                    if (resetMember.Properties["resetGUID"].Value == null)
                    {
                        ModelState.AddModelError("ResetPasswordForm.", "Invalid GUID - Please follow the link again to <a href='/forgotten-password' class='alert-link'>reset your password.</a>");
                        return CurrentUmbracoPage();
                    }
                    //See if the QS matches the value on the member property
                    if (resetMember.Properties["resetGUID"].Value.ToString() == resetQueryString)
                    {

                        //Got a match, now check to see if the 15min window hasnt expired
                        DateTime expiryTime = DateTime.ParseExact(resetQueryString, "ddMMyyyyHHmmssFFFF", null);

                        //Check the current time is less than the expiry time
                        DateTime currentTime = DateTime.Now;

                        //Check if date has NOT expired (been and gone)
                        if (currentTime.CompareTo(expiryTime) < 0)
                        {
                            //Got a match, we can allow user to update password
                            //resetMember.RawPasswordValue.Password = model.Password;
                            membershipService.SavePassword(resetMember, model.Password);

                            //Remove the resetGUID value
                            resetMember.Properties["resetGUID"].Value = string.Empty;

                            //Save the member
                            membershipService.Save(resetMember);

                            TempData["IsSuccessful"] = true;
                            return CurrentUmbracoPage();
                        }
                        else
                        {
                            //ERROR: Reset GUID has expired
                            ModelState.AddModelError("ResetPasswordForm.", "Reset GUID has expired - Please follow the link again to <a href='/forgotten-password' class='alert-link'>reset your password.</a> ");
                            return CurrentUmbracoPage();
                        }
                    }

                    else 
                    {
                        //ERROR: QS does not match what is stored on member property
                        //Invalid GUID
                        ModelState.AddModelError("ResetPasswordForm.", "Invalid GUID - Please follow the link again to <a href='/forgotten-password' class='alert-link'>reset your password.</a>");
                        return CurrentUmbracoPage();
                    }
                }
                else
                {
                    //ERROR: No QS present
                    //Invalid GUID
                    ModelState.AddModelError("ResetPasswordForm.", "Invalid GUID - Please follow the link again to <a href='/forgotten-password' class='alert-link'>reset your password.</a>");
                    return CurrentUmbracoPage();
                }
            }

            // No Email found
            ModelState.AddModelError("ResetPasswordForm.", "Email address not found");
            return CurrentUmbracoPage();
        }


        /// <summary>
        /// Renders the Register View
        /// @Html.Action("RenderRegister","AuthSurface");
        /// </summary>
        /// <returns></returns>

        [ChildActionOnly]
        public ActionResult RenderRegister()
        {
            return PartialView("RegisterForm", new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleRegister(RegisterViewModel model)
        {
            var membershipService = ApplicationContext.Current.Services.MemberService;

            if (!ModelState.IsValid)
            {
                return PartialView("RegisterForm", model);
            }

            //Model valid let's create the member
            try
            {
                //Member createMember = Member.MakeNew(model.Name, model.EmailAddress, model.EmailAddress, umbJobMemberType, umbUser);
                // WARNING: update to your desired MembertypeAlias...
                // .CreateMember(string username, string email, string displayName, string memberTypeAlias);
                var createMember = membershipService.CreateMember(model.EmailAddress, model.EmailAddress, model.Name, "Member");

                //Set the verified email to false
                createMember.Properties["hasVerifiedEmail"].Value = false;

                //Save the changes, if we do not do so, we cannot save the password.
                membershipService.Save(createMember);

                //Set password on the newly created member
                membershipService.SavePassword(createMember, model.Password);
            }
            catch (Exception ex)
            {
                //EG: Duplicate email address - already exists
                ModelState.AddModelError("memberCreation", ex.Message);

                return CurrentUmbracoPage();
            }
            
            //Create temporary GUID
            var tempGUID = Guid.NewGuid();

            //Fetch our new member we created by their email
            var updateMember = membershipService.GetByEmail(model.EmailAddress);

            //Just to be sure...
            if (updateMember != null)
            {
                //Set the verification email GUID value on the member
                updateMember.Properties["emailVerifyGUID"].Value = tempGUID.ToString();

                //Set the Joined Date label on the member
                updateMember.Properties["joinedDate"].Value = DateTime.Now.ToString("dd/MM/yyyy @ HH:mm:ss");

                //Save changes
                membershipService.Save(updateMember);
            }

            //Send out verification email, with GUID in it
            EmailHelper email = new EmailHelper();
            email.SendVerifyEmail(model.EmailAddress, tempGUID.ToString());

            //Update success flag (in a TempData key)
            TempData["IsSuccessful"] = true;

            //All done - redirect back to page
            return CurrentUmbracoPage();
        }

        /// <summary>
        /// Renders the Verify Email
        /// @Html.Action("RenderVerifyEmail","AuthSurface");
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderVerifyEmail(string verifyGUID)
        {
            var membershipService = ApplicationContext.Current.Services.MemberService;

            // If verify email guid is null or page accessed manually
            if (verifyGUID == null)
            {
                //Update success flag (in a TempData key)
                TempData["IsSuccessful"] = false;

                //Couldn't find them - most likely invalid GUID
                return PartialView("VerifyEmail");
            }
            else
            {
                //Auto binds and gets guid from the querystring
                var findMember = membershipService.GetMembersByPropertyValue("emailVerifyGUID", verifyGUID, StringPropertyMatchType.Exact).SingleOrDefault();
                //Member findMember = Member.GetAllAsList().SingleOrDefault(x => x.getProperty("emailVerifyGUID").Value.ToString() == verifyGUID);

                //Ensure we find a member with the verifyGUID
                if (findMember != null)
                {
                    //We got the member, so let's update the verify email checkbox
                    findMember.Properties["hasVerifiedEmail"].Value = true;

                    //Save the member
                    membershipService.Save(findMember);
                }
                else
                {
                    //Update success flag (in a TempData key)
                    TempData["IsSuccessful"] = false;

                    //Couldn't find them - most likely invalid GUID
                    return PartialView("VerifyEmail");
                }
            }

            //Update success flag (in a TempData key)
            TempData["IsSuccessful"] = true;

            //All sorted let's redirect to root/homepage
            return PartialView("VerifyEmail");
        }


        //REMOTE Validation
        /// <summary>
        /// Used with jQuery Validate to check when user registers that email address not already used
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public JsonResult CheckEmailIsUsed(string emailAddress)
        {
            //Try and get member by email typed in
            var checkEmail = Members.GetByEmail(emailAddress);

            if (checkEmail != null)
            {
                return Json(String.Format("The email address '{0}' is already in use.", emailAddress), JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
