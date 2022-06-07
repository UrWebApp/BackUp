using System;
using System.Collections.Generic;

namespace WebApplication1.EF
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] CreatedAt { get; set; }
    }
}
