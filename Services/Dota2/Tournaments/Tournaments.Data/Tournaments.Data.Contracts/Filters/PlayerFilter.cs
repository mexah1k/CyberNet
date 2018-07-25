using System.ComponentModel.DataAnnotations;

namespace Tournaments.Data.Contracts.Filters
{
    public class PlayerFilter
    {
        [MaxLength(100)]
        public string NickName { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
    }
}