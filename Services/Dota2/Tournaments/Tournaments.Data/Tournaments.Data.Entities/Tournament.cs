using Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tournaments.Data.Entities.HelperTables;

namespace Tournaments.Data.Entities
{
    public class Tournament : IKeyIdentifier
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<TeamTournament> TeamTournament { get; set; }

        public IEnumerable<Series> Series { get; set; }
    }
}