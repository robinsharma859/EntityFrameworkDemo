using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Contracts
{
    interface IAuthticate
    {
        bool Authenticate(LoginModel loginModel);
        void ForgotPassword(LoginModel loginModel);
    }
}
