using System;
using System.Collections.Generic;

namespace Immigration.Entity
{
    public partial class BorderPassRegister
    {
        public long Id { get; set; }
        public string? Surname { get; set; }
        public string? GivenName { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? Village { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public int? DocumentNo { get; set; }
        public string? Occupation { get; set; }
    }
}
