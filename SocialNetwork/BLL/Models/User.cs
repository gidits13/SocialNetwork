﻿using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services.Models
{
    public class User
    {
        public IEnumerable<Message> IncomingMessages { get; }
        public IEnumerable<Message> OutgoingMessages { get; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string FavoriteMovie { get; set; }
        public string FavoriteBook { get; set; }

        public User(int id, string firstName, string lastName, string password, string email, string photo, string favoriteMovie, string favoriteBook,
            IEnumerable<Message> incomingMessages,
            IEnumerable<Message> outgoingMessages)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Photo = photo;
            FavoriteMovie = favoriteMovie;
            FavoriteBook = favoriteBook;
            IncomingMessages = incomingMessages;
            OutgoingMessages = outgoingMessages;
        }
    }
}