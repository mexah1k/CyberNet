namespace Tournaments.Dtos.Match
{
    public class MatchDto
    {
        public int Id { get; set; }

        public int SeriesId { get; set; }

        public int DireTeamId { get; set; }

        public int RadiantTeamId { get; set; }

        public bool IsRadiantWin { get; set; }
    }
}