﻿using System;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class CitiesLocalization
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string CreatedByUserId { get; set; }
        public int LanguageId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual City City { get; set; }
    }
}
