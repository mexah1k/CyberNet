using System;
using System.Collections.Generic;
using Tournaments.Dtos.Series;
using Tournaments.Dtos.Team;

namespace Tournaments.Dtos.Tournament
{
    public class TournamentForUpdateDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<TeamDto> Teams { get; set; }

        public IEnumerable<SeriesDto> Series { get; set; }
    }
}