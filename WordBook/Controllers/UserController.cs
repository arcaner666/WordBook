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
            if (db.Users.Any(a => a.UserName == userDto.UserName))
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
            if (db.Categories.Any(a => a.Name == categoryDto.Name))
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
            Category updatedCategory = db.Categories.Where(a => a.CategoryId == categoryDto.CategoryId).SingleOrDefault();
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
            Category deletedCategory = db.Categories.Where(a => a.CategoryId == categoryDto.CategoryId).SingleOrDefault();
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
            List<TypeDto> types = db.Types.Where(c => c.UserId == userId).Select(type =>
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
            if (db.Types.Any(a => a.Name == typeDto.Name))
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
            Type updatedType = db.Types.Where(a => a.TypeId == typeDto.TypeId).SingleOrDefault();
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
            Type deletedType = db.Types.Where(a => a.TypeId == typeDto.TypeId).SingleOrDefault();
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
            if (db.Boxes.Any(a => a.Name == boxDto.Name))
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
            if (!db.Categories.Any(w => w.CategoryId == wordDto.CategoryId))
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
            if (!db.Types.Any(w => w.TypeId == wordDto.TypeId))
            {
                return new ErrorResult(Messages.TypeNotFound);
            }
            if (!db.Boxes.Any(w => w.BoxId == wordDto.BoxId))
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
    }
}
