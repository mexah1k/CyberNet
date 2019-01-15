using System;
using System.ComponentModel.DataAnnotations;

namespace Tournaments.Data.Contracts.Filters
{
    public class TournamentFilter
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}