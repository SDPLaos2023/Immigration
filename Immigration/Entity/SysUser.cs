using System;
using System.Collections.Generic;

namespace Immigration.Entity
{
    public partial class SysUser
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? UserId { get; set; }
        public string? SystemRole { get; set; }
    }
}
