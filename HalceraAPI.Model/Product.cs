﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalceraAPI.Models
{
    /// <summary>
    /// Product model class
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Field has a minimum length of '2' and maximum length of '20'", MinimumLength = 2)]
        public string? Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Field has a minimum length of 10 and maximum length of '100'", MinimumLength = 10)]
        public string? Description { get; set; }

        /// <summary>
        /// if product is active
        /// </summary>
        public bool IsActive { get; set; } = true;

        [Required]
        public ICollection<Price>? Prices { get; set; }
        /// <summary>
        /// Featured Product
        /// </summary>
        public bool? IsFeatured { get; set; }

        /// <summary>
        /// Product Medias
        /// </summary>
        public ICollection<Media>? MediaCollection { get; set; }
        
        /// <summary>
        /// Product Ratings
        /// </summary>
        public ICollection<Rating>? ProductRatings { get; set; }

        /// <summary>
        /// Product Composition
        /// </summary>
        public ICollection<Composition>? ProductCompositions { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}
