using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Constants
{
    public static class Messages
    {
        #region Registration
        public const string RegistrationSuccessful = "Registration is successful.";
        public const string UserNameAlreadyInUse = "This user name is already in use!";
        #endregion

        #region Login
        public const string LoginSuccessful = "Login is successful.";
        public const string UserNameOrPasswordInvalid = "User name or password is invalid!";
        #endregion

        #region Categories
        public const string CategoriesListed = "All categories has been listed.";
        public const string CategoryNotFound = "No categories found.";
        public const string CategoryAdded = "The category has been added.";
        public const string CategoryUpdated = "The category has been updated.";
        public const string CategoryDeleted = "The category has been deleted.";
        public const string CategoryAlreadyExists = "This category already exists!";
        #endregion

        #region Types
        public const string TypesListed = "All types has been listed.";
        public const string TypeNotFound = "No types found.";
        public const string TypeAdded = "The type has been added.";
        public const string TypeUpdated = "The type has been updated.";
        public const string TypeDeleted = "The type has been deleted.";
        public const string TypeAlreadyExists = "This type already exists!";
        #endregion

        #region Boxes
        public const string BoxesListed = "All boxes has been listed.";
        public const string BoxNotFound = "No boxes found.";
        public const string BoxAdded = "The box has been added.";
        public const string BoxUpdated = "The box has been updated.";
        public const string BoxDeleted = "The box has been deleted.";
        public const string BoxAlreadyExists = "This box already exists!";
        #endregion

        #region Words
        public const string WordsListed = "All words has been listed.";
        public const string WordNotFound = "No words found.";
        public const string WordAdded = "The word has been added.";
        public const string WordUpdated = "The word has been updated.";
        public const string WordDeleted = "The word has been deleted.";
        public const string WordAlreadyExists = "This word already exists!";
        #endregion
    }
}
