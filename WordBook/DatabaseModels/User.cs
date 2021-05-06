using System;
using System.Collections.Generic;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class User
    {
        public User()
        {
            Achievements = new HashSet<Achievement>();
            Categories = new HashSet<Category>();
            ContactFriends = new HashSet<Contact>();
            ContactUsers = new HashSet<Contact>();
            MessageReceivers = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
            Rankings = new HashSet<Ranking>();
            SharedWordReceivers = new HashSet<SharedWord>();
            SharedWordSenders = new HashSet<SharedWord>();
            Types = new HashSet<Type>();
            Words = new HashSet<Word>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAdmin { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Contact> ContactFriends { get; set; }
        public virtual ICollection<Contact> ContactUsers { get; set; }
        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<SharedWord> SharedWordReceivers { get; set; }
        public virtual ICollection<SharedWord> SharedWordSenders { get; set; }
        public virtual ICollection<Type> Types { get; set; }
        public virtual ICollection<Word> Words { get; set; }
    }
}
