﻿using System.ComponentModel.DataAnnotations;
namespace City.api.Models
{
    public class PointsOfIntrestForCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Description { get; set; }
    }
}
