using Infrastructure.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournaments.Data.Entities
{
    public class Series : IKeyIdentifier
    {
        protected Series()
        {
            NumberOfMatches = SeriesType.Id;
        }

        [Key]
        public int Id { get; set; }

        public int TournamentId { get; set; }

        [ForeignKey(nameof(TournamentId))]
        public Tournament Tournament { get; set; }

        public IEnumerable<Match> Matches { get; set; }

        public int SeriesTypeId { get; set; }

        [ForeignKey(nameof(SeriesTypeId))]
        public SeriesType SeriesType { get; set; }

        public int NumberOfMatches { get; set; }

        public int? WinnerTeamId { get; set; }

        [ForeignKey(nameof(WinnerTeamId))]
        public Team WinnerTeam { get; set; }
    }
}