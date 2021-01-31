using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<BP.Api.Data.Models.Contact, BP.Api.Models.ContactDVO>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ReverseMap();
        }
    }
}
