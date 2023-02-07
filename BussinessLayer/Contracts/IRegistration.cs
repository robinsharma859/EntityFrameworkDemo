using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Contracts
{
    interface IRegistration
    {
       
        void SaveDetails(ViewModel registration);
        object GetUserInformation(ViewModel registration);
        object GetUserInformation();
    }
}
