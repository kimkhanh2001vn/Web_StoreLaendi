using LaendiStore.Common;
using LaendiStore.Data.EF;
using LaendiStore.IBusiness;
using LaendiStore.ViewModel;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;

namespace LaendiStore.Web.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var result = _customerRepository.Login(customer.UserName, customer.PassWord);
                if (result == 1)
                {
                    var customerByUser = _customerRepository.GetByUserName(customer.UserName);
                    var CustomerSession = new Customer();
                    CustomerSession.UserName = customerByUser.UserName;
                    CustomerSession.CustomerID = customerByUser.CustomerID;
                    CustomerSession.CustomerName = customerByUser.CustomerName;
                    Session.Add(CommonStants.Customer_Session, CustomerSession);
                    Session[CommonStants.username_Customer] = customerByUser.CustomerName;
                    Session[CommonStants.ID_Customer] = customerByUser.CustomerID;
                    //Session["ID"] = customer.CustomerID;
                    //HttpContext.Application["ID"] = customerByUser.CustomerID;
                    return RedirectToAction("index", "home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", Resources.Common.MsgAccountNotContain);
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", Resources.Common.MsgAccountIsLock);
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", Resources.Common.MsgPassworkIsNotVaild);
                }
                else
                {
                    ModelState.AddModelError("", Resources.Common.MsgUserIsNotVaild);
                }
            }
            else
            {
                ModelState.AddModelError("", "");
            }

            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                if (!_customerRepository.CheckContainAccount(customer.CustomerEmail, customer.UserName))
                {
                    ModelState.AddModelError("", Resources.Common.lblAccoutContain);
                }
                else if (!ConfirmPassword(customer.PassWord, customer.ConfirmPassWord))
                {
                    ModelState.AddModelError("", Resources.Common.lblConfirmPassIsvaild);
                }
                else
                {
                    var objCustomer = new Customer();
                    objCustomer.CustomerName = customer.CustomerName;
                    objCustomer.CustomerEmail = customer.CustomerEmail;
                    objCustomer.UserName = customer.UserName;
                    objCustomer.PassWord = Encryptor.MD5Hash(customer.ConfirmPassWord);

                    _customerRepository.Insert(objCustomer);
                    _customerRepository.Save();

                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }

        private bool ConfirmPassword(string pass, string confirmPass)
        {
            if (string.Compare(pass, confirmPass) == 0)
            {
                return true;
            }
            else if (string.IsNullOrEmpty(pass))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(confirmPass))
            {
                return false;
            }
            return false;
        }
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            string messenger = "";
            var account = _customerRepository.GetbyEmailResestPassword(string.IsNullOrEmpty(email) ? string.Empty : email);
            if (account != null)
            {
                //send email for reset password
                string resetCode = Guid.NewGuid().ToString();
                SendVerificationEmail(account.CustomerEmail, resetCode, "ResetPassword");
                //account.ResestPasswordCode = resetCode;
                //this line i have added here to void confirm password not match issue
                //db.Configuration.ValidateOnSaveEnabled = false;
                ////save token guid in resetpassword
                //db.SaveChanges();
                ViewData["success"] = "Mã xác thực đã được gửi đến email của bạn.";
            }
            else
            {
                messenger = "Account Not found";
            }
            return View();
        }
        public void SendVerificationEmail(string Email, string activationCode, string EmailFor = "VerifyAccount")
        {
            var verifyUrl = "/Login/" + EmailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("1924801030055@student.tdmu.edu.vn", "Ngo Kim Khanh");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "Ngokimkhanh19";
            string subject = "";
            string body = "";
            if (EmailFor != null)
            {
                subject = "Tài khoản của bạn được gửi mã xác thực thành công";
                body = "<br/><br/>Hãy chọn link bên dưới để xác thực " +
                    "Cập nhật thành công. Chọn link bên dưới để hoàn thành xác thực mật khẩu của bạn" +
                    "<br/><br/><a href='" + link + "'>" + Resources.Common.lblResestPassword + "<a/>";
            }
            else if (EmailFor == "ResetPassWord")
            {
                subject = "Reset PassWord";
                body = "Hi,<br/>,<br/> Chúng tối đang gửi yêu cầu để cập nhật lại mật khẩu của bạn.Làm ơn hãy chọn link bên dưới để cập nhật lại mật khẩu." +
                    "<br/><br/><a href=" + link + ">" + Resources.Common.lblResestPassword + "<a/>";
            }
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var messenge = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(messenge);
        }
        public ActionResult Logout()
        {
            Session[CommonStants.User_Session] = null;
            Session[CommonStants.username_Customer] = null;
            Session[CommonStants.ID_Customer] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn", "Login");
        }
    }
}