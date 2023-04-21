﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        public int SellRent { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int PropertyTypeId { get; set; }

        public int BHK { get; set; }

        public int FurnishingTypeId { get; set; }

        public int Price { get; set; }

        public int BuiltArea { get; set; }

        public int CarpetArea { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [StringLength(30)]
        public string Address2 { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; } = null;

        public int FloorNo { get; set; }

        public int TotalFloors { get; set; }

        public bool ReadyToMove { get; set; }

        public string MainEntrance { get; set; }

        public int Security { get; set; }

        public bool Gated { get; set; }

        public int Maintenance { get; set; }

        public DateTime EstPossessionOn { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public DateTime PostedOn { get; set; } = DateTime.Now;

        public int PostedBy { get; set; }
    }
}