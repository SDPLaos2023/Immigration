using System;
using System.Collections.Generic;

namespace Immigration.Entity
{
    public partial class PassportRegister
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? BirthCountry { get; set; }
        public int? DocumentNo { get; set; }
        public string? ImagePath { get; set; }
    }
}
