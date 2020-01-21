using System;

using R5T.Lombardy;
using R5T.Peristeria;
using R5T.Visigothia;


namespace R5T.Bulgaria.Visigothia
{
    public class UserProfileDropboxDirectoryPathProvider : IDropboxDirectoryPathProvider
    {
        private IUserProfileDirectoryPathProvider UserProfileDirectoryPathProvider { get; }
        private IDropboxDirectoryNameConvention DropboxDirectoryNameConvention { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public UserProfileDropboxDirectoryPathProvider(
            IUserProfileDirectoryPathProvider userProfileDirectoryPathProvider,
            IDropboxDirectoryNameConvention dropboxDirectoryNameConvention,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.UserProfileDirectoryPathProvider = userProfileDirectoryPathProvider;
            this.DropboxDirectoryNameConvention = dropboxDirectoryNameConvention;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetDropboxDirectoryPath()
        {
            var userProfileDirectoryPath = this.UserProfileDirectoryPathProvider.GetUserProfileDirectoryPath();

            var dropboxDirectoryName = this.DropboxDirectoryNameConvention.GetDropboxDirectoryName();

            var dropboxDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(userProfileDirectoryPath, dropboxDirectoryName);
            return dropboxDirectoryPath;
        }
    }
}
