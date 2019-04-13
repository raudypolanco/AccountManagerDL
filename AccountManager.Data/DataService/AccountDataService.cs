﻿using AccountManager.Data.Core;
using AccountManager.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.DataService
{
    public class AccountDataService : DataServiceBase<Account, AccountManagerDBContext>
    {
        public AccountDataService(IMapper mapper, AccountManagerDBContext context) : base(mapper, context)
        {
        }
    }
}
