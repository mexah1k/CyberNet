using System.Collections.Generic;

namespace Tournaments.Dtos.Series
{
    public class SeriesForCreateDto
    {
        public int TournamentId { get; set; }

        public IEnumerable<int> MatchIds { get; set; }

        public int SeriesTypeId { get; set; }
    }
}