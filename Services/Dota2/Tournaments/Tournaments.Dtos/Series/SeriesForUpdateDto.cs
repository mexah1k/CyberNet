using System.Collections.Generic;
using Tournaments.Dtos.Match;

namespace Tournaments.Dtos.Series
{
    public class SeriesForUpdateDto
    {
        public IEnumerable<MatchDto> Matches { get; set; }
    }
}