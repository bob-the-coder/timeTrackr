using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using BusinessLogic.Models;

namespace BusinessLogic.TypeManagement
{
    public static class DasConfigurator
    {
        internal static void ConfigureUser(IMapperConfiguration config)
        {
            config.CreateMap<DataLayer.User, User>();

            config.CreateMap<User, DataLayer.User>()
                .ForMember(m => m.Projects, o => o.Ignore())
                .ForMember(m => m.AuthTokens, o => o.Ignore());
        }

        internal static void ConfigureProject(IMapperConfiguration config)
        {
            config.CreateMap<DataLayer.Project, Project>();

            config.CreateMap<Project, DataLayer.Project>()
                .ForMember(m => m.User, o => o.Ignore())
                .ForMember(m => m.Commits, o => o.Ignore());
        }

        internal static void ConfigureCommit(IMapperConfiguration config)
        {
            config.CreateMap<DataLayer.Commit, Commit>();

            config.CreateMap<Commit, DataLayer.Commit>()
                .ForMember(m => m.Project, o => o.Ignore());
        }

        internal static void ConfigureAuthToken(IMapperConfiguration config)
        {
            config.CreateMap<DataLayer.AuthToken, AuthToken>();

            config.CreateMap<AuthToken, DataLayer.AuthToken>()
                .ForMember(m => m.User, o => o.Ignore());
        }

        #region Item configuration extension methods

        private static void Configure<T>(this IEnumerable<T> items, Action<T> applyConfiguration)
        {
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                applyConfiguration(item);
            }
        }

        private static void Configure<T>(this T item, Action<T> applyConfiguration)
        {
            if (item == null)
            {
                return;
            }

            applyConfiguration(item);
        }

        #endregion
    }
}