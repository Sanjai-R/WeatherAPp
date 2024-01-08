﻿using System;
using SQLite;

namespace DemoApp.Model
{
	public class UserModel
	{
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}

