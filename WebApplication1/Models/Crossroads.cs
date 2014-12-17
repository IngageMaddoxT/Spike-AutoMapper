using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace WebApplication1.Models
{
    public class CrossroadsTest
    {
        public string FirstName { get; set; }
        public string email { get; set; }
        public Household household { get; set; }

        public string GetSomething()
        {
            return "123";
        }

        public Dictionary<string,object> ToDictionary()
        {
            Mapper.CreateMap<Models.CrossroadsTest, Models.MinistryPlatformTest>()
                .ForMember(m => m.Email_Address, m => m.MapFrom(s => s.email));

            var destination = Mapper.Map<Models.MinistryPlatformTest>(this);

            var dictionary = destination.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(destination, null));

            return dictionary;
        }
    }

    public class Household
    {
        public string Address1 { get; set; }
    }
}