using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Peristeria;
using R5T.Visigothia;


namespace R5T.Bulgaria.Visigothia
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Adds the <see cref="UserProfileDropboxDirectoryPathProvider"/> implementation of <see cref="IDropboxDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddUserProfileDropboxDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IUserProfileDirectoryPathProvider> addUserProfileDirectoryPathProvider,
            ServiceAction<IDropboxDirectoryNameConvention> addDropboxDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<IDropboxDirectoryPathProvider, UserProfileDropboxDirectoryPathProvider>()
                .RunServiceAction(addUserProfileDirectoryPathProvider)
                .RunServiceAction(addDropboxDirectoryNameConvention)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="UserProfileDropboxDirectoryPathProvider"/> implementation of <see cref="IDropboxDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IDropboxDirectoryPathProvider> AddUserProfileDropboxDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IUserProfileDirectoryPathProvider> addUserProfileDirectoryPathProvider,
            ServiceAction<IDropboxDirectoryNameConvention> addDropboxDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<IDropboxDirectoryPathProvider>(() => services.AddUserProfileDropboxDirectoryPathProvider(
                addUserProfileDirectoryPathProvider,
                addDropboxDirectoryNameConvention,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}
