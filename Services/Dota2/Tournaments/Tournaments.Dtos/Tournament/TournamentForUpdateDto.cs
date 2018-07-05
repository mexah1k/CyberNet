using System;
using System.Collections.Generic;

namespace Tournaments.Dtos.Tournament
{
    public class TournamentForUpdateDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}