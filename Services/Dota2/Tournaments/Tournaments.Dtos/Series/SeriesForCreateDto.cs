using System.Collections.Generic;
using Tournaments.Dtos.Match;

namespace Tournaments.Dtos.Series
{
    public class SeriesForCreateDto
    {
        public int TournamentId { get; set; }

        public IEnumerable<MatchDto> Matches { get; set; }

        public int SeriesTypeId { get; set; }
    }
}