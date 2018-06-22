using System;

namespace Tournaments.Dtos.Tournament
{
    public class TournamentForCreatinDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}