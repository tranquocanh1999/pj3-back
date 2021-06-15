﻿using Project3.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.DataLayer.Interfaces
{
    public interface IAuthentication
    {

    
        Employee Login(string email , string password);
        int ChangePass(string email, string password);
    }
}
