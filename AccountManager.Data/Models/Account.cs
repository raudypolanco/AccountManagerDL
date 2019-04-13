using AccountManager.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.Models
{
    public class Account: ModelBase<int>
    {
        public string Code { get; set; }
        public int Name { get; set; }

        public AccountType AccountType { get; set; }
        public int AccountTpeId { get; set; }

        //For view the account 

        
    }
}
