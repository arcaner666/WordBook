using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBook.Constants
{
    public static class Messages
    {
        #region Startup
        public const string StartupComplete = "The startup process have been completed.";
        #endregion

        #region Registration
        public const string RegistrationSuccessful = "Registration is successful.";
        public const string UserNameAlreadyInUse = "This user name is already in use!";
        #endregion

        #region Login
        public const string LoginSuccessful = "Login is successful.";
        public const string UserNameOrPasswordInvalid = "User name or password is invalid!";
        #endregion

        #region Categories
        public const string CategoriesListed = "Categories have been listed.";
        public const string CategoryNotFound = "The category is not found.";
        public const string CategoryAdded = "The category has been added.";
        public const string CategoryUpdated = "The category has been updated.";
        public const string CategoryDeleted = "The category has been deleted.";
        public const string CategoryAlreadyExists = "This category already exists!";
        public const string CanNotDeleteCategoryDueToWords = "This category cannot be deleted because there are words in this category!";
        public const string CanNotUpdateSystemCategories = "System categories cannot be updated!";
        public const string CanNotDeleteSystemCategories = "System categories cannot be deleted!";
        #endregion

        #region Types
        public const string TypesListed = "Types have been listed.";
        public const string TypeNotFound = "The type is not found.";
        public const string TypeAdded = "The type has been added.";
        public const string TypeUpdated = "The type has been updated.";
        public const string TypeDeleted = "The type has been deleted.";
        public const string TypeAlreadyExists = "This type already exists!";
        public const string CanNotDeleteTypeDueToWords = "This type cannot be deleted because there are words in this type!";
        public const string CanNotUpdateSystemTypes = "System types cannot be updated!";
        public const string CanNotDeleteSystemTypes = "System types cannot be deleted!";
        #endregion

        #region Boxes
        public const string BoxesListed = "Boxes have been listed.";
        public const string BoxNotFound = "The box is not found.";
        public const string BoxAdded = "The box has been added.";
        public const string BoxUpdated = "The box has been updated.";
        public const string BoxDeleted = "The box has been deleted.";
        public const string BoxCanNotBeDeleted = "This box cannot be deleted because there are words in this box!";
        public const string BoxAlreadyExists = "This box already exists!";
        #endregion

        #region Words
        public const string WordsListed = "Words have been listed.";
        public const string WordNotFound = "The word is not found.";
        public const string WordAdded = "The word has been added.";
        public const string WordUpdated = "The word has been updated.";
        public const string WordDeleted = "The word has been deleted.";
        public const string WordAlreadyExists = "This word already exists!";
        #endregion

        #region AchievementTypes
        public const string AchievementTypesListed = "Achievement types have been listed.";
        public const string AchievementTypeNotFound = "The achievement type is not found.";
        public const string AchievementTypeAdded = "The achievement type has been added.";
        public const string AchievementTypeUpdated = "The achievement type has been updated.";
        public const string AchievementTypeDeleted = "The achievement type has been deleted.";
        public const string AchievementTypeCanNotBeDeleted = "This achievement type cannot be deleted because there are achievements in this achievement type!";
        public const string AchievementTypeAlreadyExists = "This achievement type already exists!";
        #endregion

        #region Achievements
        public const string AchievementsListed = "Achievements have been listed.";
        public const string AchievementNotFound = "The achievement is not found.";
        public const string AchievementAdded = "The achievement has been added.";
        public const string AchievementUpdated = "The achievement has been updated.";
        public const string AchievementDeleted = "The achievement has been deleted.";
        public const string AchievementAlreadyExists = "This achievement already exists!";
        #endregion

        #region RankTypes
        public const string RankTypesListed = "Rank types have been listed.";
        public const string RankTypeNotFound = "The rank type is not found.";
        public const string RankTypeAdded = "The rank type has been added.";
        public const string RankTypeUpdated = "The rank type has been updated.";
        public const string RankTypeDeleted = "The rank type has been deleted.";
        public const string RankTypeCanNotBeDeleted = "This rank type cannot be deleted because there are rankings in this rank type!";
        public const string RankTypeAlreadyExists = "This rank type already exists!";
        #endregion

        #region Rankings
        public const string RankingsListed = "Rankings have been listed.";
        public const string RankingNotFound = "The ranking is not found.";
        public const string RankingAdded = "The ranking has been added.";
        public const string RankingUpdated = "The ranking has been updated.";
        public const string RankingDeleted = "The ranking has been deleted.";
        public const string RankingAlreadyExists = "This ranking already exists!";
        #endregion

        #region ContactRequests
        public const string ContactRequestsListed = "Contact requests have been listed.";
        public const string ContactRequestNotFound = "The contact request is not found.";
        public const string ContactRequestSent = "The contact request has been sent.";
        public const string ContactRequestConfirmed = "The contact request has been confirmed.";
        public const string ContactRequestDeleted = "The contact request has been deleted.";
        public const string ContactRequestAlreadySent = "This contact request is already sent!";
        #endregion

        #region Contacts
        public const string ContactsListed = "Contacts have been listed.";
        public const string ContactNotFound = "The contact is not found.";
        public const string ContactAdded = "The contact has been added.";
        public const string ContactUpdated = "The contact has been updated.";
        public const string ContactDeleted = "The contact has been deleted.";
        public const string ContactAlreadyExists = "This contact already exists!";
        #endregion

        #region Messages
        public const string MessagesListed = "Messages have been listed.";
        public const string MessageNotFound = "The message is not found.";
        public const string MessageSent = "The message has been sent.";
        public const string MessageDeleted = "The message has been deleted.";
        #endregion

        #region SharedWords
        public const string SharedWordsListed = "Shared words have been listed.";
        public const string SharedWordNotFound = "The shared word is not found.";
        public const string WordShared = "The word has been shared.";
        public const string SharedWordConfirmed = "The shared word has been confirmed and added to words.";
        public const string SharedWordDeleted = "The shared word has been deleted.";
        #endregion
    }
}
