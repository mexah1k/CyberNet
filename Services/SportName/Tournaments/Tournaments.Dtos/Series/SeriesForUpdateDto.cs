namespace Tournaments.Dtos.Series
{
    public class SeriesForUpdateDto
    {
        public int TournamentId { get; set; }

        public int? WinnerTeamId { get; set; }
    }
}