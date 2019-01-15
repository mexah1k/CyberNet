using System.Collections.Generic;
using Tournaments.Dtos.Match;

namespace Tournaments.Dtos.Series
{
    public class SeriesDto
    {
        public int Id { get; set; }

        public int TournamentId { get; set; }

        public IEnumerable<MatchDto> Matches { get; set; }

        public int SeriesTypeId { get; set; }
    }
}