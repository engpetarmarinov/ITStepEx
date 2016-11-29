using AutoMapper;
using ChallengesProject.Models;
using ChallengesProject.ViewModels;

namespace ChallengesProject
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureChallengesMapping();
        }

        private static void ConfigureChallengesMapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Challenge, ChallengeViewModel>();
            });
        }

        // ... etc
    }
}