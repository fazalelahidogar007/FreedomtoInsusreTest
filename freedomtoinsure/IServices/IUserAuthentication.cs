﻿using freedomtoinsure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freedomtoinsure.IServices
{
    interface IUserAuthentication
    {
        string Authenticate(Authentication loginData);
    }
}