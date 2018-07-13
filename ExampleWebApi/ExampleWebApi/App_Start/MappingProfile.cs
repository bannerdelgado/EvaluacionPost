using AutoMapper;
using ExampleWebApi.Models;
using ExampleWebApi.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleWebApi.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
          
        }      
    }
}