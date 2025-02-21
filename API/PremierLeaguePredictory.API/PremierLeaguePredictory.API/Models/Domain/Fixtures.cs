﻿using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePredictory.API.Models.Domain
{
    public class Fixtures
    {
        [Key]
        public Guid FixtureId { get; set; }
        public int Gameweek { get; set; }
        public DateTime KickOff { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public string? Winner { get; set; }
        public string Status { get; set; }
        public string Season { get; set; }
    }
}
