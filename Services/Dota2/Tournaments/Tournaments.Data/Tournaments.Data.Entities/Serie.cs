using Infrastructure.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournaments.Data.Entities
{
    public class Serie : IKeyIdentifier
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public IEnumerable<Match> Matches { get; set; }
    }
}