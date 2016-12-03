using System;
using AutoMapper;
using ChallengesProject.Models;
using ChallengesProject.ViewModels;

namespace ChallengesProject
{
    public static class AutoMapperWebConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                ConfigureChallengesMapping(cfg);
                ConfigUsersMapping(cfg);
            });
        }

        private static void ConfigUsersMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));
        }

        private static void ConfigureChallengesMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Challenge, ChallengeViewModel>().ReverseMap();
        }

        // ... etc
    }
}