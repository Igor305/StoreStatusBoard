﻿using System;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopRegionLocalization
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int ShopRegionId { get; set; }
        public string CreatedByUserId { get; set; }
        public int LanguageId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual ShopRegion ShopRegion { get; set; }
    }
}
