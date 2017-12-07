using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}