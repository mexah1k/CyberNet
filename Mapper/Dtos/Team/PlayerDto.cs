﻿using Database.Entities.Entities.Enum;

namespace Mapper.Dtos.Team
{
    public class PlayerDto
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Points { get; set; }

        public string PhotoUrl { get; set; }

        public PositionEnum Position { get; set; }
    }
}