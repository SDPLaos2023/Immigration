using System;
using System.Collections.Generic;

namespace Immigration.Entity
{
    public partial class SystemUser
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? UserId { get; set; }
    }
}
