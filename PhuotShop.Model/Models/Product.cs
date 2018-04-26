﻿using PhuotShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PhuotShop.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }
        [Required]
        public int CategoryID { set; get; }
        [MaxLength(256)]
        public string Image { get; set; }
        public XElement MoreImages { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

    }
}