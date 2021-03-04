﻿using System;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopObjectComplexityHistory
    {
        public int Id { get; set; }
        public string UpdatedByUser { get; set; }
        public string FieldName { get; set; }
        public string FieldOldValue { get; set; }
        public string FieldNewValue { get; set; }
        public DateTime UpdateDate { get; set; }
        public string TransactionId { get; set; }
        public int ShopObjectComplexityId { get; set; }
        public int ShopId { get; set; }
    }
}
