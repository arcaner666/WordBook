using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WordBook.Constants;
using WordBook.DatabaseModels;
using WordBook.Models.DTOs;
using WordBook.Models.Results;

namespace WordBook.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Registration
        [HttpPost("register")]
        public IResult Register(UserDto userDto)
        {
            using WordBookContext db = new();
            if (db.Users.Any(u => u.UserName == userDto.UserName))
            {
                return new ErrorResult(Messages.UserNameAlreadyInUse);
            }
            User user = new()
            {
                UserId = 0,
                UserName = userDto.UserName,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                DateOfBirth = userDto.DateOfBirth,
                Email = userDto.Email,
                Phone = userDto.Phone,
                IsActive = true,
                IsBlocked = false,
                IsAdmin = false,
                CreatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
                UpdatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
            };
            db.Users.Add(user);
            db.SaveChanges();
            return new SuccessResult(Messages.RegistrationSuccessful);
        }
        #endregion

        #region Login
        [HttpPost("login")]
        public IResult Login(UserDto userDto)
        {
            using WordBookContext db = new();
            UserDto responseUserDto = db.Users.Where(u => u.UserName == userDto.UserName && u.Password == userDto.Password).Select(user =>
            new UserDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Phone = user.Phone,
                IsActive = user.IsActive,
                IsBlocked = user.IsBlocked,
                IsAdmin = user.IsAdmin,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            }).SingleOrDefault();
            if (responseUserDto == null)
            {
                return new ErrorResult(Messages.UserNameOrPasswordInvalid);
            }
            return new SuccessDataResult<UserDto>(responseUserDto, Messages.LoginSuccessful);
        }
        #endregion

        #region Categories
        [HttpGet("getallcategoriesbyuserid/{userId}")]
        public IResult GetAllCategoriesByUserId(int userId)
        {
            using WordBookContext db = new();
            List<CategoryDto> categories = db.Categories.Where(c => c.UserId == userId).Select(category =>
            new CategoryDto
            {
                CategoryId = category.CategoryId,
                UserId = category.UserId,
                Name = category.Name
            }).ToList();
            if (!categories.Any())
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
            return new SuccessDataResult<List<CategoryDto>>(categories, Messages.CategoriesListed);
        }

        [HttpPost("addcategory")]
        public IResult AddCategory(CategoryDto categoryDto)
        {
            using WordBookContext db = new();
            if (db.Categories.Any(c => c.Name == categoryDto.Name))
            {
                return new ErrorResult(Messages.CategoryAlreadyExists);
            }
            Category addedCategory = new()
            {
                CategoryId = 0,
                UserId = categoryDto.UserId,
                Name = categoryDto.Name
            };
            db.Categories.Add(addedCategory);
            db.SaveChanges();
            return new SuccessResult(Messages.CategoryAdded);
        }

        [HttpPost("updatecategory")]
        public IResult UpdateCategory(CategoryDto categoryDto)
        {
            using WordBookContext db = new();
            Category updatedCategory = db.Categories.Where(c => c.CategoryId == categoryDto.CategoryId).SingleOrDefault();
            if (updatedCategory == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
            updatedCategory.Name = categoryDto.Name;
            db.SaveChanges();
            return new SuccessResult(Messages.CategoryUpdated);
        }

        [HttpPost("deletecategory")]
        public IResult DeleteCategory(CategoryDto categoryDto)
        {
            using WordBookContext db = new();
            Category deletedCategory = db.Categories.Where(c => c.CategoryId == categoryDto.CategoryId).SingleOrDefault();
            if (deletedCategory == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
            if (db.Words.Any(w => w.CategoryId == categoryDto.CategoryId))
            {
                return new ErrorResult(Messages.CategoryCanNotBeDeleted);
            }
            db.Categories.Remove(deletedCategory);
            db.SaveChanges();
            return new SuccessResult(Messages.CategoryDeleted);
        }
        #endregion

        #region Types
        [HttpGet("getalltypesbyuserid/{userId}")]
        public IResult GetAllTypesByUserId(int userId)
        {
            using WordBookContext db = new();
            List<TypeDto> types = db.Types.Where(t => t.UserId == userId).Select(type =>
            new TypeDto
            {
                TypeId = type.TypeId,
                UserId = type.UserId,
                Name = type.Name
            }).ToList();
            if (!types.Any())
            {
                return new ErrorResult(Messages.TypeNotFound);
            }
            return new SuccessDataResult<List<TypeDto>>(types, Messages.TypesListed);
        }

        [HttpPost("addtype")]
        public IResult AddType(TypeDto typeDto)
        {
            using WordBookContext db = new();
            if (db.Types.Any(t => t.Name == typeDto.Name))
            {
                return new ErrorResult(Messages.TypeAlreadyExists);
            }
            Type addedType = new()
            {
                TypeId = 0,
                UserId = typeDto.UserId,
                Name = typeDto.Name
            };
            db.Types.Add(addedType);
            db.SaveChanges();
            return new SuccessResult(Messages.TypeAdded);
        }

        [HttpPost("updatetype")]
        public IResult UpdateType(TypeDto typeDto)
        {
            using WordBookContext db = new();
            Type updatedType = db.Types.Where(t => t.TypeId == typeDto.TypeId).SingleOrDefault();
            if (updatedType == null)
            {
                return new ErrorResult(Messages.TypeNotFound);
            }
            updatedType.Name = typeDto.Name;
            db.SaveChanges();
            return new SuccessResult(Messages.TypeUpdated);
        }

        [HttpPost("deletetype")]
        public IResult DeleteType(TypeDto typeDto)
        {
            using WordBookContext db = new();
            Type deletedType = db.Types.Where(t => t.TypeId == typeDto.TypeId).SingleOrDefault();
            if (deletedType == null)
            {
                return new ErrorResult(Messages.TypeNotFound);
            }
            if (db.Words.Any(w => w.TypeId == typeDto.TypeId))
            {
                return new ErrorResult(Messages.TypeCanNotBeDeleted);
            }
            db.Types.Remove(deletedType);
            db.SaveChanges();
            return new SuccessResult(Messages.TypeDeleted);
        }
        #endregion

        #region Boxes
        [HttpGet("getallboxes")]
        public IResult GetAllBoxes()
        {
            using WordBookContext db = new();
            List<BoxDto> boxes = db.Boxes.Select(box =>
            new BoxDto
            {
                BoxId = box.BoxId,
                Name = box.Name
            }).ToList();
            if (!boxes.Any())
            {
                return new ErrorResult(Messages.BoxNotFound);
            }
            return new SuccessDataResult<List<BoxDto>>(boxes, Messages.BoxesListed);
        }

        [HttpPost("addbox")]
        public IResult AddBox(BoxDto boxDto)
        {
            using WordBookContext db = new();
            if (db.Boxes.Any(b => b.Name == boxDto.Name))
            {
                return new ErrorResult(Messages.BoxAlreadyExists);
            }
            Box addedBox = new()
            {
                BoxId = 0,
                Name = boxDto.Name
            };
            db.Boxes.Add(addedBox);
            db.SaveChanges();
            return new SuccessResult(Messages.BoxAdded);
        }

        [HttpPost("updatebox")]
        public IResult UpdateBox(BoxDto boxDto)
        {
            using WordBookContext db = new();
            Box updatedBox = db.Boxes.Where(b => b.BoxId == boxDto.BoxId).SingleOrDefault();
            if (updatedBox == null)
            {
                return new ErrorResult(Messages.BoxNotFound);
            }
            updatedBox.Name = boxDto.Name;
            db.SaveChanges();
            return new SuccessResult(Messages.BoxUpdated);
        }

        [HttpPost("deletebox")]
        public IResult DeleteBox(BoxDto boxDto)
        {
            using WordBookContext db = new();
            Box deletedBox = db.Boxes.Where(b => b.BoxId == boxDto.BoxId).SingleOrDefault();
            if (deletedBox == null)
            {
                return new ErrorResult(Messages.BoxNotFound);
            }
            if (db.Words.Any(w => w.BoxId == boxDto.BoxId))
            {
                return new ErrorResult(Messages.BoxCanNotBeDeleted);
            }
            db.Boxes.Remove(deletedBox);
            db.SaveChanges();
            return new SuccessResult(Messages.BoxDeleted);
        }
        #endregion

        #region Words
        [HttpGet("getallwordsbyuserid/{userId}")]
        public IResult GetAllWordsByUserId(int userId)
        {
            using WordBookContext db = new();
            List<WordDto> words = db.Words.Where(w => w.UserId == userId).Select(word =>
            new WordDto
            {
                WordId = word.WordId,
                UserId = word.UserId,
                CategoryId = word.CategoryId,
                TypeId = word.TypeId,
                BoxId = word.BoxId,
                Word1 = word.Word1,
                Meaning1 = word.Meaning1,
                Meaning2 = word.Meaning2,
                Meaning3 = word.Meaning3
            }).ToList();
            if (!words.Any())
            {
                return new ErrorResult(Messages.WordNotFound);
            }
            return new SuccessDataResult<List<WordDto>>(words, Messages.WordsListed);
        }

        [HttpPost("addword")]
        public IResult AddWord(WordDto wordDto)
        {
            using WordBookContext db = new();
            if (db.Words.Any(w => w.Word1 == wordDto.Word1))
            {
                return new ErrorResult(Messages.WordAlreadyExists);
            }
            if (!db.Categories.Any(c => c.CategoryId == wordDto.CategoryId))
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
            if (!db.Types.Any(t => t.TypeId == wordDto.TypeId))
            {
                return new ErrorResult(Messages.TypeNotFound);
            }
            if (!db.Boxes.Any(b => b.BoxId == wordDto.BoxId))
            {
                return new ErrorResult(Messages.BoxNotFound);
            }
            Word addedWord = new()
            {
                WordId = 0,
                UserId = wordDto.UserId,
                CategoryId = wordDto.CategoryId,
                TypeId = wordDto.TypeId,
                BoxId = wordDto.BoxId,
                Word1 = wordDto.Word1,
                Meaning1 = wordDto.Meaning1,
                Meaning2 = wordDto.Meaning2,
                Meaning3 = wordDto.Meaning3
            };
            db.Words.Add(addedWord);
            db.SaveChanges();
            return new SuccessResult(Messages.WordAdded);
        }

        [HttpPost("updateword")]
        public IResult UpdateWord(WordDto wordDto)
        {
            using WordBookContext db = new();
            Word updatedWord = db.Words.Where(w => w.WordId == wordDto.WordId).SingleOrDefault();
            if (updatedWord == null)
            {
                return new ErrorResult(Messages.WordNotFound);
            }
            updatedWord.CategoryId = wordDto.CategoryId;
            updatedWord.TypeId = wordDto.TypeId;
            updatedWord.BoxId = wordDto.BoxId;
            updatedWord.Word1 = wordDto.Word1;
            updatedWord.Meaning1 = wordDto.Meaning1;
            updatedWord.Meaning2 = wordDto.Meaning3;
            updatedWord.Meaning3 = wordDto.Meaning2;
            db.SaveChanges();
            return new SuccessResult(Messages.WordUpdated);
        }

        [HttpPost("deleteword")]
        public IResult DeleteWord(WordDto wordDto)
        {
            using WordBookContext db = new();
            Word deletedWord = db.Words.Where(w => w.WordId == wordDto.WordId).SingleOrDefault();
            if (deletedWord == null)
            {
                return new ErrorResult(Messages.WordNotFound);
            }
            db.Words.Remove(deletedWord);
            db.SaveChanges();
            return new SuccessResult(Messages.WordDeleted);
        }
        #endregion

        #region AchievementTypes
        [HttpGet("getallachievementtypes")]
        public IResult GetAllAchievementTypes()
        {
            using WordBookContext db = new();
            List<AchievementTypeDto> achievementTypes = db.AchievementTypes.Select(achievementType =>
            new AchievementTypeDto
            {
                AchievementTypeId = achievementType.AchievementTypeId,
                Name = achievementType.Name
            }).ToList();
            if (!achievementTypes.Any())
            {
                return new ErrorResult(Messages.AchievementTypeNotFound);
            }
            return new SuccessDataResult<List<AchievementTypeDto>>(achievementTypes, Messages.AchievementTypesListed);
        }

        [HttpPost("addachievementtype")]
        public IResult AddAchievementType(AchievementTypeDto achievementTypeDto)
        {
            using WordBookContext db = new();
            if (db.AchievementTypes.Any(a => a.Name == achievementTypeDto.Name))
            {
                return new ErrorResult(Messages.AchievementTypeAlreadyExists);
            }
            AchievementType addedAchievementType = new()
            {
                AchievementTypeId = 0,
                Name = achievementTypeDto.Name
            };
            db.AchievementTypes.Add(addedAchievementType);
            db.SaveChanges();
            return new SuccessResult(Messages.AchievementTypeAdded);
        }

        [HttpPost("updateachievementtype")]
        public IResult UpdateAchievementType(AchievementTypeDto achievementTypeDto)
        {
            using WordBookContext db = new();
            AchievementType updatedAchievementType = db.AchievementTypes.Where(a => a.AchievementTypeId == achievementTypeDto.AchievementTypeId).SingleOrDefault();
            if (updatedAchievementType == null)
            {
                return new ErrorResult(Messages.AchievementTypeNotFound);
            }
            updatedAchievementType.Name = achievementTypeDto.Name;
            db.SaveChanges();
            return new SuccessResult(Messages.AchievementTypeUpdated);
        }

        [HttpPost("deleteachievementtype")]
        public IResult DeleteAchievementType(AchievementTypeDto achievementTypeDto)
        {
            using WordBookContext db = new();
            AchievementType deletedAchievementType = db.AchievementTypes.Where(a => a.AchievementTypeId == achievementTypeDto.AchievementTypeId).SingleOrDefault();
            if (deletedAchievementType == null)
            {
                return new ErrorResult(Messages.AchievementTypeNotFound);
            }
            if (db.Achievements.Any(a => a.AchievementTypeId == achievementTypeDto.AchievementTypeId))
            {
                return new ErrorResult(Messages.AchievementTypeCanNotBeDeleted);
            }
            db.AchievementTypes.Remove(deletedAchievementType);
            db.SaveChanges();
            return new SuccessResult(Messages.AchievementTypeDeleted);
        }
        #endregion

        #region Achievements
        [HttpGet("getallachievementsbyuserid/{userId}")]
        public IResult GetAllAchievementsByUserId(int userId)
        {
            using WordBookContext db = new();
            List<AchievementDto> achievements = db.Achievements.Where(a => a.UserId == userId).Select(achievement =>
            new AchievementDto
            {
                AchievementId = achievement.AchievementId,
                UserId = achievement.UserId,
                AchievementTypeId = achievement.AchievementTypeId,
                Score = achievement.Score,
                UpdatedAt = achievement.UpdatedAt
            }).ToList();
            if (!achievements.Any())
            {
                return new ErrorResult(Messages.AchievementNotFound);
            }
            return new SuccessDataResult<List<AchievementDto>>(achievements, Messages.AchievementsListed);
        }

        [HttpPost("addachievement")]
        public IResult AddAchievement(AchievementDto achievementDto)
        {
            using WordBookContext db = new();
            if (db.Achievements.Any(a => a.AchievementTypeId == achievementDto.AchievementTypeId))
            {
                return new ErrorResult(Messages.AchievementAlreadyExists);
            }
            Achievement addedAchievement = new()
            {
                AchievementId = 0,
                UserId = achievementDto.UserId,
                AchievementTypeId = achievementDto.AchievementTypeId,
                Score = achievementDto.Score,
                UpdatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
            };
            db.Achievements.Add(addedAchievement);
            db.SaveChanges();
            return new SuccessResult(Messages.AchievementAdded);
        }

        [HttpPost("updateachievement")]
        public IResult UpdateAchievement(AchievementDto achievementDto)
        {
            using WordBookContext db = new();
            Achievement updatedAchievement = db.Achievements.Where(a => a.AchievementId == achievementDto.AchievementId).SingleOrDefault();
            if (updatedAchievement == null)
            {
                return new ErrorResult(Messages.AchievementNotFound);
            }
            updatedAchievement.AchievementTypeId = achievementDto.AchievementTypeId;
            updatedAchievement.Score = achievementDto.Score;
            updatedAchievement.UpdatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            db.SaveChanges();
            return new SuccessResult(Messages.AchievementUpdated);
        }

        [HttpPost("deleteachievement")]
        public IResult DeleteAchievement(AchievementDto achievementDto)
        {
            using WordBookContext db = new();
            Achievement deletedAchievement = db.Achievements.Where(a => a.AchievementId == achievementDto.AchievementId).SingleOrDefault();
            if (deletedAchievement == null)
            {
                return new ErrorResult(Messages.AchievementNotFound);
            }
            db.Achievements.Remove(deletedAchievement);
            db.SaveChanges();
            return new SuccessResult(Messages.AchievementDeleted);
        }
        #endregion

        #region RankTypes
        [HttpGet("getallranktypes")]
        public IResult GetAllRankTypes()
        {
            using WordBookContext db = new();
            List<RankTypeDto> rankTypes = db.RankTypes.Select(rankType =>
            new RankTypeDto
            {
                RankTypeId = rankType.RankTypeId,
                Name = rankType.Name
            }).ToList();
            if (!rankTypes.Any())
            {
                return new ErrorResult(Messages.RankTypeNotFound);
            }
            return new SuccessDataResult<List<RankTypeDto>>(rankTypes, Messages.RankTypesListed);
        }

        [HttpPost("addranktype")]
        public IResult AddRankType(RankTypeDto rankTypeDto)
        {
            using WordBookContext db = new();
            if (db.RankTypes.Any(r => r.Name == rankTypeDto.Name))
            {
                return new ErrorResult(Messages.RankTypeAlreadyExists);
            }
            RankType addedRankType = new()
            {
                RankTypeId = 0,
                Name = rankTypeDto.Name
            };
            db.RankTypes.Add(addedRankType);
            db.SaveChanges();
            return new SuccessResult(Messages.RankTypeAdded);
        }

        [HttpPost("updateranktype")]
        public IResult UpdateRankType(RankTypeDto rankTypeDto)
        {
            using WordBookContext db = new();
            RankType updatedRankType = db.RankTypes.Where(r => r.RankTypeId == rankTypeDto.RankTypeId).SingleOrDefault();
            if (updatedRankType == null)
            {
                return new ErrorResult(Messages.RankTypeNotFound);
            }
            updatedRankType.Name = rankTypeDto.Name;
            db.SaveChanges();
            return new SuccessResult(Messages.RankTypeUpdated);
        }

        [HttpPost("deleteranktype")]
        public IResult DeleteRankType(RankTypeDto rankTypeDto)
        {
            using WordBookContext db = new();
            RankType deletedRankType = db.RankTypes.Where(r => r.RankTypeId == rankTypeDto.RankTypeId).SingleOrDefault();
            if (deletedRankType == null)
            {
                return new ErrorResult(Messages.RankTypeNotFound);
            }
            if (db.Rankings.Any(r => r.RankTypeId == rankTypeDto.RankTypeId))
            {
                return new ErrorResult(Messages.RankTypeCanNotBeDeleted);
            }
            db.RankTypes.Remove(deletedRankType);
            db.SaveChanges();
            return new SuccessResult(Messages.RankTypeDeleted);
        }
        #endregion

        #region Rankings
        [HttpGet("getallrankings")]
        public IResult GetAllRankings()
        {
            using WordBookContext db = new();
            List<RankingDto> rankings = db.Rankings.Select(ranking =>
            new RankingDto
            {
                RankId = ranking.RankTypeId,
                UserId = ranking.UserId,
                RankTypeId = ranking.RankTypeId,
                Score = ranking.Score,
                UpdatedAt = ranking.UpdatedAt
            }).ToList();
            if (!rankings.Any())
            {
                return new ErrorResult(Messages.RankingsNotFound);
            }
            return new SuccessDataResult<List<RankingDto>>(rankings, Messages.RankingsListed);
        }

        [HttpPost("addranking")]
        public IResult AddRanking(RankingDto rankingDto)
        {
            using WordBookContext db = new();
            if (db.Rankings.Any(r => r.RankTypeId == rankingDto.RankTypeId))
            {
                return new ErrorResult(Messages.RankingAlreadyExists);
            }
            Ranking addedRanking = new()
            {
                RankId = 0,
                UserId = rankingDto.UserId,
                RankTypeId = rankingDto.RankTypeId,
                Score = rankingDto.Score,
                UpdatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
            };
            db.Rankings.Add(addedRanking);
            db.SaveChanges();
            return new SuccessResult(Messages.RankingAdded);
        }

        [HttpPost("updateranking")]
        public IResult UpdateRanking(RankingDto rankingDto)
        {
            using WordBookContext db = new();
            Ranking updatedRanking = db.Rankings.Where(r => r.RankId == rankingDto.RankId).SingleOrDefault();
            if (updatedRanking == null)
            {
                return new ErrorResult(Messages.RankingsNotFound);
            }
            updatedRanking.UserId = rankingDto.UserId;
            updatedRanking.RankTypeId = rankingDto.RankTypeId;
            updatedRanking.Score = rankingDto.Score;
            updatedRanking.UpdatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            db.SaveChanges();
            return new SuccessResult(Messages.RankingUpdated);
        }

        [HttpPost("deleteranking")]
        public IResult DeleteRanking(RankingDto rankingDto)
        {
            using WordBookContext db = new();
            Ranking deletedRanking = db.Rankings.Where(r => r.RankId == rankingDto.RankId).SingleOrDefault();
            if (deletedRanking == null)
            {
                return new ErrorResult(Messages.RankingsNotFound);
            }
            db.Rankings.Remove(deletedRanking);
            db.SaveChanges();
            return new SuccessResult(Messages.RankingDeleted);
        }
        #endregion

        #region Contacts
        [HttpGet("getallcontactsbyuserid/{userId}")]
        public IResult GetAllContactsByUserId(int userId)
        {
            using WordBookContext db = new();
            List<ContactDto> contacts = db.Contacts.Where(c => c.UserId == userId).Select(contact =>
            new ContactDto
            {
                ContactId = contact.ContactId,
                UserId = contact.UserId,
                FriendId = contact.FriendId,
                CreatedAt = contact.CreatedAt
            }).ToList();
            if (!contacts.Any())
            {
                return new ErrorResult(Messages.ContactsNotFound);
            }
            return new SuccessDataResult<List<ContactDto>>(contacts, Messages.ContactsListed);
        }

        [HttpPost("addcontact")]
        public IResult AddContact(ContactDto contactDto)
        {
            using WordBookContext db = new();
            if (db.Contacts.Any(c => c.FriendId == contactDto.FriendId))
            {
                return new ErrorResult(Messages.ContactAlreadyExists);
            }
            Contact addedContact = new()
            {
                ContactId = 0,
                UserId = contactDto.UserId,
                FriendId = contactDto.FriendId,
                CreatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
            };
            db.Contacts.Add(addedContact);
            db.SaveChanges();
            return new SuccessResult(Messages.ContactAdded);
        }

        [HttpPost("updatecontact")]
        public IResult UpdateContact(ContactDto contactDto)
        {
            using WordBookContext db = new();
            Contact updatedContact = db.Contacts.Where(c => c.ContactId == contactDto.ContactId).SingleOrDefault();
            if (updatedContact == null)
            {
                return new ErrorResult(Messages.ContactsNotFound);
            }
            updatedContact.FriendId = contactDto.FriendId;
            updatedContact.CreatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            db.SaveChanges();
            return new SuccessResult(Messages.ContactUpdated);
        }

        [HttpPost("deletecontact")]
        public IResult DeleteContact(ContactDto contactDto)
        {
            using WordBookContext db = new();
            Contact deletedContact = db.Contacts.Where(c => c.ContactId == contactDto.ContactId).SingleOrDefault();
            if (deletedContact == null)
            {
                return new ErrorResult(Messages.ContactsNotFound);
            }
            db.Contacts.Remove(deletedContact);
            db.SaveChanges();
            return new SuccessResult(Messages.ContactDeleted);
        }
        #endregion

        #region Messages
        [HttpGet("getallmessagesbyreceiverid/{receiverId}")]
        public IResult GetAllMessagesByReceiverId(int receiverId)
        {
            using WordBookContext db = new();
            List<MessageDto> messages = db.Messages.Where(m => m.ReceiverId == receiverId).Select(message =>
            new MessageDto
            {
                MessageId = message.MessageId,
                SenderId = message.SenderId,
                ReceiverId = message.ReceiverId,
                Message1 = message.Message1,
                CreatedAt = message.CreatedAt
            }).ToList();
            if (!messages.Any())
            {
                return new ErrorResult(Messages.MessagesNotFound);
            }
            return new SuccessDataResult<List<MessageDto>>(messages, Messages.MessagesListed);
        }

        [HttpPost("sendmessage")]
        public IResult SendMessage(MessageDto messageDto)
        {
            using WordBookContext db = new();
            Message sentMessage = new()
            {
                MessageId = 0,
                SenderId = messageDto.SenderId,
                ReceiverId = messageDto.ReceiverId,
                Message1 = messageDto.Message1,
                CreatedAt = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
            };
            db.Messages.Add(sentMessage);
            db.SaveChanges();
            return new SuccessResult(Messages.MessageSent);
        }

        [HttpPost("deletemessage")]
        public IResult DeleteMessage(MessageDto messageDto)
        {
            using WordBookContext db = new();
            Message deletedMessage = db.Messages.Where(m => m.MessageId == messageDto.MessageId).SingleOrDefault();
            if (deletedMessage == null)
            {
                return new ErrorResult(Messages.MessagesNotFound);
            }
            db.Messages.Remove(deletedMessage);
            db.SaveChanges();
            return new SuccessResult(Messages.MessageDeleted);
        }
        #endregion
    }
}
