﻿using Infrastructure.Extensions;
using System;
using System.Collections.Generic;

namespace Tournaments.Data.Entities
{
    public class Tournamet : IKeyIdentifier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<Team> Teams { get; set; }
    }
}