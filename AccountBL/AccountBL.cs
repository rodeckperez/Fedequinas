using Base;
using Common;
using CommonEntity;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using Table;
using Util;

namespace BusinessRules
{
    public class AccountBL
    {
        private AccountDB db = new AccountDB(new SqlServer());
        private string newPassword;
        private string email;

        private void SendMail()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(WebConfigurationManager.AppSettings["EmailAccount"], "Fedequinas App");
            mail.To.Add(this.email);
            mail.IsBodyHtml = true;
            mail.Subject = "Nueva contraseña Fedequinas App";
            mail.Body = @"<div style='border: 4px solid #4267B2;padding: 8px;'>
                            <h1 style='color: #C2C2C2;' > Su nueva contraseña generada es: </h1>
                            <p style='color: #4267B2;'> " + newPassword+"</p>"+
                            "<br><br></div>";
            mail.Priority = MailPriority.High;


            SmtpClient smtp = new SmtpClient();
            smtp.Host = WebConfigurationManager.AppSettings["EmailHost"];
            smtp.Port = Int32.Parse(WebConfigurationManager.AppSettings["EmailPort"]);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["EmailAccount"], WebConfigurationManager.AppSettings["EmailPassword"]);
            smtp.Send(mail);
        }

        public BaseResponse<SimpleResponse> NewPassword(string pEmail)
        {
            this.email = pEmail;
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            AccountDB db = new AccountDB(new SqlServer());

            if (db.AccountExists(email))
            {
                newPassword = GeneratePassword();
                db.ChangePassword(email, Sha256.Generate(newPassword));

                ThreadStart threadDelegated = new ThreadStart(SendMail);
                Thread thread = new Thread(threadDelegated);
                thread.Start();

                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "La nueva contraseña ha sido enviada a \""+email+"\"";
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = email + " no esta registrado en la base de datos";
            }

            return baseResponse;
        }

        public BaseResponse<SimpleResponse> ChangePassword(ChangePassword changePassword)
        {
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            AccountDB db = new AccountDB(new SqlServer());
            db.ChangePassword(changePassword.PkAccount, changePassword.Password);


            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "Contraseña actualizada satisfactoriamente";
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        private string GeneratePassword()
        {
            string newPassword = "";
            List<string> capitals = new List<string>(){"A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            List<string>  lowers = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            List<string> numbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            List<string> simbols = new List<string>() { "@", "#", "$", "%", "(", ")", "*", "-" ,"+"};

            Random random = new Random();
            newPassword = capitals.ElementAt(random.Next(24)) +
                            lowers.ElementAt(random.Next(24)) +
                            lowers.ElementAt(random.Next(24)) +
                            lowers.ElementAt(random.Next(24)) +
                            lowers.ElementAt(random.Next(24)) +
                            lowers.ElementAt(random.Next(24)) +
                            lowers.ElementAt(random.Next(24)) +
                            numbers.ElementAt(random.Next(9)) +
                            simbols.ElementAt(random.Next(9));

            return newPassword;
        }

        public BaseResponse<Account> ValidateCredentials(Account account)
        {
            BaseResponse<Account> baseResponse = new BaseResponse<Account>();
            baseResponse.Response = account;
            bool ValidateRecordState = false;
            AccountDB db = new AccountDB(new SqlServer());

            string StorePassword = db.GetPassword(account.Email);
            if (StorePassword.Length != 64)
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "Credenciales incorrectas";
            }
            else
            {
                if (StorePassword != account.Password)
                {
                    db.InsertAccessFail(account.Email);
                }
                else
                {
                    account = db.GetAccountData(account.Email);
                    ValidateRecordState = true;
                }
            }

            if (ValidateRecordState)
            {
                if (account.RecordState == "CA")
                {
                    baseResponse.BusinessActionOk = true;
                    baseResponse.ServerActionOk = true;
                    baseResponse.Message = "";
                    baseResponse.Response = account;

                    db.DeletePersonAccessfail(account.PkAccount);
                }
                else
                {
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = true;
                    baseResponse.Message = "La cuenta del usuario esta bloqueada";
                    baseResponse.Response = null;
                }
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "Credenciales incorrectas";
            }

            return baseResponse;
        }

        public BaseResponse<Account> InsertAccount(Account account)
        {
            try
            {
                BaseResponse<Account> response = new BaseResponse<Account>();
                account.Document = account.AccountType;
                if (account.AccountType.Equals("1")) //publica
                {
                    response = CreateAccount(account);
                }
                else
                {
                    if (db.CanCreateAccount(account))
                    {
                        response = CreateAccount(account);
                    }
                    else
                    {
                        response.BusinessActionOk = false;
                        response.ServerActionOk = true;
                        response.Message = db.Message;
                    }
                }
            
                return response;
            }
            catch(Exception e)
            {
                BaseResponse<Account> response = new BaseResponse<Account>();
                response.BusinessActionOk=false;
                response.ServerActionOk=false;
                response.Message= e.Message;
                return response;
            }
            
        }

        private BaseResponse<Account> CreateAccount(Account account)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            account = db.InsertAccount(account);
            response.Response = account;
            if (account.PkAccount > 0)
            {
                response.BusinessActionOk = true;
                response.ServerActionOk = true;
                response.Message = "La cuenta ha sido creada correctamente";
            }

            if (account.PkAccount == 0)
            {
                response.BusinessActionOk = false;
                response.ServerActionOk = true;
                response.Message = "El email digitado ya esta asociado a otra cuenta";
            }

            if (account.PkAccount == -1)
            {
                response.BusinessActionOk = false;
                response.ServerActionOk = false;
                response.Message = db.Message;
            }

            return response;
        }
    }
}