using Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournaments.Data.Entities
{
    public class Match : IKeyIdentifier
    {
        [Key]
        public int Id { get; set; }

        public int SeriesId { get; set; }

        [ForeignKey(nameof(SeriesId))]
        public Series Series { get; set; }

        public int DireTeamId { get; set; }

        [ForeignKey(nameof(DireTeamId))]
        public Team DireTeam { get; set; }

        public int RadiantTeamId { get; set; }

        [ForeignKey(nameof(RadiantTeamId))]
        public Team RadiantTeam { get; set; }

        public bool? IsRadiantWin { get; set; }
    }
}