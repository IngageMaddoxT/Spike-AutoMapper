using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace WebApplication1.Models.Crossroads
{
    public class PersonalInfo
    {
        public string ContactId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaritalStatusId { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            Mapper.CreateMap<Models.Crossroads.PersonalInfo, Models.MinistryPlatform.Contact>()
                .ForMember(m => m.Email_Address, m => m.MapFrom(s => s.Email));

            var destination = Mapper.Map<Models.MinistryPlatform.Contact>(this);

            var dictionary = destination.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(destination, null));

            return dictionary;
        }
    }
}