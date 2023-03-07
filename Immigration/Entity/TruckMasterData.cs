using System;
using System.Collections.Generic;

namespace Immigration.Entity
{
    public partial class TruckMasterData
    {
        public long Id { get; set; }
        public string? TruckLicencePlateNo { get; set; }
        public string? TruckType { get; set; }
        public string? CompanyName { get; set; }
    }
}
