using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Contracts;
using BussinessLayer.Models;
namespace BussinessLayer.BussinessUtil
{
    public class LoginUtility : IAuthticate
    {
        private Entities Entities;
 
        public LoginUtility()
        {
            Entities = new Entities();
        }

        public void ForgotPassword(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(LoginModel loginModel)
        {
            bool loginSucesss = false;
            try
            {
               
                CustomerLogin login = Entities.CustomerLogins.ToList().Where(x => x.UserName.ToLower() == loginModel.UserName.ToLower() && x.Password.ToLower() == loginModel.Password.ToLower()).FirstOrDefault();
                if (login != null)
                {
                    if (login.CustomerId != null && login.CustomerId.HasValue)
                    {
                        login.LoggedIn = 1;
                        
                        //Entities.Entry(login).CurrentValues.SetValues(login.LoginId);
                        Entities.CustomerLogins.Add(login);
                        Entities.Entry(login).State = System.Data.Entity.EntityState.Modified;
                        Entities.SaveChanges();
                        loginSucesss = true;
                    }
                }
                return loginSucesss;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error occured while loggin into application " + ex.Message);
            }
            return loginSucesss;
        }
    }
}
