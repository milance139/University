﻿namespace Api.Models
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       
    }
}
