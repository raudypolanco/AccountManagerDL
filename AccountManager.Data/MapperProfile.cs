using AccountManager.Data.Models;
using AccountManager.Data.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data
{
    public class MapperProfile
        : Profile 
    {

        public MapperProfile()
        {
            CreateMap<AccountType, ViewModelParent<int>>()
                .ForAllMembers(d=>d.Id, opt.MapFroms(S => S.Id))
                .ForAllMembers(d => d.Id, Description, (S => S.Id))
            CreateMap<AccountType, AccountTypeDTO>();
            CreateMap<AccountTypeDTO, AccountType>();
        }
            .ForMember(d => d.Accounts, opt => opt.Ignore());
            .ForMember(d => d.RowVersion, opt => opt.Ignore());
        }
    }
}
