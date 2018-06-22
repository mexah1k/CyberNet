using System;

namespace Tournaments.Dtos.Tournament
{
    public class TournamentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}