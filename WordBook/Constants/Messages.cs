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
        public const string CategoryCanNotBeDeleted = "This category cannot be deleted because there are words in this category!";
        public const string CategoryAlreadyExists = "This category already exists!";
        #endregion

        #region Types
        public const string TypesListed = "All types has been listed.";
        public const string TypeNotFound = "No types found.";
        public const string TypeAdded = "The type has been added.";
        public const string TypeUpdated = "The type has been updated.";
        public const string TypeDeleted = "The type has been deleted.";
        public const string TypeCanNotBeDeleted = "This type cannot be deleted because there are words in this type!";
        public const string TypeAlreadyExists = "This type already exists!";
        #endregion

        #region Boxes
        public const string BoxesListed = "All boxes has been listed.";
        public const string BoxNotFound = "No boxes found.";
        public const string BoxAdded = "The box has been added.";
        public const string BoxUpdated = "The box has been updated.";
        public const string BoxDeleted = "The box has been deleted.";
        public const string BoxCanNotBeDeleted = "This box cannot be deleted because there are words in this box!";
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

        #region AchievementTypes
        public const string AchievementTypesListed = "All achievement types has been listed.";
        public const string AchievementTypeNotFound = "No achievement types found.";
        public const string AchievementTypeAdded = "The achievement type has been added.";
        public const string AchievementTypeUpdated = "The achievement type has been updated.";
        public const string AchievementTypeDeleted = "The achievement type has been deleted.";
        public const string AchievementTypeCanNotBeDeleted = "This achievement type cannot be deleted because there are achievements in this achievement type!";
        public const string AchievementTypeAlreadyExists = "This achievement type already exists!";
        #endregion

        #region Achievements
        public const string AchievementsListed = "All achievements has been listed.";
        public const string AchievementNotFound = "No achievements found.";
        public const string AchievementAdded = "The achievement has been added.";
        public const string AchievementUpdated = "The achievement has been updated.";
        public const string AchievementDeleted = "The achievement has been deleted.";
        public const string AchievementAlreadyExists = "This achievement already exists!";
        #endregion

        #region RankTypes
        public const string RankTypesListed = "All rank types has been listed.";
        public const string RankTypeNotFound = "No rank types found.";
        public const string RankTypeAdded = "The rank type has been added.";
        public const string RankTypeUpdated = "The rank type has been updated.";
        public const string RankTypeDeleted = "The rank type has been deleted.";
        public const string RankTypeCanNotBeDeleted = "This rank type cannot be deleted because there are rankings in this rank type!";
        public const string RankTypeAlreadyExists = "This rank type already exists!";
        #endregion

        #region Rankings
        public const string RankingsListed = "All rankings has been listed.";
        public const string RankingsNotFound = "No rankings found.";
        public const string RankingAdded = "The ranking has been added.";
        public const string RankingUpdated = "The ranking has been updated.";
        public const string RankingDeleted = "The ranking has been deleted.";
        public const string RankingAlreadyExists = "This ranking already exists!";
        #endregion

        #region Contacts
        public const string ContactsListed = "All contacts has been listed.";
        public const string ContactsNotFound = "No contacts found.";
        public const string ContactAdded = "The contact has been added.";
        public const string ContactUpdated = "The contact has been updated.";
        public const string ContactDeleted = "The contact has been deleted.";
        public const string ContactAlreadyExists = "This contact already exists!";
        #endregion
    }
}
