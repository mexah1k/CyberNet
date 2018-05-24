using Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournaments.Data.Entities
{
    public class Match : IKeyIdentifier
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Serie))]
        public int SerieId { get; set; }

        public Serie Serie { get; set; }

        [ForeignKey(nameof(DireTeam))]
        public int DireTeamId { get; set; }

        public Team DireTeam { get; set; }

        [ForeignKey(nameof(RadiantTeam))]
        public int RadiantTeamId { get; set; }

        public Team RadiantTeam { get; set; }
    }
}