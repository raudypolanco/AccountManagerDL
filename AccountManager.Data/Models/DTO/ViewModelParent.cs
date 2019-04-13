using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.Models.DTO
{
    public class ViewModelParent<TId>
    {
        public TId Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
