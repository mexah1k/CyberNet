﻿using System.ComponentModel.DataAnnotations;

namespace Teams.Data.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}