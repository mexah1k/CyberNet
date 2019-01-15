using Infrastructure.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournaments.Data.Entities
{
    public class Player : IKeyIdentifier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NickName { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public int Points { get; set; }

        public string PhotoUrl { get; set; }

        public string Country { get; set; } // todo: create table Countries

        public DateTime DateOfBirth { get; set; }

        public int? PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public Position Position { get; set; }

        public int? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
    }
}