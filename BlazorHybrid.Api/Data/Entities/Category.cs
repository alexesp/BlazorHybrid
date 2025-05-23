﻿using System.ComponentModel.DataAnnotations;

namespace BlazorHybrid.Api.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
