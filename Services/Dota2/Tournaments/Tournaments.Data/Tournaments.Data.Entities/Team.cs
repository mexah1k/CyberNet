using Infrastructure.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Tournaments.Data.Entities.HelperTables;

namespace Tournaments.Data.Entities
{
    public class Team : IKeyIdentifier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }

        public decimal Revenue { get; set; }

        public IEnumerable<Player> Players { get; set; }

        public IEnumerable<Match> Matches { get; set; }

        public IEnumerable<TeamTournament> TeamTournament { get; set; }

        public int GetPoints()
        {
            if (!Players.Any())
                return 0;

            return Players
                .OrderBy(p => p.Points)
                .Take(3) // TODO: Move number 3 to config file
                .Sum(p => p.Points);
        }
    }
}