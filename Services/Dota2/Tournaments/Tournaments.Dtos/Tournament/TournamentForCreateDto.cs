using System;

namespace Tournaments.Dtos.Tournament
{
    public class TournamentForCreateDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}