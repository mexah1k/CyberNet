﻿using Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Tournaments.Data.Entities
{
    public class SeriesType : IKeyIdentifier
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}