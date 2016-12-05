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
                ConfigureUsersChallengesMapping(cfg);
            });
        }

        private static void ConfigUsersMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));
        }

        private static void ConfigureChallengesMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Challenge, ChallengeViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            cfg.CreateMap<ChallengeViewModel, Challenge>();
        }

        private static void ConfigureUsersChallengesMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UsersChallenges, UsersChallengesViewModel>().ReverseMap();
        }

        // ... etc
    }
}